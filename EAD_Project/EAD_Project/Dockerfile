#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EAD_Project/EAD_Project.csproj", "EAD_Project/"]
RUN dotnet restore "EAD_Project/EAD_Project.csproj"
COPY . .
WORKDIR "/src/EAD_Project"
RUN dotnet build "EAD_Project.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EAD_Project.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EAD_Project.dll"]