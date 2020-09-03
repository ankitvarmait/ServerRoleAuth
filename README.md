# ServerRoleAuth

[![NuGet package](https://img.shields.io/nuget/v/ServerRoleAuth.svg)](https://www.nuget.org/packages/ServerRoleAuth/) ![Build status](https://github.com/ankitvarmait/ServerRoleAuth/workflows/.NET%20Core%20Pack/badge.svg?branch=master)
[![GitHub release](https://img.shields.io/github/release/ankitvarmait/ServerRoleAuth.svg)](https://GitHub.com/ankitvarmait/ServerRoleAuth/releases)
[![GitHub tag](https://img.shields.io/github/tag/ankitvarmait/ServerRoleAuth.svg)](https://GitHub.com/ankitvarmait/ServerRoleAuth/tags/)
[![Open Source? Yes!](https://badgen.net/badge/Open%20Source%20%3F/Yes%21/blue?icon=github)](https://github.com/ankitvarmait/ServerRoleAuth)

Configure request based authorization at server side with simple JSON based configurations.

# Introduction 
* ServerRoleAuth is the open-source .NET assembly library to handle server based authorization.
  * Simple JSON based configuration. 
  * Check incoming request by 
     * User Role.
     * Incomeing Request Name.
     * Incoming Request -Sub Name (any additional condition if any). 
     * Customer type/ Group type (if any).
     
# Getting Started
## Build
* Project Path `src/MS.ServerRoleAuthorization/MS.ServerRoleAuthorization.sln.`
* Build. `dotnet build`

## Test
* Project path `src/MS.ServerRoleAuthorization/MS.ServerRoleAuthorization.sln.`
* Build. `dotnet build`
* Test project path`src/MS.ServerRoleAuthorization.FunctionalTests`
* Run test(s) ServerRoleTests. `dotnet test`

## How to use
* [How To configure Role based configurations](https://github.com/ankitvarmait/ServerRoleAuth/blob/master/Docs/ConfigureJson.md)
* [How start changes at Server Side](https://github.com/ankitvarmait/ServerRoleAuth/blob/master/Docs/ServerSideChanges.md)

# Contribute
Always welcome. Feel free to raise a request from GitHub.


![Twitter Follow](https://img.shields.io/twitter/follow/AnkitVarmait.svg?label=Follow%20@AnkitVarmait)
