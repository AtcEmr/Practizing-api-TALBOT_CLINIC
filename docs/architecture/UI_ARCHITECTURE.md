# UI Architecture — Practizing Angular Frontend

For orientation, start at [SYSTEM_OVERVIEW.md](./SYSTEM_OVERVIEW.md). For recipes, [RECIPES.md](../conventions/RECIPES.md). For risks, [SECURITY_AND_RISKS.md](./SECURITY_AND_RISKS.md).

The UI source lives in the sibling repo `Practizing-ui-TALBOT_CLINIC`.

## 1. Workspace layout

`angular.json` defines a single workspace with 4 projects:

| Project | Path | Prefix | Role |
|---|---|---|---|
| `piworkspace` (default) | `src/` | `app` | Root admin app — auth shell, master data, tab system |
| `pibilling` | `projects/pibilling/` | `billing` | Billing/charges/payments/claims/denial/reports |
| `pipatient` | `projects/pipatient/` | `patient` | Patient demographics, insurance, alerts |
| `pi-lib` (library) | `projects/pi-lib/` | n/a | ng-packagr lib exposing `Base*` component classes (BaseProvider, BaseCharges, BaseBillingInfo, BaseClaim, BasePatient, …) |

**Build order:** `pi-lib` MUST be built first; the apps consume it via the `pi-lib` path alias in `tsconfig.json`. The Dockerfile honors this.

**Tech stack:** Angular **7.1**, TypeScript 3.1, RxJS **6** (with old-style `rxjs/add/operator/...` imports still in use), PrimeNG 7.1, ag-grid 18/20, ngx-spinner 7, ngx-toastr 9, Bootstrap 3.3 (legacy CSS only). Node 14 for build.

**Dependency between root and sub-apps:** `pibilling` and `pipatient` are **NOT lazy-loaded in the Angular Router sense.** The root app's routing module imports them as `forRoot()` ModuleWithProviders; everything is in the main bundle. The "lazy" feel comes from the tab system (see §3).

## 2. Routing

Top-level (`src/app/app-routing.module.ts`):
```typescript
{ path: '', component: BaseComponent, canActivate: [AuthGuard], children: [
    { path: 'billing', loadChildren: () => PIBillingSharedModule },
    { path: 'patient', loadChildren: () => PIPatientSharedModule },
] },
{ path: 'sign-in', component: SignInComponent },
{ path: '**', redirectTo: '/sign-in' }
```

`useHash: true` — URL stays at `#/sign-in` (or `#/billing`, etc.) regardless of which tab the user is on. **Deep linking is not supported.**

**AuthGuard** (`src/app/shared/guards/auth.guard.ts`): checks `localStorage.Authorization`. Nothing more. No role check, no expiration check (the JWT is checked server-side; a stale token bounces the user via the 401 handler in `ApiHttpInterceptor`).

## 3. Tab system (the real navigation)

`TabMaintainService` (`src/app/components/services/tab-maintain.service.ts`) is the de facto router. It exposes BehaviorSubjects for opening/closing/renaming tabs and passing context (e.g. patient info) between them. The visible workspace is a `TabsComponent` that listens to these subjects and adds/removes tab views dynamically.

Why this matters:
- Components are created and destroyed on tab open/close. Subscriptions that aren't cleaned up will leak.
- There is no URL-driven state. To "navigate to patient X", components emit a tab-open event, not a router navigate.
- The browser back button does not work as users expect.

## 4. State management

No NgRx, no Akita. Three sources of state:

1. **`localStorage`** via `LocalStorageService` (`src/app/shared/services/local-storage.service.ts`):
   - `Authorization` — `bearer <smallToken>`. Cleared on 401.
   - `practiceName`, `tabs`, `moduleName`.
   - JWT is decoded with `jwt-decode` to surface practice name and user info on demand.
2. **RxJS Subjects** in singleton services (`TabMaintainService`, `LoaderService`, `GlobalsService`).
3. **Component state** for everything else.

There is no global "current practice" service beyond `localStorage`. The UI does not pass practice code in headers — the API picks it up from the HTTP host. **Don't add hardcoded practice codes in client code.**

## 5. HTTP layer

Two interceptors wrap every request, in order:

