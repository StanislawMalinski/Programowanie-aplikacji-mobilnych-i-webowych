FROM node:18-alpine
EXPOSE 5137:5137
WORKDIR /app/
COPY package.json /app/
COPY src /app/src
COPY tsconfig.json /app/
COPY index.html /app/
COPY package-lock.json /app/
COPY tsconfig.node.json /app/
COPY vite.config.ts /app/
COPY public /app/public
RUN npm install
CMD ["npm", "run", "host"]