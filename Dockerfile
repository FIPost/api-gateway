#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Default

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 8123

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build

WORKDIR /src
COPY ["api-gateway.csproj", ""]
RUN dotnet restore "./api-gateway.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "api-gateway.csproj" -c Release -o /app/build

FROM build AS publish
ARG BUILD_ENV="k8s"

RUN dotnet publish "api-gateway.csproj" -c Release -o /app/publish

FROM base AS final
ARG BUILD_ENV="Production"
ENV ASPNETCORE_ENVIRONMENT "${BUILD_ENV}"
ENV ENVIRONMENT "${BUILD_ENV}"

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "api-gateway.dll"]