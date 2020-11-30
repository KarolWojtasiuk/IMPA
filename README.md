# IMPA ![](https://github.com/KarolWojtasiuk/IMPA/workflows/.NET/badge.svg?branch=master)

IMPA Meeting People App

## Usage
1. Clone repo
    > git clone https://github.com/KarolWojtasiuk/IMPA.git
2. Edit `appsettings.json`
3. Run `dotnet run`

## Getting Started
These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

> [.NET 5.0 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)

### Installing
Clone this repository to your computer.
> git clone https://github.com/KarolWojtasiuk/IMPA.git

Then go to the repository directory.
> cd IMPA

Finally build server app.
> dotnet build IMPA

## Running the tests
Tests for this application is provided by xUnit.
.NET Core contains a Test Runner, so you don't have to download anything.

Just run this command.
> dotnet test IMPA.Tests

## Built With

* [xUnit](https://xunit.net) - Testing framework
* [MongoDB](https://www.mongodb.com) - Database
* [MongoDB.Driver](https://mongodb.github.io/mongo-csharp-driver) - Database driver
