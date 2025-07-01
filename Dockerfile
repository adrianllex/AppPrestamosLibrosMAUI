# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia todo el contenido del repo
COPY . .

# Restaura dependencias desde la carpeta de proyecto
WORKDIR /src/ApiPrestamosLibros
RUN dotnet restore

# Publica
RUN dotnet publish -c Release -o /app/out

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

ENTRYPOINT ["dotnet", "ApiPrestamosLibros.dll"]