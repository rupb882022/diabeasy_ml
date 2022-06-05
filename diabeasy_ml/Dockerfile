#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["diabeasy_ml/diabeasy_ml.csproj", "diabeasy_ml/"]
RUN dotnet restore "diabeasy_ml/diabeasy_ml.csproj"
COPY . .
WORKDIR "/src/diabeasy_ml"
RUN dotnet build "diabeasy_ml.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "diabeasy_ml.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "diabeasy_ml.dll"]