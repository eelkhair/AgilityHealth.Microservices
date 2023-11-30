#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Debug
WORKDIR /src
COPY ["AH.Microservices.Company/Src/Presentation/AH.Company.Api/Nuget.Config", "AH.Microservices.Company/Src/Presentation/AH.Company.Api/"]
COPY ["AH.Microservices.Company/Src/Presentation/AH.Company.Api/AH.Company.Api.csproj", "AH.Microservices.Company/Src/Presentation/AH.Company.Api/"]
COPY ["AH.Microservices.Metadata/Src/Shared/AH.Metadata.Shared.V1/AH.Metadata.Shared.V1.csproj", "AH.Microservices.Metadata/Src/Shared/AH.Metadata.Shared.V1/"]
COPY ["Shared/AH.Shared.API/AH.Shared.Api.csproj", "Shared/AH.Shared.API/"]
COPY ["Shared/AH.Shared.Infrastructure/AH.Shared.Infrastructure.csproj", "Shared/AH.Shared.Infrastructure/"]
COPY ["Shared/AH.Shared.Application/AH.Shared.Application.csproj", "Shared/AH.Shared.Application/"]
COPY ["Shared/AH.Shared.Domain/AH.Shared.Domain.csproj", "Shared/AH.Shared.Domain/"]
COPY ["Shared/AH.Shared.Persistence/AH.Shared.Persistence.csproj", "Shared/AH.Shared.Persistence/"]
COPY ["AH.Microservices.Company/Src/Infrastructure/AH.Company.Infrastructure/AH.Company.Infrastructure.csproj", "AH.Microservices.Company/Src/Infrastructure/AH.Company.Infrastructure/"]
COPY ["AH.Microservices.Company/Src/Core/AH.Company.Application/AH.Company.Application.csproj", "AH.Microservices.Company/Src/Core/AH.Company.Application/"]
COPY ["AH.Microservices.Company/Src/Core/AH.Company.Domain/AH.Company.Domain.csproj", "AH.Microservices.Company/Src/Core/AH.Company.Domain/"]
COPY ["AH.Microservices.Company/Src/Infrastructure/AH.Company.Persistence/AH.Company.Persistence.csproj", "AH.Microservices.Company/Src/Infrastructure/AH.Company.Persistence/"]
COPY ["AH.Microservices.Company/Src/Shared/AH.Company.Shared.V1/AH.Company.Shared.V1.csproj", "AH.Microservices.Company/Src/Shared/AH.Company.Shared.V1/"]
RUN dotnet restore "./AH.Microservices.Company/Src/Presentation/AH.Company.Api/./AH.Company.Api.csproj"
COPY . .
WORKDIR "/src/AH.Microservices.Company/Src/Presentation/AH.Company.Api"
RUN dotnet build "./AH.Company.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AH.Company.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AH.Company.Api.dll"]