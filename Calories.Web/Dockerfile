FROM node AS build

RUN apt-get update && apt-get install -y \
  python make gcc g++ \
  && rm -rf /var/lib/apt/lists/*


WORKDIR /app
COPY . .

RUN yarn
RUN export NODE_OPTIONS=--openssl-legacy-provider && yarn compile

FROM nginx:stable

EXPOSE 80
COPY --from=build /app/build/ /usr/share/nginx/html