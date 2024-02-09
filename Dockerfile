#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Nityo/Nityo.csproj", "Nityo/"]
RUN dotnet restore "Nityo/Nityo.csproj"
COPY . .
WORKDIR "/src/Nityo"
RUN dotnet build "Nityo.csproj" -c Release -o /app/build

# Run NUnit tests
RUN dotnet test "Nityo.csproj" --no-restore --configuration Release --logger "trx;LogFileName=test-results.trx" --results-directory /app/TestResults
