# Recipes — How to Add X Without Breaking Anything

Each recipe is the canonical, copy-from-an-existing-feature pattern for this codebase. Read [SYSTEM_OVERVIEW.md](../architecture/SYSTEM_OVERVIEW.md) and [SECURITY_AND_RISKS.md](../architecture/SECURITY_AND_RISKS.md) once before using these.

---

## Add an API endpoint (CRUD on a new entity)

**1. Add the entity interface** (`Base/PractiZing.Base/Entities/{Service}/I{Entity}.cs`):
```csharp
public interface IMyThing : IStamp, IPracticeDTO, IUniqueIdentifier
{
    string Name { get; set; }
    bool IsActive { get; set; }
}
```

**2. Add the entity class** (`{Service}/PractiZing.DataAccess.{Service}/Tables/MyThing.cs`):
```csharp
[Alias("MyThing")]
public class MyThing : IMyThing
{
    [Key, AutoIncrement] public long Id { get; set; }
    public Guid UId { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public int PracticeId { get; set; }
    public long CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public long ModifiedBy { get; set; }
    public DateTime ModifiedDate { get; set; }
}
```

**3. Add the repository interface** (`Base/PractiZing.Base/Repositories/{Service}/IMyThingRepository.cs`):
```csharp
public interface IMyThingRepository
{
    Task<IEnumerable<IMyThing>> GetAll();
    Task<IMyThing> GetById(long id);
    Task<IMyThing> AddNew(IMyThing entity);
    Task<int> Update(IMyThing entity);
    Task<int> DeleteById(long id);
}
```

**4. Implement the repository** (`{Service}/PractiZing.BusinessLogic.{Service}/Repositories/MyThingRepository.cs`):
```csharp
public class MyThingRepository : BaseRepository<MyThing>, IMyThingRepository
{
    public MyThingRepository(ValidationErrorCodes errorCodes, DataBaseContext db, ILoginUser user)
        : base(errorCodes, db, user) { }

    public async Task<IEnumerable<IMyThing>> GetAll()
        => await Connection.SelectAsync<MyThing>(x => x.PracticeId == LoggedUser.PracticeId && x.IsActive);

    public async Task<IMyThing> GetById(long id) => await base.GetById(id);
    public async Task<IMyThing> AddNew(IMyThing e) => await AddNewAsync((MyThing)e);
    public async Task<int> Update(IMyThing e) => await UpdateAsync((MyThing)e);
    public async Task<int> DeleteById(long id) => await DeleteByIdAsync<MyThing>(id);
}
```
**Always filter `GetAll`-style queries by `LoggedUser.PracticeId`.** Audit columns are auto-stamped by `BaseRepository` — don't set them manually.

**5. Register in DI** (`{Service}/PractiZing.BusinessLogic.{Service}/{Service}RepositoryCollectionExtension.cs`):
```csharp
services.AddScoped<IMyThingRepository, MyThingRepository>();
```
There is no assembly scan — missing this line is a runtime DI failure, not a compile error.

**6. Add the controller** (`{Service}/PractiZing.Api.{Service}/Controllers/MyThingController.cs`):
```csharp
[Route("api/[controller]")]
public class MyThingController : SecuredRepositoryController<IMyThingRepository>
{
    public MyThingController(IMyThingRepository repo) : base(repo) { }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try { return Ok(await Repository.GetAll()); }
        catch (EntityException ex) { return StatusCode(400, ex.ValidationCodeResult); }
        catch (Exception ex) { _logger.LogError(ex, "MyThing.GetAll"); return StatusCode(500, "Internal error"); }
    }
}
```
**Do not return `ex.Message`.** Log it; return a generic string.

**7. Verify** by hitting `/swagger` on the local service. The new endpoint should appear automatically.

---

## Add a stored procedure call

