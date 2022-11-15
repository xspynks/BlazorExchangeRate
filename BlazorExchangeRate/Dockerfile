FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BlazorExchangeRate/BlazorExchangeRate.csproj", "BlazorExchangeRate/"]
RUN dotnet restore "BlazorExchangeRate/BlazorExchangeRate.csproj"
COPY . .
WORKDIR "/src/BlazorExchangeRate"
RUN dotnet build "BlazorExchangeRate.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlazorExchangeRate.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlazorExchangeRate.dll"]
