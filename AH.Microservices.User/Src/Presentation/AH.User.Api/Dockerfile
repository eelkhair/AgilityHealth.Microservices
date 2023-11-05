FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["AH.Microservices.Company/Src/Presentation/AH.Company.Api/Nuget.Config", "."]
COPY ["AH.Microservices.User/Src/Presentation/AH.Users.Api/AH.Users.Api.csproj", "AH.Microservices.User/Src/Presentation/AH.Users.Api/"]
RUN dotnet restore "AH.Microservices.User/Src/Presentation/AH.Users.Api/AH.Users.Api.csproj"
COPY . .
WORKDIR "/src/AH.Microservices.User/Src/Presentation/AH.Users.Api"
RUN dotnet build "AH.Users.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AH.Users.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AH.Users.Api.dll"]
