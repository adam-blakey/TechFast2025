# Use the official Nginx image as a base
FROM nginx:alpine

# Copy your static HTML file to the Nginx HTML directory
COPY index.html /usr/share/nginx/html/index.html
COPY talk-poster.jpg /usr/share/nginx/html/talk-poster.jpg

EXPOSE 8080
