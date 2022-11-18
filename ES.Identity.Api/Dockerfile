FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ES.Identity.Api/ES.Identity.Api.csproj", "ES.Identity.Api/"]
RUN dotnet restore "ES.Identity.Api/ES.Identity.Api.csproj"
COPY . .
WORKDIR "/src/ES.Identity.Api"
RUN dotnet build "ES.Identity.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ES.Identity.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ES.Identity.Api.dll"]
