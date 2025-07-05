# Use a minimal Nginx image
FROM nginx:alpine

# Create a blank white HTML page
RUN echo '<!DOCTYPE html><html><head><title>Blank</title><style>body{margin:0;background:#fff;}</style></head><body></body></html>' > /usr/share/nginx/html/index.html

# Expose port 80
EXPOSE 8080

# Nginx will start by default as the CMD in the base image
