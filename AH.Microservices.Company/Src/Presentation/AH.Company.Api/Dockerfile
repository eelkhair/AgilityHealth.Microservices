#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["AH.Microservices.Company/Src/Presentation/AH.Company.Api/Nuget.Config", "."]
COPY ["AH.Microservices.Company/Src/Presentation/AH.Company.Api/AH.Company.Api.csproj", "AH.Microservices.Company/Src/Presentation/AH.Company.Api/"]
RUN dotnet restore "AH.Microservices.Company/Src/Presentation/AH.Company.Api/AH.Company.Api.csproj" --configfile Nuget.Config
COPY . .
WORKDIR "/src/AH.Microservices.Company/Src/Presentation/AH.Company.Api"
RUN dotnet build "AH.Company.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AH.Company.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AH.Company.Api.dll"]