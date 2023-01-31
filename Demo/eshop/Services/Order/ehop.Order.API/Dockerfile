#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Order/ehop.Order.API/ehop.Order.API.csproj", "Services/Order/ehop.Order.API/"]
COPY ["Common/eshop.MessageBus/eshop.MessageBus.csproj", "Common/eshop.MessageBus/"]
RUN dotnet restore "Services/Order/ehop.Order.API/ehop.Order.API.csproj"
COPY . .
WORKDIR "/src/Services/Order/ehop.Order.API"
RUN dotnet build "ehop.Order.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ehop.Order.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ehop.Order.API.dll"]