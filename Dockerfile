FROM  mcr.microsoft.com/dotnet/sdk:6.0.302 AS build-env
WORKDIR /Afiliaciones
RUN mkdir EventBus
RUN mkdir Services
WORKDIR /Afiliaciones/EventBus
RUN mkdir EventBus
RUN mkdir EventBusRabbitMQ
RUN mkdir IntegrationEventLogEF
WORKDIR /Afiliaciones/Services/RegistroAfiliacionesService/src
RUN mkdir Application
RUN mkdir Domain
RUN mkdir Infrastructure


# Copy csproj and restore as distinct layers
COPY Services/RegistroAfiliacionesService/src/Application/*.csproj ./Application
COPY Services/RegistroAfiliacionesService/src/Domain/*.csproj ./Domain
COPY Services/RegistroAfiliacionesService/src/Infrastructure/*.csproj ./Infrastructure

WORKDIR /Afiliaciones/EventBus
COPY EventBus/EventBus/*.csproj ./EventBus
COPY EventBus/IntegrationEventLogEF/*.csproj ./IntegrationEventLogEF
COPY EventBus/EventBusRabbitMQ/*.csproj ./EventBusRabbitMQ


WORKDIR /Afiliaciones/Services/RegistroAfiliacionesService/src/Application
RUN dotnet restore

# Copy everything else and build
WORKDIR /Afiliaciones
COPY . ./
WORKDIR /Afiliaciones/Services/RegistroAfiliacionesService/src/Application
RUN dotnet publish -c Release -o out

# Build runtime image
FROM  mcr.microsoft.com/dotnet/sdk:6.0.302 
WORKDIR /app
COPY --from=build-env /Afiliaciones/Services/RegistroAfiliacionesService/src/Application/out .
ENTRYPOINT ["dotnet", "Application.dll"]