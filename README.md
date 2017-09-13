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
  * Deployment using SAM
  * Configuration for environment dependent settings

Coming soon / TO DO:

  * Containerised setup for dev setup and CI set up
  * Other testing frameworks than NUnit (although dotnet watch isn't bad)


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

## Comparison between .NET Core Raw and ASP.NET Core

For a hello world app:

| Property | .NET Core Raw | ASP.NET |
| -------- | ------------- | ------- |
| Package size | 570KB | 2100KB |
| Cold Start Time | 414ms | 815ms |
| Warm Start Time | 3ms | 2ms |

### .NET Core Raw Samples
416ms (cold)
12ms
7ms
3ms
3ms
3ms
3ms
3ms
413ms (cold)
5ms
3ms
2ms

### ASP.NET Samples
818ms (cold)
811ms (cold)
11ms
8ms
2ms
2ms
2ms
2ms
2ms