FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Solution Items/Nuget.Config", "."]
COPY ["AH.Microservices.Team/Src/Presentation/AH.Team.Api/AH.Team.Api.csproj", "AH.Microservices.Team/Src/Presentation/AH.Team.Api/"]
COPY ["AH.Microservices.Team/Src/Infrastructure/AH.Team.Infrastructure/AH.Team.Infrastructure.csproj", "AH.Microservices.Team/Src/Infrastructure/AH.Team.Infrastructure/"]
COPY ["AH.Microservices.Team/Src/Core/AH.Team.Application/AH.Team.Application.csproj", "AH.Microservices.Team/Src/Core/AH.Team.Application/"]
COPY ["AH.Microservices.Team/Src/Core/AH.Team.Domain/AH.Team.Domain.csproj", "AH.Microservices.Team/Src/Core/AH.Team.Domain/"]
COPY ["AH.Microservices.Team/Src/Infrastructure/AH.Team.Persistence/AH.Team.Persistence.csproj", "AH.Microservices.Team/Src/Infrastructure/AH.Team.Persistence/"]
COPY ["AH.Microservices.Team/Src/Shared/AH.Team.Shared.V1/AH.Team.Shared.V1.csproj", "AH.Microservices.Team/Src/Shared/AH.Team.Shared.V1/"]
RUN dotnet restore "AH.Microservices.Team/Src/Presentation/AH.Team.Api/AH.Team.Api.csproj" --configfile "Nuget.Config"
COPY . .
WORKDIR "/src/AH.Microservices.Team/Src/Presentation/AH.Team.Api"
RUN dotnet build "AH.Team.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AH.Team.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AH.Team.Api.dll"]
