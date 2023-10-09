
#Build Stage
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./dotnet-api/dotnet-api.csproj" --disable-parallel
RUN dotnet publish "./dotnet-api/dotnet-api.csproj" -c release -o /app --no-restore

#Serve Stage as BASE
FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal as BASE
WORKDIR /app 
COPY --from=build /app ./
EXPOSE 5000
ENTRYPOINT ["dotnet", "dotnet-api.dll"]

#Migrations
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS migration
WORKDIR /source
COPY . .
RUN dotnet restore "./dotnet-api/dotnet-api.csproj"
COPY . .
WORKDIR "/source/dotnet-api.Migration"
RUN dotnet build "dotnet-api.Migration.csproj" -c Release -o /app/migration

FROM base AS final
WORKDIR /migration
COPY --from=migration /app/migration .