### `TokenInterceptor` (runs first)
- Reads `localStorage.Authorization`.
- Adds `Authorization` header and an `_rid` (random request id) header.
- Pushes the request into `GlobalService.requestedURL` so other code can correlate.
- Does not handle 401 itself.

### `ApiHttpInterceptor`
- Prepends `environment.apiUrl` to every relative URL.
- Appends `?_rid=<rand>` (or `&_rid=...`) to the URL — yes, both header and query string carry it (legacy).
- Shows a global ngx-spinner on POST/PUT.
- On error:
  - **401** → clears `Authorization`, navigates to `/sign-in`.
  - **403** → silent.
  - **400** → expects `error.validationErrors` to be an array, joins messages with `<br/>`, toasts.
  - **500** → toasts the body string.
  - **0** → "Server down!".

**Known bug** in `api.interceptor.ts:57,83`: `if (item.rId = _rid)` uses assignment, not comparison. The condition is always truthy. Works only because the list gets spliced regardless. Don't copy that pattern; if you fix it, test the spinner-hide logic carefully.

## 6. Service pattern

Every Angular service that hits the API looks like this (e.g. `provider.service.ts`):

```typescript
@Injectable({ providedIn: 'root' })
export class ProviderService {
  constructor(private httpClient: HttpClient) {}

  getProviderList(): Observable<any> {
    return this.httpClient.get('Provider/getProviderList?RunCount=true')
      .map((response: any) => response);   // legacy operator-on-Observable, not pipe()
  }
}
```

Conventions:
- URL is **relative** — interceptor adds `environment.apiUrl`.
- Returns are `Observable<any>` almost everywhere (loose typing — codebase smell).
- No `.catch` in services; errors flow up to the interceptor.
- `import 'rxjs/add/operator/map'` (deprecated) is still common.

## 7. Forms

Template-driven (`FormsModule`) only — no `ReactiveFormsModule` in active use. Validation is via custom directives (`OnlyNumberDirective`, `DecimalNumber`, `OnlyAlphabetic`, `DateSetterDirective`, etc.) plus manual required-field checks before submit.

There is **no dirty/pristine tracking** and no "discard changes?" prompt. Switching tabs while editing silently loses data.

## 8. UI library & shared components

- **PrimeNG 7.1**: tables, dialogs, dropdowns, calendars, toolbar pieces.
- **ag-grid 18/20**: data grids (provider list, charges, fee schedules, master data).
- **ngx-spinner**: global spinner driven by interceptor.
- **ngx-toastr**: error/success messages, `enableHtml: true, timeOut: 10s`.
- Shared building blocks in `src/app/shared/components/`: `CustomCheckboxComponent`, `CustomButtonComponent`, `CustomHeaderComponent`, `SubHeaderComponent`, `SpinnerComponent`, `NoteAssignToComponent`, `NewActionNoteComponent`.

## 9. Domain layout (where each feature lives)

### Root admin app (`src/app/admin/`)
Most master-data screens follow a pattern: a list component + a detail component. All declared as `entryComponents` in the root `AppModule`.

| Folder | Feature | Service file |
|---|---|---|
| `action-category/` | Action note categories | `action-category.service.ts` |
| `adjustment-reason-code/` | CARC/RARC management | `adjustment-reason-code.service.ts` |
| `base-month-end/` | Month-end close | `base-month-end.service.ts` |
| `charges/` | Admin charge view (1089 lines — refactor candidate) | `charges.service.ts` |
| `cpt-codes/`, `cpt-category/`, `cpt-modifier/` | CPT master | `cpt-codes.service.ts` etc. |
| `era-details/` | ERA viewer | `era-details.service.ts` |
| `facility/` | Facility master + identities | `facility.service.ts` |
| `hcfa-form-fields/` | HCFA-1500 form config | `hcfa-form-fields.service.ts` |
| `icd10/` | ICD-10 master | `icd10.service.ts` |
| `insurance/` | Insurance company master | `insurance.service.ts` |
| `ndc/` | NDC drug codes | `ndc.service.ts` |
| `new-action-note/`, `note-category/`, `action-note-assign/` | Action notes | `new-action-note.service.ts` |
| `practitioner-service/` | Practitioner service codes | `practitioner-service.service.ts` |
| `provider/` | Provider master + identities + referring | `provider.service.ts`, `referring-providers.service.ts` |
| `service-circumstance/` | Service circumstance codes | `service-circumstance.service.ts` |
| `user/` | User mgmt + permissions matrix | `user.service.ts` |

