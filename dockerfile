FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

WORKDIR /src/ThingyDexer.Model
COPY ThingyDexer.Model/ThingyDexer.Model.csproj .
RUN dotnet restore ThingyDexer.Model.csproj
COPY ThingyDexer.Model .
RUN dotnet build ThingyDexer.Model.csproj -c Release -o /app/build/ThingyDexer.Model

WORKDIR /src/ThingyDexer.ViewModel
COPY ThingyDexer.ViewModel/ThingyDexer.ViewModel.csproj .
RUN dotnet restore ThingyDexer.ViewModel.csproj
COPY ThingyDexer.ViewModel .
RUN dotnet build ThingyDexer.ViewModel.csproj -c Release -o /app/build/ThingyDexer.ViewModel

WORKDIR /src/ThingyDexer.View
COPY ThingyDexer.View/ThingyDexer.View.csproj .
RUN dotnet restore ThingyDexer.View.csproj
COPY ThingyDexer.View .
RUN dotnet build ThingyDexer.View.csproj -c Release -o /app/build/ThingyDexer.View

WORKDIR /src/ThingyDexer.WASM
COPY ThingyDexer.WASM/ThingyDexer.WASM.csproj .
RUN dotnet restore ThingyDexer.WASM.csproj
COPY ThingyDexer.WASM .
RUN dotnet build ThingyDexer.WASM.csproj -c Release -o /app/build/ThingyDexer.WASM

FROM build AS publish
RUN dotnet publish ThingyDexer.WASM.csproj -c Release -o /app/publish


FROM nginx:stable-alpine AS final
WORKDIR /usr/share/nginx/html

COPY --chmod=755 --from=publish /app/publish/wwwroot .
COPY nginx.conf /etc/nginx/nginx.conf

COPY --chmod=755 <<-"EOT" /usr/share/nginx/html/sample-data/Version.md
## Version
v0.1.23 (ALPHA - DOCKER)
EOT
EXPOSE 80