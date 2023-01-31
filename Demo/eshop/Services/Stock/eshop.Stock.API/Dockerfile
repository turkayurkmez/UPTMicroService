#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Stock/eshop.Stock.API/eshop.Stock.API.csproj", "Services/Stock/eshop.Stock.API/"]
COPY ["Common/eshop.MessageBus/eshop.MessageBus.csproj", "Common/eshop.MessageBus/"]
RUN dotnet restore "Services/Stock/eshop.Stock.API/eshop.Stock.API.csproj"
COPY . .
WORKDIR "/src/Services/Stock/eshop.Stock.API"
RUN dotnet build "eshop.Stock.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "eshop.Stock.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eshop.Stock.API.dll"]