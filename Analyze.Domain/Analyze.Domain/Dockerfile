FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Analyze.Domain/Analyze.Domain.csproj", "Analyze.Domain/"]
RUN dotnet restore "Analyze.Domain/Analyze.Domain.csproj"
COPY . .
WORKDIR "/src/Analyze.Domain"
RUN dotnet build "Analyze.Domain.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Analyze.Domain.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Analyze.Domain.dll"]
