FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["Solution Items/Nuget.Config", "."]
COPY ["AH.Microservices.User/Src/Presentation/AH.User.Api/AH.User.Api.csproj", "AH.Microservices.User/Src/Presentation/AH.User.Api/"]
COPY ["AH.Microservices.User/Src/Infrastructure/AH.User.Infrastructure/AH.User.Infrastructure.csproj", "AH.Microservices.User/Src/Infrastructure/AH.User.Infrastructure/"]
COPY ["AH.Microservices.User/Src/Core/AH.User.Application/AH.User.Application.csproj", "AH.Microservices.User/Src/Core/AH.User.Application/"]
COPY ["AH.Microservices.User/Src/Core/AH.User.Domain/AH.User.Domain.csproj", "AH.Microservices.User/Src/Core/AH.User.Domain/"]
COPY ["AH.Microservices.User/Src/Infrastructure/AH.User.Persistence/AH.User.Persistence.csproj", "AH.Microservices.User/Src/Infrastructure/AH.User.Persistence/"]
COPY ["AH.Microservices.User/Src/Shared/AH.User.Shared.V1/AH.User.Shared.V1.csproj", "AH.Microservices.User/Src/Shared/AH.User.Shared.V1/"]
RUN dotnet restore "AH.Microservices.User/Src/Presentation/AH.User.Api/AH.User.Api.csproj" --configfile "Nuget.Config"
COPY . .
WORKDIR "/src/AH.Microservices.User/Src/Presentation/AH.User.Api"
RUN dotnet build "AH.User.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AH.User.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AH.User.Api.dll"]
