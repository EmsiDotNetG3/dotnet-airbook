FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EMSI.Airbook.WebAPI/EMSI.Airbook.WebAPI.csproj", "EMSI.Airbook.WebAPI/"]
RUN dotnet restore "EMSI.Airbook.WebAPI/EMSI.Airbook.WebAPI.csproj"
COPY . .
WORKDIR "/src/EMSI.Airbook.WebAPI"
RUN dotnet build "./EMSI.Airbook.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EMSI.Airbook.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EMSI.Airbook.WebAPI.dll"]
