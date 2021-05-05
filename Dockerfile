FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS build
WORKDIR /source

COPY *.sln .
COPY src/*.csproj ./src/
RUN dotnet restore

COPY src/. ./src/
WORKDIR /source/DeployRoverClient
RUN dotnet publish -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT [ "dotnet", "DeployRoverClient.dll" ]
