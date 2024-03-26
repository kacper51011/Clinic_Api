#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Clinic_Api/Clinic_Api.csproj", "Clinic_Api/"]
COPY ["Clinic_Api.Application/Clinic_Api.Application.csproj", "Clinic_Api.Application/"]
COPY ["Clinic_Api.Domain/Clinic_Api.Domain.csproj", "Clinic_Api.Domain/"]
RUN dotnet restore "./Clinic_Api/./Clinic_Api.csproj"
COPY . .
WORKDIR "/src/Clinic_Api"
RUN dotnet build "./Clinic_Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Clinic_Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Clinic_Api.dll"]