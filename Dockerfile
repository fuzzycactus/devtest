#FROM microsoft/aspnetcore-build:2.1 AS build-env
FROM mcr.microsoft.com/dotnet/core/sdk:2.1 AS build-env
COPY src /app
WORKDIR /app

#RUN dotnet restore --configfile ../NuGet.Config
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Build runtime image
#FROM microsoft/aspnetcore:2.1
FROM mcr.microsoft.com/dotnet/core/aspnet:2.1 AS runtime
WORKDIR /app
COPY --from=build-env /app/dsnybff/out .
ENV ASPNETCORE_URLS http://*:5000
ENV DEBUG false
ENTRYPOINT ["dotnet", "dsnybff.dll"]