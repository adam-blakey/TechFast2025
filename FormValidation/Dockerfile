# Taken from https://codepruner.com/how-to-run-blazor-wasm-app-in-container/

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet publish -c Release -o /app

# Runtime stage
FROM nginx AS base
WORKDIR /usr/share/nginx/html
COPY --from=build /app/wwwroot .
EXPOSE 80
