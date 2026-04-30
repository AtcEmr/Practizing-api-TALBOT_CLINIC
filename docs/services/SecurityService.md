# SecurityService

**Folder**: `SecurityService/`
**Container name in compose**: `practizing-security`

## Purpose

User authentication, authorization, role/permission management. The
actual JWT issuance happens in HostService (the token endpoint), but
the credential-validation logic and user/role/permission CRUD live here.

## Key controllers

5 controllers. Compact and clear:

| Controller | What |
|---|---|
| `LoginController` | Validate credentials; usually called by HostService's token-provider middleware via `IdentityResolver` |
| `LogoutController` | Server-side logout (clears `LoggedInUser`) |
| `UserController` | CRUD users |
| `UserRoleController` | Assign/revoke roles per user |
| `UserPermissionController` | Per-user permission overrides |

## Key tables

| Table | Purpose |
|---|---|
| `User` | The user account record |
| `Role` | Named roles (e.g. "Biller", "Admin") |
| `UserRole` | user ↔ role link |
| `PZModule` | Application modules ("Charges", "Reports", ...) |
| `RoleModule` | Per-role module access |
| `UserPermission`, `UserPermissionConfig` | User-specific overrides |
| `ModulePermission` | Permission types per module |
| `LoggedInUser` | Current sessions |
| `UserAuthentication` | Authentication attempts / sessions |
| `PracticeCentralPractice` | **Lives in PracticeCentral DB** — every tenant practice and its DB |

## Authentication flow

```
UI POST /token  { username, password }
  │
  ▼
HostService SimpleTokenProvider middleware
  │
  ▼
IdentityResolver.CheckUserLogin(username, password)
  │
  ▼
SecurityService.LoginRepository / UserAuthenticationRepository
  - Look up the User
  - Hash and compare passwords (or whatever the algorithm is — verify in code)
  - On success, return ClaimsIdentity with PracticeCode and roles
  │
  ▼
HostService signs JWT with the hardcoded HMAC key (🔴 see TROUBLESHOOTING)
  │
  ▼
JWT returned to UI
```

For Azure AD (`/tokenAzure`), the password is ignored and `CheckUserLoginAzure(username, "")` is called. **The Azure AD verification is not visible in the code I've seen** — it's likely incomplete or relies on out-of-band trust.

## Dependencies

- `Common/*`
- HostService is the only consumer of `IdentityResolver`.

## Notable repository methods

- `UserAuthenticationRepository.SetAllInCache(_practices)` — preloads all currently-logged-in users into in-memory cache at HostService startup
- `UserAuthenticationRepository.RemoveAllExpiredTokenFromCache(_practices)` — currently commented out at the call site, may not be wired
- `IdentityResolver.CheckUserLogin(username, password)` — validates plaintext password against stored hash (verify the algorithm before any password-policy work)

## Known gotchas

- 🔴 **JWT secret is hardcoded** in HostService, not in this service. Rotating it requires changes elsewhere.
- 🟡 The cache invalidation logic (`RemoveAllExpiredTokenFromCache`) is commented out — expired tokens may stay cached for the container's lifetime.
- 🟡 No password-policy enforcement code visible (length, complexity, history).
- 🟡 No account lockout after N failed attempts visible.
- 🟢 The Azure AD path appears incomplete; if you wire it, audit `CheckUserLoginAzure` first.
