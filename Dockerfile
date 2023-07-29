# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./recipe-book-api.csproj" --disable-parallel
RUN dotnet publish "./recipe-book-api.csproj" -c release -o /app --no-restore


# Stage 2: Serve
FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal
WORKDIR /app
COPY --from=build /app ./

# Expose the port your Web API listens on (change the port number if needed)
EXPOSE 5000

# Start the .NET Web API when the container is run
ENTRYPOINT ["dotnet", "recipe-book-api.dll"]
