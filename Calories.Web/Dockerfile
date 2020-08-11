FROM node AS build

WORKDIR /app
COPY . .

RUN yarn
RUN yarn compile

FROM nginx:stable

EXPOSE 80
COPY --from=build /app/build/ /usr/share/nginx/html