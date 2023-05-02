# pull official base image
FROM node:18.16.0-alpine
EXPOSE 3000
# set working directory
WORKDIR /app

# add `/app/node_modules/.bin` to $PATH
ENV PATH /app/node_modules/.bin:$PATH

# install app dependencies
COPY RentCar.UI/package.json ./
COPY RentCar.UI/package-lock.json ./
RUN npm install --silent

# add app
COPY RentCar.UI/ ./

# start app
CMD ["npm", "start"]