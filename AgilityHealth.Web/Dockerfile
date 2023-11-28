FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["AgilityHealth.Web/AgilityHealth.Web.csproj", "AgilityHealth.Web/"]
RUN dotnet restore "AgilityHealth.Web/AgilityHealth.Web.csproj"
COPY . .
WORKDIR "/src/AgilityHealth.Web"
RUN dotnet build "AgilityHealth.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AgilityHealth.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AgilityHealth.Web.dll"]
