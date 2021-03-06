#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
RUN apt-get update -y && \
	apt-get upgrade -y && \
	apt-get install wget apt-transport-https software-properties-common git nodejs npm -y && \
	wget -q https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb && \
	dpkg -i packages-microsoft-prod.deb && \
	apt-get update -y && \
	apt-get install powershell -y && \
	npm i -g love.js

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ShowcaseSite/ShowcaseSite.csproj", "ShowcaseSite/"]
RUN dotnet restore "ShowcaseSite/ShowcaseSite.csproj"
COPY . .
WORKDIR "/src/ShowcaseSite"
RUN dotnet build "ShowcaseSite.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShowcaseSite.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShowcaseSite.dll"]