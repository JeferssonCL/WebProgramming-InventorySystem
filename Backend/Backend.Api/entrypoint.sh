#!/bin/bash

# Wait for the database to be ready
until dotnet ef database update --project Backend.API; do
    >&2 echo "Postgres is unavailable - sleeping"
    sleep 1
done

# Start the application
dotnet Backend.API.dll
