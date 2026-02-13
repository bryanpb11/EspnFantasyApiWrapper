# Projects and dependencies analysis

This document provides a comprehensive overview of the projects and their dependencies in the context of upgrading to .NETCoreApp,Version=v10.0.

## Table of Contents

- [Executive Summary](#executive-Summary)
  - [Highlevel Metrics](#highlevel-metrics)
  - [Projects Compatibility](#projects-compatibility)
  - [Package Compatibility](#package-compatibility)
  - [API Compatibility](#api-compatibility)
- [Aggregate NuGet packages details](#aggregate-nuget-packages-details)
- [Top API Migration Challenges](#top-api-migration-challenges)
  - [Technologies and Features](#technologies-and-features)
  - [Most Frequent API Issues](#most-frequent-api-issues)
- [Projects Relationship Graph](#projects-relationship-graph)
- [Project Details](#project-details)

  - [EspnFantasyApiWrapper.API\EspnFantasyApiWrapper.API.csproj](#espnfantasyapiwrapperapiespnfantasyapiwrapperapicsproj)
  - [EspnFantasyApiWrapper.ConsoleClient\EspnFantasyApiWrapper.ConsoleClient.csproj](#espnfantasyapiwrapperconsoleclientespnfantasyapiwrapperconsoleclientcsproj)
  - [EspnFantasyApiWrapper.UnitTest\EspnFantasyApiWrapper.UnitTest.csproj](#espnfantasyapiwrapperunittestespnfantasyapiwrapperunittestcsproj)


## Executive Summary

### Highlevel Metrics

| Metric | Count | Status |
| :--- | :---: | :--- |
| Total Projects | 3 | 2 require upgrade |
| Total NuGet Packages | 4 | 1 need upgrade |
| Total Code Files | 8 |  |
| Total Code Files with Incidents | 2 |  |
| Total Lines of Code | 1142 |  |
| Total Number of Issues | 3 |  |
| Estimated LOC to modify | 0+ | at least 0.0% of codebase |

### Projects Compatibility

| Project | Target Framework | Difficulty | Package Issues | API Issues | Est. LOC Impact | Description |
| :--- | :---: | :---: | :---: | :---: | :---: | :--- |
| [EspnFantasyApiWrapper.API\EspnFantasyApiWrapper.API.csproj](#espnfantasyapiwrapperapiespnfantasyapiwrapperapicsproj) | net10.0 | ✅ None | 0 | 0 |  | ClassLibrary, Sdk Style = True |
| [EspnFantasyApiWrapper.ConsoleClient\EspnFantasyApiWrapper.ConsoleClient.csproj](#espnfantasyapiwrapperconsoleclientespnfantasyapiwrapperconsoleclientcsproj) | net8.0 | 🟢 Low | 0 | 0 |  | DotNetCoreApp, Sdk Style = True |
| [EspnFantasyApiWrapper.UnitTest\EspnFantasyApiWrapper.UnitTest.csproj](#espnfantasyapiwrapperunittestespnfantasyapiwrapperunittestcsproj) | net8.0 | 🟢 Low | 1 | 0 |  | DotNetCoreApp, Sdk Style = True |

### Package Compatibility

| Status | Count | Percentage |
| :--- | :---: | :---: |
| ✅ Compatible | 3 | 75.0% |
| ⚠️ Incompatible | 1 | 25.0% |
| 🔄 Upgrade Recommended | 0 | 0.0% |
| ***Total NuGet Packages*** | ***4*** | ***100%*** |

### API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 0 | High - Require code changes |
| 🟡 Source Incompatible | 0 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 0 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 373 |  |
| ***Total APIs Analyzed*** | ***373*** |  |

## Aggregate NuGet packages details

| Package | Current Version | Suggested Version | Projects | Description |
| :--- | :---: | :---: | :--- | :--- |
| Microsoft.NET.Test.Sdk | 17.12.0 |  | [EspnFantasyApiWrapper.UnitTest.csproj](#espnfantasyapiwrapperunittestespnfantasyapiwrapperunittestcsproj) | ✅Compatible |
| MSTest | 3.6.4 |  | [EspnFantasyApiWrapper.UnitTest.csproj](#espnfantasyapiwrapperunittestespnfantasyapiwrapperunittestcsproj) | ✅Compatible |
| xunit | 2.9.3 |  | [EspnFantasyApiWrapper.UnitTest.csproj](#espnfantasyapiwrapperunittestespnfantasyapiwrapperunittestcsproj) | ⚠️NuGet package is deprecated |
| xunit.runner.visualstudio | 3.0.2 |  | [EspnFantasyApiWrapper.UnitTest.csproj](#espnfantasyapiwrapperunittestespnfantasyapiwrapperunittestcsproj) | ✅Compatible |

## Top API Migration Challenges

### Technologies and Features

| Technology | Issues | Percentage | Migration Path |
| :--- | :---: | :---: | :--- |

### Most Frequent API Issues

| API | Count | Percentage | Category |
| :--- | :---: | :---: | :--- |

## Projects Relationship Graph

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart LR
    P1["<b>📦&nbsp;EspnFantasyApiWrapper.API.csproj</b><br/><small>net10.0</small>"]
    P2["<b>📦&nbsp;EspnFantasyApiWrapper.UnitTest.csproj</b><br/><small>net8.0</small>"]
    P3["<b>📦&nbsp;EspnFantasyApiWrapper.ConsoleClient.csproj</b><br/><small>net8.0</small>"]
    P2 --> P1
    P3 --> P1
    click P1 "#espnfantasyapiwrapperapiespnfantasyapiwrapperapicsproj"
    click P2 "#espnfantasyapiwrapperunittestespnfantasyapiwrapperunittestcsproj"
    click P3 "#espnfantasyapiwrapperconsoleclientespnfantasyapiwrapperconsoleclientcsproj"

```

## Project Details

<a id="espnfantasyapiwrapperapiespnfantasyapiwrapperapicsproj"></a>
### EspnFantasyApiWrapper.API\EspnFantasyApiWrapper.API.csproj

#### Project Info

- **Current Target Framework:** net10.0✅
- **SDK-style**: True
- **Project Kind:** ClassLibrary
- **Dependencies**: 0
- **Dependants**: 2
- **Number of Files**: 5
- **Lines of Code**: 867
- **Estimated LOC to modify**: 0+ (at least 0.0% of the project)

#### Dependency Graph

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart TB
    subgraph upstream["Dependants (2)"]
        P2["<b>📦&nbsp;EspnFantasyApiWrapper.UnitTest.csproj</b><br/><small>net8.0</small>"]
        P3["<b>📦&nbsp;EspnFantasyApiWrapper.ConsoleClient.csproj</b><br/><small>net8.0</small>"]
        click P2 "#espnfantasyapiwrapperunittestespnfantasyapiwrapperunittestcsproj"
        click P3 "#espnfantasyapiwrapperconsoleclientespnfantasyapiwrapperconsoleclientcsproj"
    end
    subgraph current["EspnFantasyApiWrapper.API.csproj"]
        MAIN["<b>📦&nbsp;EspnFantasyApiWrapper.API.csproj</b><br/><small>net10.0</small>"]
        click MAIN "#espnfantasyapiwrapperapiespnfantasyapiwrapperapicsproj"
    end
    P2 --> MAIN
    P3 --> MAIN

```

### API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 0 | High - Require code changes |
| 🟡 Source Incompatible | 0 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 0 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 0 |  |
| ***Total APIs Analyzed*** | ***0*** |  |

<a id="espnfantasyapiwrapperconsoleclientespnfantasyapiwrapperconsoleclientcsproj"></a>
### EspnFantasyApiWrapper.ConsoleClient\EspnFantasyApiWrapper.ConsoleClient.csproj

#### Project Info

- **Current Target Framework:** net8.0
- **Proposed Target Framework:** net10.0
- **SDK-style**: True
- **Project Kind:** DotNetCoreApp
- **Dependencies**: 1
- **Dependants**: 0
- **Number of Files**: 1
- **Number of Files with Incidents**: 1
- **Lines of Code**: 109
- **Estimated LOC to modify**: 0+ (at least 0.0% of the project)

#### Dependency Graph

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart TB
    subgraph current["EspnFantasyApiWrapper.ConsoleClient.csproj"]
        MAIN["<b>📦&nbsp;EspnFantasyApiWrapper.ConsoleClient.csproj</b><br/><small>net8.0</small>"]
        click MAIN "#espnfantasyapiwrapperconsoleclientespnfantasyapiwrapperconsoleclientcsproj"
    end
    subgraph downstream["Dependencies (1"]
        P1["<b>📦&nbsp;EspnFantasyApiWrapper.API.csproj</b><br/><small>net10.0</small>"]
        click P1 "#espnfantasyapiwrapperapiespnfantasyapiwrapperapicsproj"
    end
    MAIN --> P1

```

### API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 0 | High - Require code changes |
| 🟡 Source Incompatible | 0 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 0 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 144 |  |
| ***Total APIs Analyzed*** | ***144*** |  |

<a id="espnfantasyapiwrapperunittestespnfantasyapiwrapperunittestcsproj"></a>
### EspnFantasyApiWrapper.UnitTest\EspnFantasyApiWrapper.UnitTest.csproj

#### Project Info

- **Current Target Framework:** net8.0
- **Proposed Target Framework:** net10.0
- **SDK-style**: True
- **Project Kind:** DotNetCoreApp
- **Dependencies**: 1
- **Dependants**: 0
- **Number of Files**: 4
- **Number of Files with Incidents**: 1
- **Lines of Code**: 166
- **Estimated LOC to modify**: 0+ (at least 0.0% of the project)

#### Dependency Graph

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart TB
    subgraph current["EspnFantasyApiWrapper.UnitTest.csproj"]
        MAIN["<b>📦&nbsp;EspnFantasyApiWrapper.UnitTest.csproj</b><br/><small>net8.0</small>"]
        click MAIN "#espnfantasyapiwrapperunittestespnfantasyapiwrapperunittestcsproj"
    end
    subgraph downstream["Dependencies (1"]
        P1["<b>📦&nbsp;EspnFantasyApiWrapper.API.csproj</b><br/><small>net10.0</small>"]
        click P1 "#espnfantasyapiwrapperapiespnfantasyapiwrapperapicsproj"
    end
    MAIN --> P1

```

### API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 0 | High - Require code changes |
| 🟡 Source Incompatible | 0 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 0 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 229 |  |
| ***Total APIs Analyzed*** | ***229*** |  |

