
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app


COPY NullSoft/. .
RUN dotnet restore

# RUN dotnet build "NullSoft.csproj" -c Release -o /build

RUN dotnet publish -c Release -o /app2 --no-restore

ENV APP_NAME = PlaySoft

#EXPOSE 4575
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app ./
#zENTRYPOINT ["dotnet", "NullSoft.dll"]  