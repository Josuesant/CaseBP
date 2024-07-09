FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CreditoCliente/CreditoCliente.csproj", "CreditoCliente/"]
RUN dotnet restore "CreditoCliente/CreditoCliente.csproj"
COPY . .
WORKDIR "/src/CreditoCliente"
RUN dotnet build "CreditoCliente.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CreditoCliente.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CreditoCliente.dll"]
