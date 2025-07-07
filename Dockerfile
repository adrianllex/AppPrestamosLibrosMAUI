# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ApiPrestamosLibros/ApiPrestamosLibros.csproj", "ApiPrestamosLibros/"]
RUN dotnet restore "ApiPrestamosLibros/ApiPrestamosLibros.csproj"
COPY . .
WORKDIR /src/ApiPrestamosLibros
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80
ENTRYPOINT ["dotnet", "ApiPrestamosLibros.dll"]
