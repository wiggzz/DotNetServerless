# .NET Serverless

This is a project for showing some best practices for setting up a .NET Core project for Lambda.

Oh the joy.

But anyway, it contains a few useful features:

  * Commandline first experience
  * Deployment to AWS using Serverless framework
  * Code style enforcement using StyleCop
  * npm build tooling (restore, test, package)
  * Unit test scaffolding
  * Structured logging using Serilog

Coming soon / TO DO:

  * Other testing frameworks than NUnit (although dotnet watch isn't bad)
  * Deployment using SAM
  * Containerised setup for dev setup and CI set up

## Set up

You will need to install .NET core. You're on your own with that (Google it)

Install the node dependencies (serverless)

    npm i

Restore .NET dependencies

    npm run restore

Run the tests

    npm t

Package for deployment

    npm run package

Deploy to lambda (you will need to have your AWS credentials configured correctly)

    npm run deploy

None of these have been tested on any other machine than my own so, no guarantees.

## Development

If you want to watch for changes to rerun the tests, use

    npm run watch