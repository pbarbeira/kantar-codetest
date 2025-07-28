FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["KantarBooks.DataServer/KantarBooks.DataServer.csproj", "KantarBooks.DataServer/"]
RUN dotnet restore "KantarBooks.DataServer/KantarBooks.DataServer.csproj"
COPY . .
WORKDIR "/src/KantarBooks.DataServer"
RUN dotnet build "./KantarBooks.DataServer.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./KantarBooks.DataServer.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KantarBooks.DataServer.dll"]
