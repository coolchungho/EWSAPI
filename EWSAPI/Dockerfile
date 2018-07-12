FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY EWSAPI/EWSAPI.csproj EWSAPI/
RUN dotnet restore EWSAPI/EWSAPI.csproj
COPY . .
WORKDIR /src/EWSAPI
RUN dotnet build EWSAPI.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish EWSAPI.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EWSAPI.dll"]
