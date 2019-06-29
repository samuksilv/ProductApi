FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Product.api.csproj", "./"]
RUN dotnet restore "./Product.api.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Product.api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Product.api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Product.api.dll"]
