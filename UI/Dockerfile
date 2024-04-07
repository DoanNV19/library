FROM node:16.14.2 as build

RUN mkdir -p /usr/src/app
WORKDIR /usr/src/app
COPY UI/ /usr/src/app/
RUN npm install -f
RUN npm run build

FROM nginx:latest
COPY --from=build /usr/src/app/dist/velzon /usr/share/nginx/html
EXPOSE 80