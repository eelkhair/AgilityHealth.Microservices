#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Debug
WORKDIR /src
COPY ["AH.Microservices.User/Src/Presentation/AH.User.Api/Nuget.Config", "AH.Microservices.User/Src/Presentation/AH.User.Api/"]
COPY ["AH.Microservices.User/Src/Presentation/AH.User.Api/AH.User.Api.csproj", "AH.Microservices.User/Src/Presentation/AH.User.Api/"]
COPY ["Shared/AH.Shared.API/AH.Shared.Api.csproj", "Shared/AH.Shared.API/"]
COPY ["Shared/AH.Shared.Infrastructure/AH.Shared.Infrastructure.csproj", "Shared/AH.Shared.Infrastructure/"]
COPY ["Shared/AH.Shared.Application/AH.Shared.Application.csproj", "Shared/AH.Shared.Application/"]
COPY ["Shared/AH.Shared.Domain/AH.Shared.Domain.csproj", "Shared/AH.Shared.Domain/"]
COPY ["Shared/AH.Shared.Persistence/AH.Shared.Persistence.csproj", "Shared/AH.Shared.Persistence/"]
COPY ["AH.Microservices.User/Src/Infrastructure/AH.User.Infrastructure/AH.User.Infrastructure.csproj", "AH.Microservices.User/Src/Infrastructure/AH.User.Infrastructure/"]
COPY ["AH.Microservices.User/Src/Core/AH.User.Application/AH.User.Application.csproj", "AH.Microservices.User/Src/Core/AH.User.Application/"]
COPY ["AH.Microservices.User/Src/Core/AH.User.Domain/AH.User.Domain.csproj", "AH.Microservices.User/Src/Core/AH.User.Domain/"]
COPY ["AH.Microservices.User/Src/Infrastructure/AH.User.Persistence/AH.User.Persistence.csproj", "AH.Microservices.User/Src/Infrastructure/AH.User.Persistence/"]
COPY ["AH.Microservices.User/Src/Shared/AH.User.Shared.V1/AH.User.Shared.V1.csproj", "AH.Microservices.User/Src/Shared/AH.User.Shared.V1/"]
RUN dotnet restore "./AH.Microservices.User/Src/Presentation/AH.User.Api/./AH.User.Api.csproj"
COPY . .
WORKDIR "/src/AH.Microservices.User/Src/Presentation/AH.User.Api"
RUN dotnet build "./AH.User.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AH.User.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AH.User.Api.dll"]