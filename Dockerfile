FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY TektonOrnek.sln .
COPY TektonOrnek/TektonOrnek.csproj TektonOrnek/
COPY BirimTestleri/BirimTestleri.csproj BirimTestleri/
RUN dotnet restore TektonOrnek.sln
COPY TektonOrnek/ TektonOrnek/
WORKDIR /src/TektonOrnek
RUN dotnet build TektonOrnek.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish TektonOrnek.csproj -c Release -o /app/publish

FROM build AS testrunner
WORKDIR /src
COPY BirimTestleri/ BirimTestleri/
RUN dotnet test TektonOrnek.sln --logger:trx

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TektonOrnek.dll"]