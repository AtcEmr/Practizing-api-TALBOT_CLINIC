---
name: add-api-endpoint
description: Adds a new CRUD API endpoint end-to-end in the Practizing .NET API. Use when the user asks to "add an endpoint", "add a controller", "create a new entity API", or describes a new server-side resource that needs HTTP exposure. Walks the entity → repository → controller → DI registration steps and enforces project-specific conventions (PracticeId filter, audit columns, no ex.Message leak, no hardcoded SP names).
---

# Skill: Add an API endpoint

A new CRUD endpoint in this codebase touches **six** files across **three** projects of one service. There is no scaffolder; missing any step yields a runtime DI failure or a silent multi-tenancy leak. Follow the order.

## When you should run this skill

- User says "add a controller for X", "expose Y over HTTP", "create a CRUD API for Z".
- A feature requires server persistence and there's no existing endpoint that does the job.

## When you should NOT run this skill

- The user wants to add a **report** → use `add-report` skill instead (it's a DB row, not new C# code).
- The user wants to add a **scrub rule** → use `add-scrub` skill.
- An existing controller can take a new action method — extending an existing one is preferred over a new resource.

## Inputs to gather first

Before writing any code, confirm with the user:
1. **Entity name** (singular, PascalCase — e.g. `Foo`).
2. **Service** the entity belongs to. The decision tree:
   - patient/case/insurance → `PatientService`
   - charge/payment/voucher/claim-batch/scrub → `ChargePaymentService`
   - claim, ClaimView, 837 → `ClaimService`
   - ERA, 835 → `ERAService`
   - denial queue, dashboard → `DenialManagementService`
   - report, statement, charge-stat → `ReportService`
   - master/reference data (CPT, ICD, NDC, Insurance, Provider, Facility, Config*) → `MasterService`
   - users, roles, permissions, login → `SecurityService`
   - cross-cutting utilities (ZIP, lookup) → `HostService`
3. **Whether the table is per-practice** (almost always yes). Determines whether `PracticeId` is on the entity and whether queries filter by it.
4. **Soft delete or hard delete** — does the entity have `IsActive`?

## Steps

### 1. Entity interface
File: `Base/PractiZing.Base/Entities/{Service}/I{Entity}.cs`

```csharp
namespace PractiZing.Base.Entities.{Service}
{
    public interface I{Entity} : IStamp, IPracticeDTO, IUniqueIdentifier
    {
        string Name { get; set; }
        bool IsActive { get; set; }
    }
}
```
Drop `IPracticeDTO` only if the entity is genuinely cross-practice (rare — Master config tables sometimes are; Patient/Charge/etc. never are).

### 2. Entity table class
File: `{Service}/PractiZing.DataAccess.{Service}/Tables/{Entity}.cs`

```csharp
[Alias("{Entity}")]   // exact DB table name
public class {Entity} : I{Entity}
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

### 3. Repository interface
File: `Base/PractiZing.Base/Repositories/{Service}/I{Entity}Repository.cs`

```csharp
public interface I{Entity}Repository
{
    Task<IEnumerable<I{Entity}>> GetAll();
    Task<I{Entity}> GetById(long id);
    Task<I{Entity}> AddNew(I{Entity} entity);
    Task<int> Update(I{Entity} entity);
    Task<int> DeleteById(long id);
}
```

### 4. Repository implementation
File: `{Service}/PractiZing.BusinessLogic.{Service}/Repositories/{Entity}Repository.cs`

```csharp
public class {Entity}Repository : BaseRepository<{Entity}>, I{Entity}Repository
{
    public {Entity}Repository(ValidationErrorCodes errorCodes, DataBaseContext db, ILoginUser user)
        : base(errorCodes, db, user) { }

    public async Task<IEnumerable<I{Entity}>> GetAll()
        => await Connection.SelectAsync<{Entity}>(x => x.PracticeId == LoggedUser.PracticeId && x.IsActive);

    public async Task<I{Entity}> GetById(long id) => await base.GetById(id);
    public async Task<I{Entity}> AddNew(I{Entity} e) => await AddNewAsync(({Entity})e);
    public async Task<int> Update(I{Entity} e) => await UpdateAsync(({Entity})e);
    public async Task<int> DeleteById(long id) => await DeleteByIdAsync<{Entity}>(id);
}
```

**Required guarantees:**
- Every `Connection.Select*` against this table includes a `PracticeId == LoggedUser.PracticeId` predicate. Skip this only if the table is genuinely cross-practice.
- Audit columns are populated by `BaseRepository.SetUserStamp` — do not set `CreatedDate`, `ModifiedBy`, etc. yourself.
- No `ExecuteStoredProcedureAsync` in the basic CRUD path.

### 5. DI registration
File: `{Service}/PractiZing.BusinessLogic.{Service}/{Service}RepositoryCollectionExtension.cs`

Add inside the existing `Add{Service}Repositories` method:
```csharp
services.AddScoped<I{Entity}Repository, {Entity}Repository>();
```
**There is no assembly scan.** Forgetting this line means the controller fails at runtime with "no service has been registered".

### 6. Controller
File: `{Service}/PractiZing.Api.{Service}/Controllers/{Entity}Controller.cs`

```csharp
[Route("api/[controller]")]
public class {Entity}Controller : SecuredRepositoryController<I{Entity}Repository>
{
    private readonly ILogger<{Entity}Controller> _logger;
    public {Entity}Controller(I{Entity}Repository repo, ILogger<{Entity}Controller> logger)
        : base(repo) { _logger = logger; }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try { return Ok(await Repository.GetAll()); }
        catch (EntityException ex) { return StatusCode(400, ex.ValidationCodeResult); }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Entity}.GetAll failed");
            return StatusCode(500, "Internal error");        // never return ex.Message
        }
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        try { return Ok(await Repository.GetById(id)); }
        catch (EntityException ex) { return StatusCode(400, ex.ValidationCodeResult); }
        catch (Exception ex) { _logger.LogError(ex, "{Entity}.GetById"); return StatusCode(500, "Internal error"); }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] {Entity} entity)
    {
        try { return Ok(await Repository.AddNew(entity)); }
        catch (EntityException ex) { return StatusCode(400, ex.ValidationCodeResult); }
        catch (Exception ex) { _logger.LogError(ex, "{Entity}.Create"); return StatusCode(500, "Internal error"); }
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] {Entity} entity)
    {
        try { return Ok(await Repository.Update(entity)); }
        catch (EntityException ex) { return StatusCode(400, ex.ValidationCodeResult); }
        catch (Exception ex) { _logger.LogError(ex, "{Entity}.Update"); return StatusCode(500, "Internal error"); }
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        try { return Ok(await Repository.DeleteById(id)); }
        catch (EntityException ex) { return StatusCode(400, ex.ValidationCodeResult); }
        catch (Exception ex) { _logger.LogError(ex, "{Entity}.Delete"); return StatusCode(500, "Internal error"); }
    }
}
```

**Required guarantees:**
- `[Route("api/[controller]")]` — no version segment, the rest of the codebase doesn't use them.
- Inherit from `SecuredRepositoryController<...>` — picks up `[Authorize]`. **Do not add `[AllowAnonymous]` unless the user explicitly says the endpoint must be public.**
- Never return `ex.Message` to the client. Log it. Return a generic string.
- Use `_logger.LogError(ex, ...)` — `Console.WriteLine` is the legacy pattern; new code should not adopt it.

### 7. Verify
- Build the solution: from the API repo root, `dotnet build PractiZing.sln`.
- Start the relevant service. Hit `/swagger`. The new endpoints should appear automatically.
- Test happy path with a tool like Postman; confirm a 401 if the bearer is missing.

## What this skill does NOT do

- It does not generate the SQL migration to create the table. The DB schema is managed by Codex / DBAs under `docs/database/`. Coordinate the schema change separately.
- It does not write Angular UI to consume the endpoint.
- It does not write tests (the codebase has minimal tests; if you write one, follow `PractiZing.UnitTest.Common` patterns).

## Cross-references

- Conventions: [docs/architecture/API_ARCHITECTURE.md](../../../docs/architecture/API_ARCHITECTURE.md)
- Risks to avoid: [docs/architecture/SECURITY_AND_RISKS.md](../../../docs/architecture/SECURITY_AND_RISKS.md)
- If your endpoint needs to call a stored procedure, see also `add-sp-call` patterns in [docs/conventions/RECIPES.md](../../../docs/conventions/RECIPES.md#add-a-stored-procedure-call).
