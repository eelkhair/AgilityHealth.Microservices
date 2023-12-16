#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release

WORKDIR /src
COPY ["Solution Items/Nuget.Config", "."]
COPY ["FrontEnd/AH.Web/AH.Web.csproj", "FrontEnd/AH.Web/"]
RUN dotnet restore "./FrontEnd/AH.Web/./AH.Web.csproj" --configfile "Nuget.Config"
COPY . .
WORKDIR "/src/FrontEnd/AH.Web"
RUN dotnet build "./AH.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AH.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false


FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY ./FrontEnd/AH.Web/nginx.conf /etc/nginx/nginx.conf
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AH.Web.dll"]