dotnet publish -c Release
docker build -t amblakey/techfast2025:latest .
docker push amblakey/techfast2025:latest