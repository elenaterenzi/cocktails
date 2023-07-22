FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

# Copy csproj and restore as distinct layers
COPY . /app
WORKDIR /app
RUN dotnet restore

# Copy everything else and build
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "cocktails.dll"]