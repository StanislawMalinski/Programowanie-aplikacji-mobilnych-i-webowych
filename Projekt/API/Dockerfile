FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
EXPOSE 7061
WORKDIR /app/
COPY /API/ /app/
RUN dotnet tool install --global dotnet-ef
ENV PATH="${PATH}:/root/.dotnet/tools"
RUN dotnet dev-certs https --trust
CMD ["dotnet", "run"] 
