FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
EXPOSE 80
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["HealthChecks/AH.Microservices.WebStatus/AH.Microservices.WebStatus.csproj", "HealthChecks/AH.Microservices.WebStatus/"]
RUN dotnet restore "HealthChecks/AH.Microservices.WebStatus/AH.Microservices.WebStatus.csproj"
COPY . .
WORKDIR "/src/HealthChecks/AH.Microservices.WebStatus"
RUN dotnet build "AH.Microservices.WebStatus.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "AH.Microservices.WebStatus.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AH.Microservices.WebStatus.dll"]
