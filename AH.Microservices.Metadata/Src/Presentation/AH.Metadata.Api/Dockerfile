FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Solution Items/Nuget.Config", "."]
COPY ["AH.Microservices.Metadata/Src/Presentation/AH.Metadata.Api/AH.Metadata.Api.csproj", "AH.Microservices.Metadata/Src/Presentation/AH.Metadata.Api/"]
COPY ["AH.Microservices.Metadata/Src/Infrastructure/AH.Metadata.Infrastructure/AH.Metadata.Infrastructure.csproj", "AH.Microservices.Metadata/Src/Infrastructure/AH.Metadata.Infrastructure/"]
COPY ["AH.Microservices.Metadata/Src/Core/AH.Metadata.Application/AH.Metadata.Application.csproj", "AH.Microservices.Metadata/Src/Core/AH.Metadata.Application/"]
COPY ["AH.Microservices.Metadata/Src/Core/AH.Metadata.Domain/AH.Metadata.Domain.csproj", "AH.Microservices.Metadata/Src/Core/AH.Metadata.Domain/"]
COPY ["AH.Microservices.Metadata/Src/Infrastructure/AH.Metadata.Persistence/AH.Metadata.Persistence.csproj", "AH.Microservices.Metadata/Src/Infrastructure/AH.Metadata.Persistence/"]
COPY ["AH.Microservices.Metadata/Src/Shared/AH.Metadata.Shared.V1/AH.Metadata.Shared.V1.csproj", "AH.Microservices.Metadata/Src/Shared/AH.Metadata.Shared.V1/"]
RUN dotnet restore "AH.Microservices.Metadata/Src/Presentation/AH.Metadata.Api/AH.Metadata.Api.csproj"  --configfile "Nuget.Config"
COPY . .
WORKDIR "/src/AH.Microservices.Metadata/Src/Presentation/AH.Metadata.Api"
RUN dotnet build "AH.Metadata.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AH.Metadata.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AH.Metadata.Api.dll"]
