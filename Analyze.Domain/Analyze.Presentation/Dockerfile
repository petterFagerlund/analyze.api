FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Analyze.Presentation/Analyze.Presentation.csproj", "Analyze.Presentation/"]
RUN dotnet restore "Analyze.Presentation/Analyze.Presentation.csproj"
COPY . .
WORKDIR "/src/Analyze.Presentation"
RUN dotnet build "Analyze.Presentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Analyze.Presentation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Analyze.Presentation.dll"]
