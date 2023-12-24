FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Solution Items/Nuget.Config", "."]
COPY ["FrontEnd/AH.Web/Server/AH.Web.Server.csproj", "FrontEnd/AH.Web/Server/"]
COPY ["FrontEnd/AH.Web/Client/AH.Web.Client.csproj", "FrontEnd/AH.Web/Client/"]
COPY ["FrontEnd/AH.Web/Shared/AH.Web.Shared.csproj", "FrontEnd/AH.Web/Shared/"]
RUN dotnet restore "FrontEnd/AH.Web/Server/AH.Web.Server.csproj" --configfile "Nuget.Config"
COPY . .
WORKDIR "/src/FrontEnd/AH.Web/Server"
RUN dotnet build "AH.Web.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "AH.Web.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AH.Web.Server.dll"]
