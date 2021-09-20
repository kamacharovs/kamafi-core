# Overview

Kamacharov Finance core library

[![publish](https://github.com/kamacharovs/kamafi-core/actions/workflows/publish.yml/badge.svg)](https://github.com/kamacharovs/kamafi-core/actions/workflows/publish.yml)

## How it works

In order for your project to pull packages from this repository, then you need to add the source to your IDE, GitHub action, etc. before you have to build you project.

### GitHub actions

In the `Kamacharovs` organization, there's a secret storing the Personal Access Token (PAT) to the packages source called `PACKAGE_TOKEN`. Thus, making the
command that needs to be added in the GitHub actions as follows

```pw
dotnet nuget add source --username USERNAME --password ${{ secrets.PACKAGE_TOKEN }} --store-password-in-clear-text --name github "https://nuget.pkg.github.com/kamacharovs/index.json"
```
