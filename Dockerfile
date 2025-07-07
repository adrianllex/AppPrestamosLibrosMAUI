# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar el archivo .csproj y restaurar dependencias
COPY ["ApiPrestamosLibros/ApiPrestamosLibros.csproj", "ApiPrestamosLibros/"]
RUN dotnet restore "ApiPrestamosLibros/ApiPrestamosLibros.csproj"

# Copiar el resto del código
COPY . .

# Publicar la API en modo Release
WORKDIR /src/ApiPrestamosLibros
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Configurar la URL base para ASP.NET Core
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

# Ejecutar la aplicación
ENTRYPOINT ["dotnet", "ApiPrestamosLibros.dll"]
