---
name: write-tests
description: Writes tests for changed code in the Practizing API or UI. Use when the user asks to "write tests for X", "add coverage for Y", or after running /coverage-plan and wanting to author the recommended P0 tests. Picks the right layer (unit / repository contract / API integration / golden-master) and follows the project's existing test patterns.
---

# Skill: Write tests for changed code

> Pair this skill with `/coverage-plan`. The plan tells you *what* to test; this skill tells you *how to author each test* in the patterns this codebase uses.

## When to use this skill

- User asks to write tests for a change.
- After `/coverage-plan` produced a P0 list and the user wants to act on it.
- Before merging a non-trivial change without tests.

## When NOT to use this skill

- Adding tests for code outside the user's change scope. That's a separate "ratchet coverage" task.
- Writing exhaustive parameterized matrices for inputs that won't vary in production. Two clear tests beat one obscure parameterized one.

## Step 0: Sanity-check existing infrastructure

This codebase has very little usable test infrastructure today, and what exists is **legacy and brittle — do not copy it blindly**.

**API side — two existing test projects, both legacy:**
- `Common/PractiZing.UnitTest.Common/` — has `DependencyResolverTest.cs` and `TestStartUp.cs`. Issues: `DBConnection()` hardcodes a developer's local SQL Server credentials (`DESKTOP-PBHUBDF\SA`, `sa/sa$123`) and an expired ServiceStack license, then returns `null`. It also depends on `SqlServerOrmLiteDialectProvider`, which means tests in this project cannot run on CI or against the team DB without rewriting the fixture.
- `DenialManagementService/PractiZing.UnitTest.DenialService/` — second test project, similar shape.

**Do not extend either project as-is.** When you add real tests:
1. Create or augment a new `*.Tests` project alongside the production project (e.g. `ChargePaymentService/PractiZing.Tests.ChargePaymentService/`).
2. Build a new `RepositoryTestBase` that reads the test DB connection from `appsettings.Test.json` or env var — never hardcoded.
3. Do not import `DependencyResolverTest` from your new tests.

If you must touch the legacy projects, mark them in the PR description so the team knows to plan a cleanup.

