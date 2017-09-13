#!/bin/bash

set -e

docker build -t dotnet-serverless .

docker run dotnet-serverless npm t
