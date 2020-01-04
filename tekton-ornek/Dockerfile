FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["tekton-ornek/tekton-ornek.csproj", "tekton-ornek/"]
RUN dotnet restore "tekton-ornek/tekton-ornek.csproj"
COPY . .
WORKDIR "/src/tekton-ornek"
RUN dotnet build "tekton-ornek.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "tekton-ornek.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "tekton-ornek.dll"]