#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Source/Presentation/CopaApp.Presentation.UI/CopaApp.Presentation.UI.csproj", "Source/Presentation/CopaApp.Presentation.UI/"]
RUN dotnet restore "Source/Presentation/CopaApp.Presentation.UI/CopaApp.Presentation.UI.csproj"
COPY . .
WORKDIR "/src/Source/Presentation/CopaApp.Presentation.UI"
RUN dotnet build "CopaApp.Presentation.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CopaApp.Presentation.UI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CopaApp.Presentation.UI.dll"]
