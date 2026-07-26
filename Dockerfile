# Stage 1: Build application
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["CINESMART.csproj", "./"]
RUN dotnet restore "CINESMART.csproj"
COPY . .
RUN dotnet publish "CINESMART.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 2: Run application
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "CINESMART.dll"]
