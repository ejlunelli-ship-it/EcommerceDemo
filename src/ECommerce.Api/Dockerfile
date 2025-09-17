# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy project files
COPY ["src/ECommerce.Api/ECommerce.Api.csproj", "src/ECommerce.Api/"]
COPY ["src/Ecommerce.Application/Ecommerce.Application.csproj", "src/Ecommerce.Application/"]
COPY ["src/Ecommerce.Domain/Ecommerce.Domain.csproj", "src/Ecommerce.Domain/"]
COPY ["src/Ecommerce.Infaestructure/Ecommerce.Infaestructure.csproj", "src/Ecommerce.Infaestructure/"]

# Restore dependencies
RUN dotnet restore "src/ECommerce.Api/ECommerce.Api.csproj"

# Copy all source code
COPY . .
WORKDIR "/src/src/ECommerce.Api"

# Build the application
RUN dotnet build "ECommerce.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ECommerce.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ECommerce.Api.dll"]