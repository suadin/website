#suadin.de

## Template

* Blazor Server-App
  * Authenticationtype: single nodes
  * HTTPS configured
  * Docker for Linux

## Prerequisites

* .NET 5: `choco install dotnet-5.0-sdk`
* Docker: `choco install docker-desktop` and `choco install docker-cli`
* IDE: for example `choco install visualstudio2019community`
* GIT Client: for example `choco install gitkraken`
* PostgreSQL Database: `choco install postgresql13` and/or `choco install postgresql`
  * update `C:\Program Files\PostgreSQL\{VERSION}\data\pg_hba.conf` with `host all all 0.0.0.0/0 md5`
  * create on local database user & database `suadin`, grant user suadin to database suadin
* PostgreSQL Client: for example `choco install pgadmin4`
* Dev-Certificate: `dotnet dev-certs https --trust`
* Entity Framework Core Tools: `dotnet tool install --global dotnet-ef`
* Secrets: `PostgreSql:DbPassword`, `Authentication:Google:ClientSecret`

## Getting Started
* start docker
* start postgresql
* update database `cd Suadin`, `dotnet ef database update`
* run app within docker

## Deployment
* grant repo `suadin/website` to github-package `website` to release image to github
* add into repo `suadin/website` secrets `DOCKER_HUB_USER` and `DOCKER_HUB_PASSWORD` to release image to dockerhub
* add into repo `suadin/website` secret `SERVER_PASSWORD` to deploy released image to server

## Sources
* Prerequisites
  * [How to configure PostgreSQL to accept all incoming connections](https://stackoverflow.com/questions/3278379/how-to-configure-postgresql-to-accept-all-incoming-connections)
  * [Configure localhost development dev certificate](https://docs.servicestack.net/netcore-localhost-cert)
  * [Entity Framework Core tools reference - .NET Core CLI](https://docs.microsoft.com/en-us/ef/core/cli/dotnet)
  * [PostgreSQL - Create User, Create Database, Grant privileges/access](https://medium.com/@mohammedhammoud/postgresql-create-user-create-database-grant-privileges-access-aabb2507c0aa)
  * [Safe storage of app secrets in development in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-6.0&tabs=windows)
* Development
  * [How to Configure PostgreSQL in Entity Framework Core](https://code-maze.com/configure-postgresql-ef-core/)
  * [Publishing Docker images](https://docs.github.com/en/actions/publishing-packages/publishing-docker-images)
  * [EntityFramework Core automatic migrations](https://stackoverflow.com/questions/39526595/entityframework-core-automatic-migrations)
  * [Google Authentication in Blazor WebAssembly Hosted Applications](https://code-maze.com/google-authentication-in-blazor-webassembly-hosted-applications/)
  * [Get Current User in a Blazor component](https://stackoverflow.com/questions/60264657/get-current-user-in-a-blazor-component)
* Open
  * [Account confirmation and password recovery in ASP.NET Core](https://docs.microsoft.com/de-de/aspnet/core/security/authentication/accconfirm?view=aspnetcore-6.0&tabs=visual-studio)