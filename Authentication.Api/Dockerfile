#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Authentication.Api/Authentication.Api.csproj", "Authentication.Api/"]
COPY ["Authentication.Infrastructure/Authentication.Infrastructure.csproj", "Authentication.Infrastructure/"]
COPY ["Authentication.Domain/Authentication.Domain.csproj", "Authentication.Domain/"]
COPY ["Authentication.UseCases/Authentication.UseCases.csproj", "Authentication.UseCases/"]
RUN dotnet restore "./Authentication.Api/./Authentication.Api.csproj"
COPY . .
WORKDIR "/src/Authentication.Api"
RUN dotnet build "./Authentication.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Authentication.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Authentication.Api.dll"]