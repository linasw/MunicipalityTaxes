FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TaxesMunicipality.Api/TaxesMunicipality.Api.csproj", "TaxesMunicipality.Api/"]
COPY ["TaxesMunicipality.Core/TaxesMunicipality.Core.csproj", "TaxesMunicipality.Core/"]
COPY ["TaxesMunicipality.Data/TaxesMunicipality.Data.csproj", "TaxesMunicipality.Data/"]
RUN dotnet restore "TaxesMunicipality.Api/TaxesMunicipality.Api.csproj"
COPY ..
WORKDIR "/src/TaxesMunicipality.Api"
RUN dotnet build "TaxesMunicipality.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TaxesMunicipality.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish 

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet" , "TaxesMunicipality.Api.dll"]