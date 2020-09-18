#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Auth/Auth.csproj", "Auth/"]
COPY ["Auth/Auth.xml", "Auth/"]
COPY ["Auth/ApiDbLite.db", "Auth/"]
COPY ["Auth/TaxDbLite.db", "Auth/"]
COPY ["Auth/CalcDbLite.db", "Auth/"]
COPY ["Auth/AuthDbLite.db", "Auth/"]
COPY ["Auth/README.md", "Auth/"]
RUN dotnet restore "Auth/Auth.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Auth/Auth.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Auth/Auth.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Auth/Auth.dll"]