FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Analyze.Host/Analyze.Host.csproj", "Analyze.Host/"]
RUN dotnet restore "Analyze.Host/Analyze.Host.csproj"
COPY . .
WORKDIR "/src/Analyze.Host"
RUN dotnet build "Analyze.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Analyze.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Analyze.Host.dll"]
