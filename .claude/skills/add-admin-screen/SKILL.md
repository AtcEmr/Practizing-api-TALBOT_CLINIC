---
name: add-admin-screen
description: Adds a new admin master-data screen to the Practizing UI (root admin app). Use when the user asks to "add an admin page", "add a master data screen", "create a CRUD UI for X". Follows the list+detail pattern shared by CPT, ICD, Provider, Insurance, etc.
---

# Skill: Add an admin master-data screen

The root admin app (`src/app/admin/`) hosts ~18 list+detail screens for master/reference data. They share a strong convention: a list component (ag-grid) + a detail component (PrimeNG dialog or inline form), declared as entry components on the root `AppModule`, opened via the tab system.

## When you should run this skill

- User asks for a new admin screen for a master-data entity (e.g. "add a Locations admin", "add a screen to manage referral sources").
- The corresponding API endpoints already exist (or are being added in the same change via `add-api-endpoint`).

## When you should NOT run this skill

- The screen belongs to billing/payment/claim flow — that's `projects/pibilling/`, not `src/app/admin/`.
- The screen is patient-data — that's `projects/pipatient/`.
- The screen is a dashboard or report viewer — those are different patterns.

## Inputs to gather first

1. **Entity name** — what's being managed (e.g. `Location`).
2. **List columns** — what shows in the grid.
3. **Detail fields** — what's editable.
4. **API endpoints** — usually `/api/{Entity}` (POST/PUT), `/api/{Entity}/getAll`, `/api/{Entity}/getByUId/{uid}`, `/api/{Entity}?uId={uid}` (DELETE). Confirm with the backend.

## Steps

UI repo: `c:\Users\MadhukarNarahari\Documents\GitHub\Practizing-ui-TALBOT_CLINIC`. **All paths below are relative to that repo, not this API repo.**

### 1. Create folder structure

```
src/app/admin/{entity}/
├── shared/
│   ├── {entity}.model.ts
│   ├── {entity}.service.ts
│   └── {entity}.enum.ts            (only if needed)
├── {entity}.component.ts
├── {entity}.component.html
├── {entity}.component.css
└── {entity}-detail/
    ├── {entity}-detail.component.ts
    ├── {entity}-detail.component.html
    └── {entity}-detail.component.css
```

### 2. Service

```typescript
// shared/{entity}.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { {Entity}Model } from './{entity}.model';

@Injectable({ providedIn: 'root' })
export class {Entity}Service {
  constructor(private http: HttpClient) {}

  getAll(): Observable<{Entity}Model[]> {
    return this.http.get<{Entity}Model[]>('{Entity}/getAll?RunCount=true');
  }

  getByUid(uid: string): Observable<{Entity}Model> {
    return this.http.get<{Entity}Model>(`{Entity}/getByUId/${uid}`);
  }

  save(model: {Entity}Model): Observable<{Entity}Model> {
    return model.id > 0
      ? this.http.put<{Entity}Model>('{Entity}', model)
      : this.http.post<{Entity}Model>('{Entity}', model);
  }

  delete(uid: string): Observable<void> {
    return this.http.delete<void>(`{Entity}?uId=${uid}`);
  }
}
```

**Required guarantees:**
- Use **typed generics** (`<{Entity}Model[]>`), not `Observable<any>`. New code must type its returns even if the surrounding code doesn't.
- URLs are **relative**. The HTTP interceptor prepends `environment.apiUrl`.

### 3. Model

```typescript
// shared/{entity}.model.ts
export class {Entity}Model {
  id = 0;
  uId: string = '';
  name: string = '';
  isActive: boolean = true;
  // …other fields
}
```

### 4. List component

