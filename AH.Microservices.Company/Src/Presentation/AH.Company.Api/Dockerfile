FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Solution Items/Nuget.Config", "."]
COPY ["AH.Microservices.Company/Src/Presentation/AH.Company.Api/AH.Company.Api.csproj", "AH.Microservices.Company/Src/Presentation/AH.Company.Api/"]
COPY ["AH.Microservices.Company/Src/Infrastructure/AH.Company.Infrastructure/AH.Company.Infrastructure.csproj", "AH.Microservices.Company/Src/Infrastructure/AH.Company.Infrastructure/"]
COPY ["AH.Microservices.Company/Src/Core/AH.Company.Application/AH.Company.Application.csproj", "AH.Microservices.Company/Src/Core/AH.Company.Application/"]
COPY ["AH.Microservices.Company/Src/Core/AH.Company.Domain/AH.Company.Domain.csproj", "AH.Microservices.Company/Src/Core/AH.Company.Domain/"]
COPY ["AH.Microservices.Company/Src/Infrastructure/AH.Company.Persistence/AH.Company.Persistence.csproj", "AH.Microservices.Company/Src/Infrastructure/AH.Company.Persistence/"]
COPY ["AH.Microservices.Company/Src/Shared/AH.Company.Shared.V1/AH.Company.Shared.V1.csproj", "AH.Microservices.Company/Src/Shared/AH.Company.Shared.V1/"]
RUN dotnet restore "AH.Microservices.Company/Src/Presentation/AH.Company.Api/AH.Company.Api.csproj" --configfile "Nuget.Config"
COPY . .
WORKDIR "/src/AH.Microservices.Company/Src/Presentation/AH.Company.Api"
RUN dotnet build "AH.Company.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AH.Company.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AH.Company.Api.dll"]
