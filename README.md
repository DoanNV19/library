# The .net + angular example project

project uses .net 7 as BE and angular as FE

## How to migration BE
- dotnet ef --startup-project ../LibApp.WebApi/ migrations add init
- dotnet ef --startup-project ../LibApp.WebApi/ database update
