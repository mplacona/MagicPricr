FROM microsoft/dotnet:1.1.1-runtime
LABEL name "magicpricr"
 
WORKDIR /app
COPY out .
 
ENV ASPNETCORE_URLS http://*:5000
EXPOSE 5000
 
ENTRYPOINT ["dotnet",  "MagicPricr.dll"]
