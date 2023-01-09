#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["UserEventBooking/UserEventBooking.csproj", "UserEventBooking/"]
RUN dotnet restore "UserEventBooking/UserEventBooking.csproj"
COPY . .
WORKDIR "/src/UserEventBooking"
RUN dotnet build "UserEventBooking.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserEventBooking.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserEventBooking.dll"]