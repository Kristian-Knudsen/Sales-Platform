FROM node:lts-alpine

WORKDIR /app

# Copy package.json and package-lock.json
COPY package*.json .

# Install app dependencies
RUN npm install

# Move code
COPY . .

# Expose Vite dev server port
EXPOSE 5173

# Set environment variable for hot reloading
# ENV VITE_APP_HOST 0.0.0.0  # Allow connections from host machine

# Start development server
CMD ["npm", "run", "dev"]