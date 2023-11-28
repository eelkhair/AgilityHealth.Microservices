#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AH.Microservices.Metadata/Src/Presentation/AH.Metadata.Api/Nuget.Config", "AH.Microservices.Metadata/Src/Presentation/AH.Metadata.Api/"]
COPY ["AH.Microservices.Metadata/Src/Presentation/AH.Metadata.Api/AH.Metadata.Api.csproj", "AH.Microservices.Metadata/Src/Presentation/AH.Metadata.Api/"]
COPY ["Shared/AH.Shared.API/AH.Shared.Api.csproj", "Shared/AH.Shared.API/"]
COPY ["Shared/AH.Shared.Infrastructure/AH.Shared.Infrastructure.csproj", "Shared/AH.Shared.Infrastructure/"]
COPY ["Shared/AH.Shared.Application/AH.Shared.Application.csproj", "Shared/AH.Shared.Application/"]
COPY ["Shared/AH.Shared.Domain/AH.Shared.Domain.csproj", "Shared/AH.Shared.Domain/"]
COPY ["Shared/AH.Shared.Persistence/AH.Shared.Persistence.csproj", "Shared/AH.Shared.Persistence/"]
COPY ["AH.Microservices.Metadata/Src/Infrastructure/AH.Metadata.Infrastructure/AH.Metadata.Infrastructure.csproj", "AH.Microservices.Metadata/Src/Infrastructure/AH.Metadata.Infrastructure/"]
COPY ["AH.Microservices.Metadata/Src/Core/AH.Metadata.Application/AH.Metadata.Application.csproj", "AH.Microservices.Metadata/Src/Core/AH.Metadata.Application/"]
COPY ["AH.Microservices.Metadata/Src/Core/AH.Metadata.Domain/AH.Metadata.Domain.csproj", "AH.Microservices.Metadata/Src/Core/AH.Metadata.Domain/"]
COPY ["AH.Microservices.Metadata/Src/Infrastructure/AH.Metadata.Persistence/AH.Metadata.Persistence.csproj", "AH.Microservices.Metadata/Src/Infrastructure/AH.Metadata.Persistence/"]
COPY ["AH.Microservices.Metadata/Src/Shared/AH.Metadata.Shared.V1/AH.Metadata.Shared.V1.csproj", "AH.Microservices.Metadata/Src/Shared/AH.Metadata.Shared.V1/"]
RUN dotnet restore "./AH.Microservices.Metadata/Src/Presentation/AH.Metadata.Api/./AH.Metadata.Api.csproj"
COPY . .
WORKDIR "/src/AH.Microservices.Metadata/Src/Presentation/AH.Metadata.Api"
RUN dotnet build "./AH.Metadata.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AH.Metadata.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AH.Metadata.Api.dll"]