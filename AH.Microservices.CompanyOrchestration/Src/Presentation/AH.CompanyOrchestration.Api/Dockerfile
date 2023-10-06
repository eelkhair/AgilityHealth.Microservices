FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["AH.Microservices.CompanyOrchestration/Src/Presentation/AH.CompanyOrchestration.Api/AH.CompanyOrchestration.Api.csproj", "AH.Microservices.CompanyOrchestration/Src/Presentation/AH.CompanyOrchestration.Api/"]
RUN dotnet restore "AH.Microservices.CompanyOrchestration/Src/Presentation/AH.CompanyOrchestration.Api/AH.CompanyOrchestration.Api.csproj"
COPY . .
WORKDIR "/src/AH.Microservices.CompanyOrchestration/Src/Presentation/AH.CompanyOrchestration.Api"
RUN dotnet build "AH.CompanyOrchestration.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AH.CompanyOrchestration.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AH.CompanyOrchestration.Api.dll"]
