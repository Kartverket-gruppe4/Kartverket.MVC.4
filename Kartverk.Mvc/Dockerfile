# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release

WORKDIR /src

# Copy the solution file if it exists
COPY ["Kartverk.Mvc/Kartverk.sln", "./"]

# Set the working directory and copy the specific project file to restore dependencies
COPY ["Kartverk.Mvc/Kartverk.Mvc.csproj", "Kartverk.Mvc/"]

# Explicitly restore the project file
# RUN dotnet restore --project "Kartverk.Mvc/Kartverk.Mvc.csproj"

# Run restore using the solution file to restore all projects in one go
RUN dotnet restore "Kartverk.sln"

# Copy the rest of the source code
COPY . .

# Change to the project directory and build the project
WORKDIR "/src/Kartverk.Mvc"
RUN dotnet build --project "Kartverk.Mvc.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release

# Explicitly publish the project file
RUN dotnet publish --project "Kartverk.Mvc.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app

# Copy the published output from the publish stage to the final image
COPY --from=publish /app/publish .

# Define the entry point for the application
ENTRYPOINT ["dotnet", "Kartverk.Mvc.dll"]