**Pick the right pattern** — see [STORED_PROCEDURES.md §2](../../STORED_PROCEDURES.md#2-sp-invocation-patterns-in-the-api).

**For a select with safe (typed, non-string) inputs:**
```csharp
var result = await ExecuteStoredProcedureAsync<DenialDTO>("usp_GetDenials", agingDays, practiceId);
```

**For anything that takes user-supplied strings, or returns a DataTable:**
```csharp
using (var con = new SqlConnection(Connection.ConnectionString))
using (var cmd = new SqlCommand("usp_DoThing", con) { CommandType = CommandType.StoredProcedure })
{
    // Explicit SqlParameter types. Do NOT use AddWithValue — it infers types
    // from runtime values, causing index scans (varchar column vs inferred
    // nvarchar parameter) and silent mis-promotion (nvarchar(MAX) when the
    // column is nvarchar(50)).
    cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 100) { Value = name });
    cmd.Parameters.Add(new SqlParameter("@PracticeId", SqlDbType.Int) { Value = LoggedUser.PracticeId });

    await con.OpenAsync();
    using var reader = await cmd.ExecuteReaderAsync();
    // …
}
```

**For TVP (table-valued) parameters** (e.g. the `ChargeType` TVP used by scrubs):
```csharp
var tvp = new SqlParameter("@Charges", SqlDbType.Structured) {
    Value     = chargesDataTable,
    TypeName  = "dbo.ChargeType"          // must match the DB-side type name
};
cmd.Parameters.Add(tvp);
```
Setting `SqlDbType.Structured` + `TypeName` is mandatory for TVPs in any new dispatcher code. The legacy `RunAutoScrub` path works because SqlClient infers Structured from a `DataTable`, but that's an implementation accident — don't rely on it.

**Then update the catalog**: append a row to the appropriate section of [STORED_PROCEDURES.md](../../STORED_PROCEDURES.md) so future agents can find it. The catalog is the single source of truth for which SPs are wired up.

---

## Add a new report

Reports are dispatched from `PZ_Report.Command`. You usually do **not** need to write C#.

**1. Author the SP** in the DB:
```sql
CREATE PROCEDURE rpt_MyReport
    @FromDate datetime, @ToDate datetime, @ProviderId int
AS BEGIN
    SET NOCOUNT ON;
    -- … one or more SELECTs that match an RDLC dataset shape
END
```

**2. Insert the dispatch row:**
```sql
INSERT INTO PZ_Report (ReportName, [Command], Menu, Parameters, DataSetName, ReportTypeId, IsActive, ComponentName)
VALUES (
  'My Report',
  'exec rpt_MyReport {fromDate}, {toDate}, {providerID}',
  1,                    -- menu group
  '...',                -- parameter metadata for UI
  'MyReportDataSet',
  1,                    -- 1 = RDLCReport
  1,                    -- IsActive
  'MyReportOption'      -- Angular RDLC option component name
);
```

**3. Add the RDLC option component** in the UI under `projects/pibilling/src/app/reports/...` if the report has parameters not already covered.

**4. The placeholder names in `Command` (`{fromDate}`, etc.) MUST match the keys** the UI sends in the report-options payload. A typo silently leaves the literal `{fromDate}` in the executed SQL.

**5. Append to** [STORED_PROCEDURES.md §3.5](../../STORED_PROCEDURES.md#35-reports-dispatched-dynamically-via-pz_reportcommand-pattern-24).

---

## Add a new claim scrub rule

> **Important caveat.** The dispatch model documented in earlier drafts of this guide does not match the running code. `Scrub.IsProcedure` is commented out in the entity (`Scrub.cs:22`); `ClaimBatchRepository.RunAutoScrub` (`ClaimBatchRepository.cs:506-536`) **always** executes `Scrub.StoredProcedure` as a SQL Server stored procedure. There is no C# validator branch. The two existing rows `CPTToICDValidator` and `CPTToModifierValidator` are configured but will fail at runtime — they don't exist as stored procedures.
>
> Therefore: every new scrub must be a stored procedure today. The C# path is planned but unimplemented. See [add-scrub skill](../../.claude/skills/add-scrub/SKILL.md) for the full canonical recipe.

**1. Author the SP** with the canonical signature:
```sql
CREATE PROCEDURE usp_RunScrubXX
    @Charges ChargeType READONLY,    -- TVP, see existing scrubs for type def
    @ScrubId int,
    @PracticeCode nvarchar(50)
AS BEGIN
    SET NOCOUNT ON;
    -- Return a result set shaped to match the existing usp_RunScrub*EM procedures.
    -- Do NOT INSERT into ScrubError from inside the SP — the dispatcher reads result-set [0]
    -- via SqlDataAdapter and the calling repository writes errors.
    SELECT ... FROM @Charges WHERE <failure-condition>;
END
```

**2. Insert the Scrub row** (the additional flag columns exist in the live schema but the C# entity ignores them; setting them is harmless but has no runtime effect):
```sql
INSERT INTO Scrub (Name, Description, DestinationId, Active, Priority, [Order], StoredProcedure)
VALUES ('Scrub XX – my rule', '', 1, 1, 1, 9, 'usp_RunScrubXX');
```

**3. Append to** [STORED_PROCEDURES.md §3.6](../../STORED_PROCEDURES.md#36-claim-scrubs-dispatched-dynamically-via-scrubstoredprocedure-pattern-24).

**4. Note the security blocker.** `POST /api/ClaimBatch/scrub` is `[AllowAnonymous]` and the `spName` parameter is taken from the query string; combined with `CommandType.StoredProcedure`, this is unauthenticated arbitrary stored-procedure execution. See [SECURITY_AND_RISKS.md](../architecture/SECURITY_AND_RISKS.md). Adding a new scrub adds one more procedure to the unauthenticated attack surface. Coordinate the endpoint hardening in the same change if at all possible.

---

## Add an admin master-data screen (UI)

The pattern is consistent across `src/app/admin/cpt-codes/`, `provider/`, `icd10/`, etc. Copy one that has the closest shape (simple list+detail vs. list with sub-tabs).

**1. Create the folder structure** under `src/app/admin/my-thing/`:
```
my-thing/
├── shared/
│   ├── my-thing.model.ts
│   ├── my-thing.service.ts
│   └── my-thing.enum.ts
├── my-thing.component.ts/html/css
└── my-thing-detail/
    └── my-thing-detail.component.ts/html/css
```

**2. Service** — relative URLs, returns `Observable<MyThingModel[]>`. Don't use `Observable<any>` in new code.
```typescript
@Injectable({ providedIn: 'root' })
export class MyThingService {
  constructor(private http: HttpClient) {}
  getAll(): Observable<MyThingModel[]> {
    return this.http.get<MyThingModel[]>('MyThing');
  }
  save(m: MyThingModel): Observable<MyThingModel> {
    return m.id > 0 ? this.http.put<MyThingModel>('MyThing', m) : this.http.post<MyThingModel>('MyThing', m);
  }
  remove(uid: string): Observable<void> {
    return this.http.delete<void>(`MyThing?uId=${uid}`);
  }
}
```

**3. List component** uses `ag-grid` with `gridOptions`/`columnDefs`, shows the detail child via `*ngIf` on a flag.

**4. Subscriptions:** declare `private destroy$ = new Subject<void>();` and unsubscribe in `ngOnDestroy`. Old screens don't, but new ones must (see [SECURITY_AND_RISKS.md #12](../architecture/SECURITY_AND_RISKS.md#12-ui-subscribes-without-unsubscribing)).

**5. Register components** in `src/app/app.module.ts` `declarations` (and `entryComponents` for the list, since it's opened via tabs not routes). Easy to forget — runtime error if missed.

**6. Hook to a tab-open** — wherever your menu lives, emit a tab-open event with your component name.

---

## Add a UI sub-app feature (in `pibilling` or `pipatient`)

Same shape as the admin recipe, but under `projects/{pibilling|pipatient}/src/app/{feature}/`. Register in that sub-app's `app.module.ts`. Don't put feature code under `src/` — that's the root admin app.

If the feature needs a Base class (state shared across tabs), it lives in `projects/pi-lib/src/lib/` and must be exported from `pi-lib`'s `public-api.ts`. **Rebuild `pi-lib` before the apps will see the change.**

---

## Add a new background job

**Preferred: SQL Agent job on the DB host.** Use this for anything that's pure data work (snapshots, warehouse loaders, statement-eligibility lists). The `usp_*` SPs in [STORED_PROCEDURES.md §5.1](../../STORED_PROCEDURES.md#51-likely-sql-agent--scheduled-jobs-data-warehouse-loaders-snapshots) are precedent.

**If the job needs C# code (e.g. EDI upload, external API call):**
- There is **no `IHostedService` precedent** in this codebase. Adding one is a real architectural choice — discuss with the team.
- Short-term workaround: expose an idempotent endpoint and have an external `cron` hit it.

---

## Run a stored procedure manually (when debugging)

The team-maintained DB is `PI_ATC_CLINIC` on `10.3.104.52`. With Docker:
```bash
MSYS_NO_PATHCONV=1 docker run --rm mcr.microsoft.com/mssql-tools \
  /opt/mssql-tools/bin/sqlcmd -S 10.3.104.52 -U sa -P 'YOUR_PASSWORD' \
  -d PI_ATC_CLINIC -Q "EXEC usp_GetDenialManagementAgingCountByRange" -W
```
On Git Bash/Windows, `MSYS_NO_PATHCONV=1` stops path mangling of `/opt/...`. Pull SP source with `sp_helptext '<spname>'`.

---

## When in doubt: trace before changing

For any feature you don't fully understand, run `/trace-feature <name>` (slash command in this repo's `.claude/commands/`) before editing. It walks the UI component → Angular service → API endpoint → repository → SP and surfaces what would break.