```typescript
import { Component, OnInit, OnDestroy, ViewChild } from '@angular/core';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { GridOptions } from 'ag-grid';
import { ToastrService } from 'ngx-toastr';
import { {Entity}Service } from './shared/{entity}.service';
import { {Entity}Model } from './shared/{entity}.model';

@Component({
  selector: 'app-{entity}',
  templateUrl: './{entity}.component.html',
  styleUrls: ['./{entity}.component.css'],
})
export class {Entity}Component implements OnInit, OnDestroy {
  private destroy$ = new Subject<void>();

  list: {Entity}Model[] = [];
  selected: {Entity}Model = new {Entity}Model();
  showDetail = false;

  columnDefs = [
    { headerName: 'Name', field: 'name', filter: true, sortable: true },
    { headerName: 'Active', field: 'isActive', filter: true, sortable: true },
  ];
  gridOptions: GridOptions = { enableSorting: true };

  constructor(private service: {Entity}Service, private toastr: ToastrService) {}

  ngOnInit() { this.refresh(); }

  ngOnDestroy() { this.destroy$.next(); this.destroy$.complete(); }

  refresh() {
    this.service.getAll()
      .pipe(takeUntil(this.destroy$))
      .subscribe(rows => this.list = rows);
  }

  onRowClick(row: {Entity}Model) {
    this.selected = row;
    this.showDetail = true;
  }

  onAdd() {
    this.selected = new {Entity}Model();
    this.showDetail = true;
  }

  onSaved(saved: {Entity}Model) {
    this.toastr.success('Saved');
    this.showDetail = false;
    this.refresh();
  }

  onCancel() { this.showDetail = false; }
}
```

**Required guarantees:**
- Implement `OnDestroy` and use `takeUntil(this.destroy$)` on every subscribe. The codebase historically leaks subscriptions on tab close — new code must not.
- No `Observable<any>`. No `subscribe` without cleanup.

### 5. Detail component

A simple form bound with `ngModel`. Emits `(saved)` and `(cancel)` events. See `provider-details.component.ts` for the canonical shape.

### 6. Register in `AppModule`

`src/app/app.module.ts`:

```typescript
import { {Entity}Component } from './admin/{entity}/{entity}.component';
import { {Entity}DetailComponent } from './admin/{entity}/{entity}-detail/{entity}-detail.component';

@NgModule({
  declarations: [
    // …existing
    {Entity}Component,
    {Entity}DetailComponent,
  ],
  entryComponents: [
    // …existing
    {Entity}Component,         // required: opened dynamically by the tab system
  ],
  // …
})
```

**Forgetting `entryComponents` registration** is the #1 cause of "tab opens blank" in this codebase.

### 7. Wire to the menu / tab open

Add the menu entry wherever the admin menu lives (typically in the shell `BaseComponent`'s template). Emit a tab-open event with the component selector or a key that maps to it.

## Verify
1. Run `npm start` (port 4100).
2. Log in, open the new menu entry.
3. Confirm list loads, detail opens on row click, save returns to list, cancel discards.
4. Switch tabs and reopen — confirm no console errors (subscription leak hint).

## What this skill does NOT do

- It does not create the API endpoints. Use `add-api-endpoint` first if they don't exist.
- It does not add permission gating — there is no permission directive in this codebase yet.
- It does not write tests; the codebase has minimal UI tests.

## Common mistakes

- Using `Observable<any>` because surrounding code does. New code should type returns.
- Forgetting `entryComponents` declaration → tab opens but renders nothing.
- Subscribing without `takeUntil` → memory leak when the tab closes (re-opening grows memory each time).
- Putting the screen under `projects/pibilling/` because the entity feels billing-related. Master data lives in `src/app/admin/`. Billing-flow screens live in pibilling.
- Hardcoded `http://localhost:5001/api/...` in the service — use relative paths only.

## Cross-references

- [docs/architecture/UI_ARCHITECTURE.md](../../../docs/architecture/UI_ARCHITECTURE.md) — workspace layout, interceptors, tab system
- [docs/architecture/SECURITY_AND_RISKS.md #12](../../../docs/architecture/SECURITY_AND_RISKS.md) — subscription cleanup rule
- Reference screens to copy: `src/app/admin/cpt-codes/` (simple), `src/app/admin/provider/` (with sub-tabs)
