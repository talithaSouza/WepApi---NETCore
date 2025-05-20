##Build
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

# Copiando arquivos de projeto primeiro (para cache)
COPY ["Api.Application/application.csproj", "Api.Application/"]
COPY ["Api.CrossCutting/CrossCutting.csproj", "Api.CrossCutting/"]
COPY ["Api.Service/Service.csproj", "Api.Service/"]
COPY ["Api.Domain/Domain.csproj", "Api.Domain/"]
COPY ["Api.Data/Data.csproj", "Api.Data/"]

# Restaura e copia tudo
RUN dotnet restore "Api.Application/application.csproj"

# Copia o restante dos arquivos
COPY . .

# PUBLICA
RUN dotnet publish "Api.Application/application.csproj" -c Release -o /app/publish

# Runtime da imagem
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /app

#Variáveis De Ambiente
ENV DATABASE=MYSQL
ENV MIGRATION=APLICAR
ENV DB_CONNECTION="Server=mysql_container;Port=3306;Database=api_dotnet;User=root;Password=Abc12345!;"

# Copia os arquivos publicados da etapa de build
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:80

ENTRYPOINT ["dotnet", "application.dll"]