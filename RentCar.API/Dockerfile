#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5245

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["RentCar.API/RentCar.API.csproj", "RentCar.API/"]
COPY ["RentCar.Application/RentCar.Application.csproj", "RentCar.Application/"]
COPY ["RentCar.Domain/RentCar.Domain.csproj", "RentCar.Domain/"]
COPY ["RentCar.Infrastructure/RentCar.Infrastructure.csproj", "RentCar.Infrastructure/"]
RUN dotnet restore "RentCar.API/RentCar.API.csproj"
COPY . .
WORKDIR "/src/RentCar.API"
RUN dotnet build "RentCar.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RentCar.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY ["RentCar.API/RentCarDB.db", "."]
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RentCar.API.dll"]