### Billing sub-app (`projects/pibilling/src/app/`)
Major folders, with line counts on the heavy ones:

| Folder | Feature | Notes |
|---|---|---|
| `analytics/`, `dashboard/`, `payment-analytics/` | Dashboards | Read-only |
| `bank-reconciliation/` | Bank/deposit matching (999 lines) | Hits `/bankreconciliation/sync` SPs |
| `billing-info/` | Patient → invoices → charges hub (1285 lines) | Has 8 sub-folders (post-charge, patient-alert, patient-note, statement, etc.) |
| `bulk-statement/` + `bulk-statement11/` | Bulk patient statements **(two parallel implementations — duplication smell)** |
| `charges-payments/` | Charge-payment grid |
| `cliam/` (sic) | Claim review (901 lines) |
| `cpa-management/` | Claim Processing Automation |
| `denial-dashboard/`, `denial-management/`, `denial-manager/` | 3 separate denial screens |
| `fee-schedule/` | Fee schedules (692 lines) |
| `hl7-status/` | HL7 transmission status |
| `online-payment/` | Patient online payment (688 lines) |
| `payment/` + `old_payment_screen/` | New + legacy payment screens **(both active — duplication smell)** |
| `plaid-payment/` | Plaid match UI |
| `reports/` | Generic report runner + RDLC option components |
| `client-payment/`, `client-payment-search/` | Client billing |
| `take-back-payments/` | Refund / takeback |
| `patient-balance/` | Aging balances |

### Patient sub-app (`projects/pipatient/src/app/`)
- `patient-info/` (root)
- `patient-search/`
- `demographics/` with sub-folders for `patient-info`, `insurance` (policy, insurance-company, guarantor, authorization)
- `action/`
- Shared directives & pipes (mirror what's in the root app — yes, that's duplication too)

## 10. Permissions in the UI

There is **no permission directive** to gate buttons by role. The user-permissions admin screen reads/writes the permission model, but enforcement happens server-side. In practice, all UI actions are visible to all logged-in users; if you want to gate an action, you need to:
1. Add a permission service that decodes claims from JWT.
2. Use `*ngIf="permission.has('scope')"` on the button.

This is not implemented. Do not assume buttons are hidden for unauthorized users.

## 11. Build & deploy

- `npm ci --ignore-scripts && npm install node-sass@4.14.1` (workaround for broken postinstall on node-sass 4.10).
- `ng build pi-lib` then `ng build --configuration=production` for the workspace.
- Output served by nginx in stage 2.
- `docker-entrypoint.sh` requires `API_URL` env var; renders `nginx.conf.template` with it. Nginx reverse-proxies `/api/*` → `${API_URL}/api/`.
- Bundle budgets: piworkspace 10 MB warning/error; pibilling/pipatient 4–5 MB.

## 12. Anti-patterns to avoid in new code

1. **Subscriptions without cleanup.** ~164 `.subscribe()` calls vs. ~14 unsubscribe/takeUntil/async-pipe. Use `takeUntil(this.destroy$)` or async pipe; tab close is frequent here.
2. **`Observable<any>` returns.** Type your service methods with the actual model interface.
3. **Hardcoded URLs in components.** Always go through a service, and let the interceptor prepend the base URL.
4. **Practice-code logic in components.** It belongs in the JWT and the API; the UI should not be inventing it.
5. **Reactive forms in some screens, template-driven in others.** Match the surrounding style of the screen you're editing — don't half-migrate.
6. **Adding files to `bulk-statement/` vs `bulk-statement11/`, `payment/` vs `old_payment_screen/` without checking which one is live.** Confirm via routing/tab opens which file is actually rendered before editing.
7. **Adding components without entry-component or declarations registration.** The compile-time error is unhelpful; check `app.module.ts` after adding.
8. **Toasting raw error bodies.** The interceptor already handles common error shapes — don't double-toast in the component.
9. **`useHash: true` is intentional today.** Don't flip to PathLocationStrategy without coordinating with backend nginx config.
10. **Rebuilding `pi-lib` types** — if you change a Base class, you must rebuild `pi-lib` before the apps will see the new shape; consuming projects import from `dist/pi-lib`.
