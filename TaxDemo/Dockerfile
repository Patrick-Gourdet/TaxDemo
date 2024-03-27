#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80    
EXPOSE 443

FROM mcr.microsoft.com/dotnet/aspnet:8.0-bullseye-slim AS build 
WORKDIR /src
COPY ["TaxDemo/TaxDemo.csproj", "TaxDemo/"]
COPY ["TaxDemo/TaxDemo.xml", "TaxDemo/"]
COPY ["TaxDemo/ApiDbLite.db", "TaxDemo/"]
COPY ["TaxDemo/TaxDbLite.db", "TaxDemo/"]
COPY ["TaxDemo/CalcDbLite.db", "TaxDemo/"]
COPY ["TaxDemo/AuthDbLite.db", "TaxDemo/"]
COPY ["TaxDemo/README.md", "TaxDemo/"]
RUN dotnet restore "Auth/TaxDemo.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "TaxDemo/TaxDemo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TaxDemo/TaxDemo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaxDemo/TaxDemo.dll"]

