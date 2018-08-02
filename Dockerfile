
FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY WebApiCoreExemplo/WebApiCoreExemplo.csproj WebApiCoreExemplo/
RUN dotnet restore WebApiCoreExemplo/WebApiCoreExemplo.csproj
WORKDIR /src/WebApiCoreExemplo
COPY WebApiCoreExemplo/ .
RUN dotnet build WebApiCoreExemplo.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish WebApiCoreExemplo.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebApiCoreExemplo.dll"]
