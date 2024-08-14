
#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/ProductCURD.HttpApi.Host/ProductCURD.HttpApi.Host.csproj", "src/ProductCURD.HttpApi.Host/"]
COPY ["src/ProductCURD.Application/ProductCURD.Application.csproj", "src/ProductCURD.Application/"]
COPY ["src/ProductCURD.Domain/ProductCURD.Domain.csproj", "src/ProductCURD.Domain/"]
COPY ["src/ProductCURD.Domain.Shared/ProductCURD.Domain.Shared.csproj", "src/ProductCURD.Domain.Shared/"]
COPY ["src/ProductCURD.Application.Contracts/ProductCURD.Application.Contracts.csproj", "src/ProductCURD.Application.Contracts/"]
COPY ["src/ProductCURD.HttpApi/ProductCURD.HttpApi.csproj", "src/ProductCURD.HttpApi/"]
COPY ["src/ProductCURD.EntityFrameworkCore/ProductCURD.EntityFrameworkCore.csproj", "src/ProductCURD.EntityFrameworkCore/"]
RUN dotnet restore "./src/ProductCURD.HttpApi.Host/ProductCURD.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/src/ProductCURD.HttpApi.Host"
RUN dotnet build "./ProductCURD.HttpApi.Host.csproj" -c %BUILD_CONFIGURATION% -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ProductCURD.HttpApi.Host.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductCURD.HttpApi.Host.dll"]