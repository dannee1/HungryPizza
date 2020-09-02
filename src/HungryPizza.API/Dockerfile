#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/HungryPizza.API/HungryPizza.Api.csproj", "src/HungryPizza.API/"]
COPY ["src/HungryPizza.Domain/HungryPizza.Domain.csproj", "src/HungryPizza.Domain/"]
COPY ["src/HungryPizza.Domain.Infra/HungryPizza.Domain.Infra.csproj", "src/HungryPizza.Domain.Infra/"]
RUN dotnet restore "src/HungryPizza.API/HungryPizza.Api.csproj"
COPY . .
WORKDIR "/src/src/HungryPizza.API"
RUN dotnet build "HungryPizza.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HungryPizza.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HungryPizza.Api.dll"]
