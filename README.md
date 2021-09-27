# Overview

Kamacharov Finance core packages

[![publish](https://github.com/kamacharovs/kamafi-core/actions/workflows/publish.yml/badge.svg)](https://github.com/kamacharovs/kamafi-core/actions/workflows/publish.yml)

## Packages

List of available packages

- `kamafi.core.data`
- `kamafi.core.middleware`
- `kamafi.core.services`

## How it works

In order for your project to pull packages from this repository, then you need to add the source to your IDE, GitHub action, etc. before you have to build you project.

### Application settings

Application settings need to be set for each microservice. Below is an example of what those look like. These are all the required ones, except the `Logging` section, if using the `AddKamafiServices<TDbContext>` middleware. Otherwise each section corresponds to a different middleware. Of course, these are not required if passing the parameters at runtime and not using `IConfiguration`.

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "ApplicationInsights": {
    "InstrumentationKey": "appinsightsinstrumentationkey"
  },
  "Data": {
    "PostgreSQL": "Server=127.0.0.1;Port=5433;Database=aiof;User Id=aiof;Password=aiofiscool;"
  },
  "Cors": {
    "Portal": "http://localhost:4100"
  },
  "Jwt": {
    "Issuer": "aiof:auth",
    "Audience": "aiof:auth:audience",
    "PublicKey": "JWT PublicKey goes here"
  },
  "OpenApi": {
    "Title": "kamafi.liability",
    "Description": "Kamacharov Finance liability microservice",
    "Contact": {
      "Name": "Georgi Kamacharov",
      "Email": "gkamacharov@kamafi.com",
      "Url": "https://github.com/gkama"
    },
    "License": {
      "Name": "MIT",
      "Url": "https://github.com/kamacharovs/aiof-liability/blob/master/LICENSE"
    }
  }
}
```

### GitHub actions

In the `Kamacharovs` organization, there's a secret storing the Personal Access Token (PAT) to the packages source called `PACKAGE_TOKEN`. Thus, making the
command that needs to be added in the GitHub actions as follows

```pw
dotnet nuget add source --username USERNAME --password ${{ secrets.PACKAGE_TOKEN }} --store-password-in-clear-text --name github "https://nuget.pkg.github.com/kamacharovs/index.json"
```
