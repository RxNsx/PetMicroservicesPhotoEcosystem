FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PhotoEcosystem.ImageService.API/PhotoEcosystem.ImageService.API.csproj", "PhotoEcosystem.ImageService.API/"]
RUN dotnet restore "PhotoEcosystem.ImageService.API/PhotoEcosystem.ImageService.API.csproj"
COPY . .
WORKDIR "/src/PhotoEcosystem.ImageService.API"
RUN dotnet build "PhotoEcosystem.ImageService.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "PhotoEcosystem.ImageService.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PhotoEcosystem.ImageService.API.dll"]
