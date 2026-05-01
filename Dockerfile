# syntax=docker/dockerfile:1.4
#
# Parameterized Dockerfile shared by every PractiZing .NET Core 2.1 API service.
# The compose file passes SERVICE_PROJECT (path to the .csproj) and SERVICE_DLL
# (the produced DLL name) per service. One Dockerfile, eight images.
#
# Build context MUST be the repository root so project references and lib/ DLLs
# resolve. See docker-compose.yaml.
#
# NOTE: .NET Core 2.1 is out of support since Aug 2021. The 2.1 base images
# still pull from MCR but receive no patches. Plan an upgrade to .NET 8 LTS.

ARG DOTNET_VERSION=2.1

# ---------- build stage ----------
FROM mcr.microsoft.com/dotnet/core/sdk:${DOTNET_VERSION} AS build
WORKDIR /src

# Required: relative path to the API csproj, e.g.
#   ChargePaymentService/PractiZing.Api.ChargePaymentService/PractiZing.Api.ChargePaymentService.csproj
ARG SERVICE_PROJECT
RUN test -n "$SERVICE_PROJECT" || (echo "SERVICE_PROJECT build-arg is required" && exit 1)

# Copy the whole repo. The .dockerignore strips bin/, obj/, .vs/, etc.
# We copy everything because each Api csproj references several sibling
# projects (Base, Common, BusinessLogic.*, DataAccess.*) and proprietary
# DLLs under lib/ and EDIFabric/Packages/.
COPY . .

# Restore + publish only the target service. Project references pull in
# their transitive deps automatically.
RUN dotnet restore "$SERVICE_PROJECT"
RUN dotnet publish "$SERVICE_PROJECT" \
    -c Release \
    -o /app/publish \
    --no-restore \
    /p:UseAppHost=false

# ---------- runtime stage ----------
FROM mcr.microsoft.com/dotnet/core/aspnet:${DOTNET_VERSION} AS runtime
WORKDIR /app

# Required: produced DLL filename, e.g. PractiZing.Api.ChargePaymentService.dll
ARG SERVICE_DLL
RUN test -n "$SERVICE_DLL" || (echo "SERVICE_DLL build-arg is required" && exit 1)
ENV SERVICE_DLL=${SERVICE_DLL}

# Run as non-root. The aspnet base image creates uid 1000 already.
# Pre-create /app/attachments because PatientService.Startup.cs:95 does
# `Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "attachments")`,
# resolving to /app/attachments, then opens a FileSystemWatcher on it.
# If the dir doesn't exist, startup throws and the container restart-loops.
# We also keep /attachments (the volume mount target used by HostService).
RUN groupadd -r app && useradd -r -g app -u 1001 app \
 && mkdir -p /app /app/attachments /attachments \
 && chown -R app:app /app /app/attachments /attachments

COPY --from=build --chown=app:app /app/publish /app

USER app

# Each Api's Program.cs calls `.UseUrls(new UrlConfiguration().GetAppUrl())`,
# which reads `ApplicationUrl` from config. With ASPNETCORE_ENVIRONMENT=
# Production and no appsettings.Production.json, that key is missing and
# the helper returns empty string -> Kestrel falls back to localhost:5000
# (which is unreachable from outside the container's network namespace).
# Set ApplicationUrl explicitly so .UseUrls binds to all interfaces on 8080.
# ASPNETCORE_URLS is set as a safety net for any service that doesn't go
# through UrlConfiguration.
ENV ApplicationUrl=http://+:8080 \
    ASPNETCORE_URLS=http://+:8080 \
    ASPNETCORE_ENVIRONMENT=Production \
    DOTNET_RUNNING_IN_CONTAINER=true \
    DOTNET_USE_POLLING_FILE_WATCHER=false \
    AttachmentFolder=/attachments

EXPOSE 8080

# SERVICE_DLL is captured at build time but we use a shell form so it's
# resolved at container start; this lets one image always know which DLL to run.
ENTRYPOINT exec dotnet "$SERVICE_DLL"
