#FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
#WORKDIR /app
#COPY ClientService.csproj ./
#RUN dotnet restore
#COPY . ./
##RUN #dotnet publish -c Release -o out
#RUN dotnet restore "ClientService.csproj"
#RUN dotnet build "ClientService.csproj" -c Release -o out
#FROM mcr.microsoft.com/dotnet/sdk:7.0
#WORKDIR /app
#COPY --from=build /app/out .
#ENTRYPOINT ["dotnet", "ClientService.dll"]

#
#FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
#WORKDIR /app
#COPY . /app
#
#FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
#WORKDIR /src
#COPY ["ClientService.csproj", "ClientService/"]
#RUN dotnet restore "ClientService/ClientService.csproj"
#COPY . .
#WORKDIR "/src/ClientService"
##RUN dotnet build "ClientService.csproj" -c Release -o /app/build
##
##FROM build AS publish
##RUN dotnet publish "ClientService.csproj" -c Release -o /app/publish /p:UseAppHost=false
##
#FROM base AS final
#WORKDIR /app
##COPY --from=publish /app/publish .
###COPY --from=build-env /App/out .
#ENTRYPOINT ["dotnet", "ClientService\ClientService\bin\Debug\net7.0\ClientService.dll"]






FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ClientService.csproj", "ClientService/"]
RUN dotnet restore "ClientService/ClientService.csproj"
COPY . .
WORKDIR "/src/ClientService"
RUN dotnet build "ClientService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ClientService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClientService.dll"]
