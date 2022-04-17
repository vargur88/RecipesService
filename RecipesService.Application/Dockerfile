#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["RecipesService.Application/RecipesService.Application.csproj", "RecipesService.Application/"]
RUN dotnet restore "RecipesService.Application/RecipesService.Application.csproj"
COPY . .
WORKDIR "/src/RecipesService.Application"
RUN dotnet build "RecipesService.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RecipesService.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RecipesService.Application.dll"]