FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/TicketProject.Presentation/TicketProject.Presentation.csproj", "src/TicketProject.Presentation/"]
RUN dotnet restore "src/TicketProject.Presentation/TicketProject.Presentation.csproj"
COPY . .
WORKDIR "/src/src/TicketProject.Presentation"
RUN dotnet build "TicketProject.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TicketProject.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TicketProject.Presentation.dll"]
