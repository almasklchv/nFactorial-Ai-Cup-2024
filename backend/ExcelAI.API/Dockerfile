FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
EXPOSE 443

WORKDIR /src

RUN mkdir /CacheStorage

COPY ["ExcelAI.API/ExcelAI.API.csproj", "ExcelAI.API/"]
RUN dotnet restore "ExcelAI.API/ExcelAI.API.csproj"

COPY . .
WORKDIR "/src/ExcelAI.API"
RUN dotnet build "ExcelAI.API.csproj" -c Release -o /app/build

RUN dotnet publish "ExcelAI.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

RUN dotnet tool install --global dotnet-ef --version 7.0.0

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime

WORKDIR /app

COPY --from=build /app/publish .
COPY ./ExcelAI.API/template.xlsx /app/template.xlsx
COPY ./ExcelAI.API/certs /app/certs

ENV PATH="$PATH:/root/.dotnet/tools"

ENTRYPOINT ["dotnet", "ExcelAI.API.dll"]
