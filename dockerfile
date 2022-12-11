FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src


COPY NullSoft/. .
RUN dotnet restore

# RUN dotnet build "NullSoft.csproj" -c Release -o /build

RUN dotnet publish -c Release -o /app --no-restore



#EXPOSE 4575 - 5945
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app

ENV NAME = PlaySoft

COPY --from=build /app ./

ENTRYPOINT [ "dotnet", "NullSoft.dll" ]
