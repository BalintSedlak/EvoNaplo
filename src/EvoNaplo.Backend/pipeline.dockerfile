  FROM mcr.microsoft.com/dotnet/aspnet:6.0
  COPY /EvoNaplo.WebApp/bin/Release/net6.0/publish/ App/
  WORKDIR /App
  ENTRYPOINT ["dotnet", "EvoNaplo.WebApp.dll"]