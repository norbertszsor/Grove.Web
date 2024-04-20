#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Grove.Web/Grove.Web.csproj", "Grove.Web/"]
COPY ["Grove.Handling/Grove.Handling.csproj", "Grove.Handling/"]
COPY ["Grove.Shared/Grove.Shared.csproj", "Grove.Shared/"]
COPY ["Grove.Transfer/Grove.Transfer.csproj", "Grove.Transfer/"]
COPY ["Grove.Infrastructure/Grove.Infrastructure.csproj", "Grove.Infrastructure/"]
COPY ["Grove.Data/Grove.Data.csproj", "Grove.Data/"]
COPY ["Grove.Logic/Grove.Logic.csproj", "Grove.Logic/"]
RUN dotnet restore "./Grove.Web/Grove.Web.csproj"
COPY . .
WORKDIR "/src/Grove.Web"
RUN dotnet build "./Grove.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Grove.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Grove.Web.dll"]