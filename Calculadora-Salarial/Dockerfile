FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src


COPY . .


RUN dotnet restore "Calculadora-Salarial.csproj"
RUN dotnet build "Calculadora-Salarial.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Calculadora-Salarial.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Calculadora-Salarial.dll"]