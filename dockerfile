
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src


COPY NullSoft/. .
RUN dotnet restore

# RUN dotnet build "NullSoft.csproj" -c Release -o /build

RUN dotnet publish -c Release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "NullSoft.dll"]  