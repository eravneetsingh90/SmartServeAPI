# ---------- Runtime Base ----------
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app

EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080


# ---------- Build Stage ----------
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy csproj files first for caching
COPY ["SmartServe.API/SmartServe.API.csproj", "SmartServe.API/"]
COPY ["SmartServe.Common/SmartServe.Common.csproj", "SmartServe.Common/"]
COPY ["SmartServe.Domain/SmartServe.Domain.csproj", "SmartServe.Domain/"]
COPY ["SmartServe.EFCore/SmartServe.EFCore.csproj", "SmartServe.EFCore/"]
COPY ["SmartServe.Resources/SmartServe.Resources.csproj", "SmartServe.Resources/"]

RUN dotnet restore "SmartServe.API/SmartServe.API.csproj"

# Copy full source
COPY . .

WORKDIR "/src/SmartServe.API"

RUN dotnet build "SmartServe.API.csproj" -c Release -o /app/build


# ---------- Publish Stage ----------
FROM build AS publish

RUN dotnet publish "SmartServe.API.csproj" \
    -c Release \
    -o /app/publish \
    /p:UseAppHost=false


# ---------- Final Runtime ----------
FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "SmartServe.API.dll"]