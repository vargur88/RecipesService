FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
COPY ["RecipesService.Application/RecipesService.Application.csproj", "RecipesService.Application/"]
COPY ["RecipesService.Domain/RecipesService.Domain.csproj", "RecipesService.Domain/"]
COPY ["RecipesService.Handlers/RecipesService.Handlers.csproj", "RecipesService.Handlers/"]
COPY ["RecipesService.Repository/RecipesService.Repository.csproj", "RecipesService.Repository/"]
COPY ["RecipesService.Repository.Interfaces/RecipesService.Repository.Interfaces.csproj", "RecipesService.Repository.Interfaces/"]
RUN dotnet restore "RecipesService.Application/RecipesService.Application.csproj"
COPY . .
RUN dotnet build "RecipesService.Application/RecipesService.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RecipesService.Application/RecipesService.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet RecipesService.Application.dll
#ENTRYPOINT ["dotnet", "RecipesService.Application.dll"]