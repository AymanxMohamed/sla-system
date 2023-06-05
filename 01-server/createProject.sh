# Creating Folder Structure
mkdir SlaSystem

cd SlaSystem

# Adding Global Dontet Version
dotnet new globaljson --sdk-version 6.0.311
git add .
git commit -m "Create Global.Json File"

# Creating Solution
dotnet new sln

# Creating Projects
dotnet new classlib -o SlaSystem.Domain
dotnet new classlib -o SlaSystem.Application
dotnet new classlib -o SlaSystem.Infrastrucutre
dotnet new webapi -o SlaSystem.Presentation.Api


# Adding Projects to Soluiton
dotnet sln add ./*

git add .
git commit -m "Creating and Adding projects to solution"

# Adding Projects References

# Api Projects
dotnet add SlaSystem.Presentation.Api/ reference SlaSystem.Infrastrucutre SlaSystem.Application SlaSystem.Domain

# Infrastructure Projects
dotnet add SlaSystem.Infrastrucutre reference SlaSystem.Application SlaSystem.Domain

# Application Projects
dotnet add SlaSystem.Application reference SlaSystem.Domain

git add .
git commit -m "Adding Project References"

# Adding Nuget Packages
dotnet add SlaSystem.Infrastrucutre package Microsoft.Extensions.Options -v 6.0.0
dotnet add SlaSystem.Infrastrucutre package Microsoft.EntityFrameworkCore.Sqlite --version 6.0.16
dotnet add SlaSystem.Infrastrucutre package System.Data.SQLite  -v 1.0.117
dotnet add SlaSystem.Infrastrucutre package Microsoft.Extensions.Hosting -v 6.0.1
dotnet add SlaSystem.Application/ package MediatR.Extensions.Microsoft.DependencyInjection --version 11.1.0


# Restoring Packages 
dotnet restore SlaSystem.sln

git add .
git commit -m "Adding Nuget Packages"
