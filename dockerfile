FROM mcr.microsoft.com/dotnet/sdk:6.0

ENV AppName=PlaySoft

WORKDIR /NullSoft

COPY . .

RUN dotnet restore

RUN dotnet publish -c Release -o out

EXPOSE 80

ENTRYPOINT ["dotnet", "out/NullSoft.dll"]  