# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app


# copy everything else and build appdotnet 
COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c release -o out 

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "CertificateService.dll"]