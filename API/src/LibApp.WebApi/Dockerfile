#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["API/src/LibApp.WebApi/LibApp.WebApi.csproj", "src/LibApp.WebApi/"]
COPY ["API/src/LibApp.Domain/LibApp.Domain.csproj", "src/LibApp.Domain/"]
COPY ["API/src/LibApp.Application/LibApp.Application.csproj", "src/LibApp.Application/"]
COPY ["API/src/LibApp.Infrastructure/LibApp.Infrastructure.csproj", "src/LibApp.Infrastructure/"]
RUN dotnet restore "src/LibApp.WebApi/LibApp.WebApi.csproj"
COPY API/ .
WORKDIR "/src/src/LibApp.WebApi"
RUN dotnet build "LibApp.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LibApp.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LibApp.WebApi.dll"]
