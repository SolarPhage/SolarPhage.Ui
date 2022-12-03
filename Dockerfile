FROM mcr.microsoft.com/dotnet/sdk:6.0 as build

# Install node
RUN curl -sL https://deb.nodesource.com/setup_16.x | bash
RUN apt-get update && apt-get install -y nodejs

RUN dotnet tool restore


WORKDIR /src
COPY . .
RUN npm install

EXPOSE 80
EXPOSE 443
CMD ["npm", "start"]
