#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CQRSwithCDC.Read/CQRSwithCDC.Read.csproj", "CQRSwithCDC.Read/"]
RUN dotnet restore "CQRSwithCDC.Read/CQRSwithCDC.Read.csproj"
COPY . .
WORKDIR "/src/CQRSwithCDC.Read"
RUN dotnet build "CQRSwithCDC.Read.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CQRSwithCDC.Read.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CQRSwithCDC.Read.dll"]