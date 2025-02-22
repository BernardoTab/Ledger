# Use the official .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory inside the container
WORKDIR /src

# Copy the WebApp .csproj and restore any dependencies (via dotnet restore)
COPY ./LedgerAPI/Ledger.csproj ./LedgerAPI/
COPY ./Ledger.DataAccessContext/Ledger.DataAccessContext.csproj ./Ledger.DataAccessContext/
COPY ./Ledger.DataTransferring/Ledger.DataTransferring.csproj ./Ledger.DataTransferring/
COPY ./Ledger.Entities/Ledger.Entities.csproj ./Ledger.Entities/
COPY ./Ledger.Services/Ledger.Services.csproj ./Ledger.Services/
COPY ./Ledger.Services.Implementations/Ledger.Services.Implementations.csproj ./Ledger.Services.Implementations/
COPY ./Ledger.Services.Implementations.IoC/Ledger.Services.Implementations.IoC.csproj ./Ledger.Services.Implementations.IoC/

RUN dotnet restore ./LedgerAPI/Ledger.csproj

# Copy the entire solution into the container and publish
COPY . .
WORKDIR /src/LedgerAPI
RUN dotnet publish -c Release -o /app

# Use the official .NET runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

# Set the working directory inside the container
WORKDIR /app

# Copy the published files from the build stage
COPY --from=build /app .

# Expose the port the app will run on
EXPOSE 80

# Define the entrypoint to run the application
ENTRYPOINT ["dotnet", "Ledger.dll"]