**UI side — ~34 `.spec.ts` stubs, most don't assert anything.** Two practical caveats:
- The Angular CLI runner needs `npm install` first. The repo currently has no `node_modules` checked in (and shouldn't); confirm the dev environment is set up before running `ng test --watch=false`.
- This is **Angular 7.1**. The modern `TestBed.inject(X)` API does NOT exist here — use `TestBed.get(X)`. The component testing patterns shown later in this skill follow Angular 7 conventions; do not "modernize" them.

If the harness is genuinely missing and adding it is out of scope, **say so explicitly to the user.** Do not write a test that depends on infrastructure that doesn't exist.

## Choosing the layer

| If the change is… | Layer |
|---|---|
| A pure calculation, validation, or state transition (no DB, no HTTP) | **Unit** |
| A repository method that issues a query | **Repository contract** (real-DB integration) |
| An API endpoint that goes through the full request pipeline | **API integration** |
| A stored procedure or `PZ_Report.Command` change | **Golden-master** (compare output to a captured baseline) |
| An Angular component or service | **UI** (Karma / Jasmine) |

A typical CRUD endpoint warrants tests at multiple layers. `/coverage-plan` has already classified each test in its P0 list; trust that classification and follow it here.

## Authoring patterns

### Unit test (API)

xUnit-style; use the existing `PractiZing.UnitTest.Common` references. Place under a new file mirroring the production code's path:

```csharp
public class ChargeBalanceCalculatorTests
{
    [Fact]
    public void Balance_is_total_minus_payments_minus_adjustments()
    {
        var charge = new Charge { Total = 100m };
        var payments = 60m;
        var adjustments = 10m;

        var result = ChargeBalanceCalculator.Compute(charge, payments, adjustments);

        Assert.Equal(30m, result);
    }

    [Fact]
    public void Negative_balance_clamps_to_zero_when_overpaid()
    {
        var charge = new Charge { Total = 50m };
        var result = ChargeBalanceCalculator.Compute(charge, 100m, 0m);
        Assert.Equal(0m, result);
    }
}
```

Keep tests focused on **one behavior each**. Long names in the form `Method_returns_X_when_Y` are preferred over short cryptic ones.

### Repository contract test (API)

Real DB, not a mock. The migration plan explicitly calls for real-DB tests because mock-based tests pass in dev and fail in prod (the SQL → PG migration is the canonical example).

Use a **dedicated test database** (not the team's shared dev DB), seeded per test and rolled back after. Write into `PractiZing.UnitTest.Integration` (create if needed) and document the DB connection in the test class.

```csharp
public class ChargeRepositoryTests : RepositoryTestBase
{
    [Fact]
    public async Task GetById_returns_only_rows_for_logged_in_practice()
    {
        // arrange: seed two charges in two practices
        await SeedAsync(new Charge { Id = 1, PracticeId = 1, ... });
        await SeedAsync(new Charge { Id = 2, PracticeId = 2, ... });

        var repo = NewRepositoryAs(practiceId: 1);

        // act
        var result = await repo.GetById(2);    // foreign-practice id

        // assert: should NOT return practice 2's row
        Assert.Null(result);
    }
}
```

Multi-tenant tests like this one are mandatory for any new per-practice repository method. They catch the "default practice 1" class of bugs documented in [SECURITY_AND_RISKS.md §10](../../../docs/architecture/SECURITY_AND_RISKS.md).

### API integration test (API)

Use `WebApplicationFactory<Startup>` to spin up the service in-process. Hit the endpoint with `HttpClient`. Assert status code + body shape.

```csharp
public class ChargeControllerTests : IClassFixture<ApiFactory<Startup>>
{
    private readonly HttpClient _client;
    public ChargeControllerTests(ApiFactory<Startup> f) { _client = f.CreateAuthenticatedClient(practiceId: 1); }

    [Fact]
    public async Task Get_returns_401_without_bearer_token()
    {
        var anon = _client.WithoutAuth();
        var r = await anon.GetAsync("/api/Charge/1");
        Assert.Equal(HttpStatusCode.Unauthorized, r.StatusCode);
    }

    [Fact]
    public async Task Get_returns_404_for_charge_in_different_practice()
    {
        // seed a charge in practice 2; client is auth'd as practice 1
        await SeedChargeInPractice(id: 99, practiceId: 2);
        var r = await _client.GetAsync("/api/Charge/99");
        Assert.Equal(HttpStatusCode.NotFound, r.StatusCode);
    }
}
```

For endpoints that today accidentally return cross-practice data because of a missing filter, write the test that *would* fail with the bug. Then fix the bug. Then the test guards the fix.

### Golden-master test (SP / report)

Use this when changing a stored procedure or a `PZ_Report.Command` row.

```csharp
public class RptAgingByInsuranceGoldenTests
{
    [Fact]
    public async Task Output_matches_baseline_for_sample_inputs()
    {
        // arrange: a captured baseline JSON in test/fixtures/rpt_aging_by_insurance_baseline.json
        var baseline = JsonConvert.DeserializeObject<List<AgingRow>>(
            File.ReadAllText("fixtures/rpt_aging_by_insurance_baseline.json"));

        // act: run the SP against the test DB seeded with the same scenario
        var actual = await Db.QueryAsync<AgingRow>(
            "exec rpt_Aging_Summary_By_Insurance @ToDate",
            new { ToDate = new DateTime(2026, 1, 31) });

        // assert: row count, then per-row diff
        Assert.Equal(baseline.Count, actual.Count());
        Assert.Equal(baseline, actual.OrderBy(x => x.InsuranceCompanyId), new AgingRowComparer());
    }
}
```

Capture the baseline **before** the change. The test fails on either a regression or an intentional change; in the latter case, regenerate the baseline as part of the PR.

This pattern is the migration plan's Phase 4 acceptance criterion. Investing in it now pays off twice — once for regression coverage, once for the SQL Server → PostgreSQL parity comparison later.

### UI test (Angular)

Karma + Jasmine, matching the existing `.spec.ts` style. Use `TestBed` to compile the component, assert template rendering, and use `HttpClientTestingModule` to stub HTTP.

```typescript
// Angular 7.1 — use TestBed.get(), NOT TestBed.inject() (inject is Angular 9+).
describe('ProviderComponent', () => {
  let comp: ProviderComponent;
  let fixture: ComponentFixture<ProviderComponent>;
  let http: HttpTestingController;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      declarations: [ProviderComponent],
      providers: [ProviderService, ToastrService],
    }).compileComponents();
    fixture = TestBed.createComponent(ProviderComponent);
    comp = fixture.componentInstance;
    http = TestBed.get(HttpTestingController);          // Angular 7
  });

  it('loads providers on init', () => {
    fixture.detectChanges();
    const req = http.expectOne('Provider/getProviderList?RunCount=true');
    req.flush([{ id: 1, name: 'Dr. X' }]);
    expect(comp.providerList.length).toBe(1);
  });
});
```

Always assert subscriptions clean up. The codebase leaks subscriptions (see [SECURITY_AND_RISKS.md §13](../../../docs/architecture/SECURITY_AND_RISKS.md)) — new components should be tested for it.

## Rules a contributing AI must follow

1. **Don't mock the database for repository tests.** Real DB. The migration plan demands it.
2. **Each test asserts one behavior.** No god-tests.
3. **Test names describe behavior, not method names.** `Returns_404_when_charge_belongs_to_other_practice`, not `TestGetChargeBadId`.
4. **Audit-timestamp columns are excluded from equality assertions** (the migration plan's trigger-noise rule). Capture them, but don't compare them as strict equality unless that's the test's whole point.
5. **Multi-tenant tests are mandatory** for any new per-practice query. The "different practice's row should be invisible" assertion catches the most common bug in this codebase.
6. **Don't add tests for code outside your change.** Coverage ratcheting is per-PR, not per-test.
7. **If the test infrastructure isn't there, say so.** Don't write tests against missing infrastructure and call it done.

## Cross-references

- [`docs/architecture/SECURITY_AND_RISKS.md`](../../../docs/architecture/SECURITY_AND_RISKS.md) — risk patterns to write tests for.
- [`docs/database/sql-server-to-postgres-migration-plan.md`](../../../docs/database/sql-server-to-postgres-migration-plan.md) — Phase 1 (test baseline) and Phase 4 (golden-master) tie directly to this skill.
- [`/coverage-plan`](../../commands/coverage-plan.md) — runs first; this skill executes the plan.
