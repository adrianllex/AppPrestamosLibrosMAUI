# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar solo el archivo .csproj y restaurar dependencias
COPY ApiPrestamosLibros/ApiPrestamosLibros.csproj ./ApiPrestamosLibros/
WORKDIR /app/ApiPrestamosLibros
RUN dotnet restore

# Copiar el resto del código
WORKDIR /app
COPY . .

# Publicar la aplicación
WORKDIR /app/ApiPrestamosLibros
RUN dotnet publish -c Release -o /out

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out .

# Configurar la URL base
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

# Comando de inicio
ENTRYPOINT ["dotnet", "ApiPrestamosLibros.dll"]
