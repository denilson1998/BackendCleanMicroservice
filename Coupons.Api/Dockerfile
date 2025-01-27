#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Coupons.Api/Coupons.Api.csproj", "Coupons.Api/"]
COPY ["Coupons.Infrastructure/Coupons.Infrastructure.csproj", "Coupons.Infrastructure/"]
COPY ["Coupons.UseCases/Coupons.UseCases.csproj", "Coupons.UseCases/"]
COPY ["Coupons.Domain/Coupons.Domain.csproj", "Coupons.Domain/"]
RUN dotnet restore "./Coupons.Api/./Coupons.Api.csproj"
COPY . .
WORKDIR "/src/Coupons.Api"
RUN dotnet build "./Coupons.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Coupons.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Coupons.Api.dll"]