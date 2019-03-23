FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["MacroHelixService.WebAPI/NdcArchitect.WebAPI/NdcArchitect.WebAPI.csproj", "MacroHelixService.WebAPI/NdcArchitect.WebAPI/"]
RUN dotnet restore "MacroHelixService.WebAPI/NdcArchitect.WebAPI/NdcArchitect.WebAPI.csproj"
COPY . .
WORKDIR "/src/MacroHelixService.WebAPI/NdcArchitect.WebAPI"
RUN dotnet build "NdcArchitect.WebAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "NdcArchitect.WebAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "NdcArchitect.WebAPI.dll"]