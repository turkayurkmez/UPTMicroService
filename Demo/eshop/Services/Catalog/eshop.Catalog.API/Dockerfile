#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Catalog/eshop.Catalog.API/eshop.Catalog.API.csproj", "Services/Catalog/eshop.Catalog.API/"]
COPY ["Common/eshop.MessageBus/eshop.MessageBus.csproj", "Common/eshop.MessageBus/"]
COPY ["Services/Catalog/eshop.Catalog.Application/eshop.Catalog.Application.csproj", "Services/Catalog/eshop.Catalog.Application/"]
COPY ["Services/Catalog/eshop.Catalog.DataAccess/eshop.Catalog.DataAccess.csproj", "Services/Catalog/eshop.Catalog.DataAccess/"]
COPY ["Services/Catalog/eshop.Catalog.Entities/eshop.Catalog.Entities.csproj", "Services/Catalog/eshop.Catalog.Entities/"]
RUN dotnet restore "Services/Catalog/eshop.Catalog.API/eshop.Catalog.API.csproj"
COPY . .
WORKDIR "/src/Services/Catalog/eshop.Catalog.API"
RUN dotnet build "eshop.Catalog.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "eshop.Catalog.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eshop.Catalog.API.dll"]