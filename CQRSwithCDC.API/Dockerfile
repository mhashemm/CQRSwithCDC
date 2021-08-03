#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CQRSwithCDC.API/CQRSwithCDC.API.csproj", "CQRSwithCDC.API/"]
COPY ["CQRSwithCDC.Logic/CQRSwithCDC.Logic.csproj", "CQRSwithCDC.Logic/"]
RUN dotnet restore "CQRSwithCDC.API/CQRSwithCDC.API.csproj"
COPY . .
WORKDIR "/src/CQRSwithCDC.API"
RUN dotnet build "CQRSwithCDC.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CQRSwithCDC.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CQRSwithCDC.API.dll"]