#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

    FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
    WORKDIR /app
    EXPOSE 80
    EXPOSE 443
    RUN apt-get update
    RUN apt-get install -y curl
    RUN apt-get install -y libpng-dev libjpeg-dev curl libxi6 build-essential libgl1-mesa-glx
    RUN curl -sL https://deb.nodesource.com/setup_lts.x | bash -
    RUN apt-get install -y nodejs

    FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
    RUN apt-get update
    RUN apt-get install -y curl
    RUN apt-get install -y libpng-dev libjpeg-dev curl libxi6 build-essential libgl1-mesa-glx
    RUN curl -sL https://deb.nodesource.com/setup_lts.x | bash -
    RUN apt-get install -y nodejs
    WORKDIR /src
    COPY ["server/UniversityProcessing.API.csproj", "server/"]
    RUN dotnet restore "server/UniversityProcessing.API.csproj"
    COPY . .
    WORKDIR "/src/server"
    RUN dotnet build "UniversityProcessing.API.csproj" -c Release -o /app/build

    FROM build AS publish
    RUN dotnet publish "UniversityProcessing.API.csproj" -c Release -o /app/publish

    FROM base AS final
    WORKDIR /app
    COPY --from=publish /app/publish .
    ENTRYPOINT ["dotnet", "UniversityProcessing.API.dll"]