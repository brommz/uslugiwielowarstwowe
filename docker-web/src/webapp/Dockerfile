FROM microsoft/aspnetcore:1.1  
ARG source  
RUN echo "source: $source"  
WORKDIR /app  
COPY ${source:-/build} .  
EXPOSE 5000
ENTRYPOINT ["dotnet", "webapp.dll"]
