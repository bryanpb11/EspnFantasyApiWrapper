# EspnFantasyApiWrapper .NET 10 Upgrade Tasks

## Overview

Upgrade the repository to .NET 10.0 using an All-At-Once atomic approach: prerequisites, a single atomic framework+package upgrade pass, then test execution and fixes, followed by a final commit. Tasks follow the plan's specified upgrade sequence and verification criteria.

**Progress**: 3/4 tasks complete (75%) ![0%](https://progress-bar.xyz/75)

---

## Tasks

### [✓] TASK-001: Verify prerequisites *(Completed: 2026-02-13 14:22)*
**References**: Plan §Implementation Timeline, Plan §Migration Strategy

- [✓] (1) Verify required .NET 10 SDK and supporting tool versions are installed per Plan §Implementation Timeline
- [✓] (2) Runtime/SDK version meets minimum requirements (**Verify**)
- [✓] (3) Update or create `global.json` if required per Plan §Implementation Timeline
- [✓] (4) Configuration files (Directory.Build.* / Directory.Packages.props / other MSBuild imports) compatible with target framework per Plan §All-At-Once Strategy (**Verify**)

### [✓] TASK-002: Atomic framework and package upgrade with compilation fixes *(Completed: 2026-02-13 14:24)*
**References**: Plan §All-At-Once Strategy, Plan §Project-by-Project Plans, Plan §Package Update Reference, Plan §Breaking Changes Catalog

- [✓] (1) Update `TargetFramework`/multi-targeting entries in all project files listed in Plan §Project-by-Project Plans to target .NET 10.0 per Plan §All-At-Once Strategy
- [✓] (2) All project files updated to target framework (**Verify**)
- [✓] (3) Update all NuGet package references per Plan §Package Update Reference (apply replacements and version changes as specified)
- [✓] (4) All package references updated (**Verify**)
- [✓] (5) Restore dependencies (e.g., `dotnet restore`) for the solution
- [✓] (6) All dependencies restored successfully (**Verify**)
- [✓] (7) Build the solution and fix all compilation errors caused by framework and package upgrades, following guidance in Plan §Breaking Changes Catalog
- [✓] (8) Solution builds with 0 errors (**Verify**)

### [✓] TASK-003: Run full test suite and validate upgrade *(Completed: 2026-02-13 14:31)*
**References**: Plan §Testing & Validation Strategy, Plan §Project-by-Project Plans, Plan §Breaking Changes Catalog

- [✓] (1) Run all test projects listed in Plan §Testing & Validation Strategy / Plan §Project-by-Project Plans
- [✓] (2) Fix any test failures (reference Plan §Breaking Changes Catalog for common fixes)
- [✓] (3) Re-run tests after fixes
- [✓] (4) All tests pass with 0 failures (**Verify**)

### [▶] TASK-004: Final commit
**References**: Plan §Source Control Strategy, Plan §All-At-Once Strategy

- [▶] (1) Commit all remaining changes with message: "TASK-004: Complete atomic upgrade to .NET 10.0"







