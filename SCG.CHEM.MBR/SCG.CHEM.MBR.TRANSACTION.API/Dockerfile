#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SCG.CHEM.MBR.TRANSACTION.API/SCG.CHEM.MBR.TRANSACTION.API.csproj", "SCG.CHEM.MBR.TRANSACTION.API/"]
COPY ["SCG.CHEM.MBR.COMMON/SCG.CHEM.MBR.COMMON.csproj", "SCG.CHEM.MBR.COMMON/"]
COPY ["SCG.CHEM.MBR.AUTH.BUSINESSLOGIC/SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.csproj", "SCG.CHEM.MBR.AUTH.BUSINESSLOGIC/"]
COPY ["SCG.CHEM.SSPLSP.DATAACCESS/SCG.CHEM.SSPLSP.DATAACCESS.csproj", "SCG.CHEM.SSPLSP.DATAACCESS/"]
COPY ["SCG.CHEM.MBR.DATAACCESS/SCG.CHEM.MBR.DATAACCESS.csproj", "SCG.CHEM.MBR.DATAACCESS/"]
RUN dotnet restore "SCG.CHEM.MBR.TRANSACTION.API/SCG.CHEM.MBR.TRANSACTION.API.csproj"
COPY . .
WORKDIR "/src/SCG.CHEM.MBR.TRANSACTION.API"
RUN dotnet build "SCG.CHEM.MBR.TRANSACTION.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SCG.CHEM.MBR.TRANSACTION.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SCG.CHEM.MBR.TRANSACTION.API.dll", "--environment=Development"]