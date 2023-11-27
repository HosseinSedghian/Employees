# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./Employees/Employees.csproj" --disable-parallel
RUN dotnet publish "./Employees/Employees.csproj" -c release -o /app --no-restore
# Server Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app ./

Expose 5000

ENTRYPOINT ["dotnet", "Employees.dll"]
