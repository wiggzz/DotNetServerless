#!/bin/bash

set -e

DEPLOYMENT_BUCKET=dotnet-serverless-deployment

aws s3api head-bucket --bucket $DEPLOYMENT_BUCKET || aws s3 mb s3://$DEPLOYMENT_BUCKET --region ap-southeast-2

mkdir -p build/

aws cloudformation package --template-file sam.yaml --s3-bucket $DEPLOYMENT_BUCKET --output-template-file build/sam.yaml

aws cloudformation deploy --template-file build/sam.yaml --stack-name dotnet-serverless-hello-world --capabilities CAPABILITY_IAM