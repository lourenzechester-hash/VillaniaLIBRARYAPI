FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

FROM mcr.microsoft.com/dotnet/aspnet:8.0 As build
WORKDIR / src
COPY . .
RUN dotnet restore "VillaniaLIBRARYAPI.csproj"
RUN dotnet publish "VillaniaLIBRARYAPI.csproj" -c Realease -o /app/out

FROM base AS final
WORKDIR /app
COPY --from-build /app/out .
ENTRYPOINT ["dotnet", "VillaniaLIBRARYNowAPI.dll"]
