# usufulApp

[![ForecasrService](https://github.com/Ledrunning/usefulApp/actions/workflows/dotnet.yml/badge.svg)](https://github.com/Ledrunning/usefulApp/actions/workflows/dotnet.yml)

## Attention! The project is under development!

Client-server application built on a microservices architecture in C#/.NET.
Provides weather, currency rates and cryptocurrency data through separate services.

## Architecture

| Service | Purpose |
|---|---|
| ForecastService | Weather data from [OpenWeather] |
| [CurrencyService] | Currency exchange rates from [API name] |
| [CryptoService] | Cryptocurrency rates from [API name] |
| [Client] | [WPF / web client] |

[Add a simple diagram or one sentence on how the client and services communicate.]

## Tech stack

C#, .NET [version], ASP.NET Core, REST API, GitHub Actions (CI)
[add: Docker, tests, etc. only if they are actually used]

## Getting started

```bash
git clone https://github.com/Ledrunning/usefulApp.git
cd usefulApp
# [how to run services, e.g. dotnet run --project ...]
```

Set the API keys in `appsettings.json` (or user secrets), do not commit them:

```json
{
  "OpenWeatherApi": { "ApiKey": "<your key>" }
}
```

## Status

[Work in progress: planned improvements, e.g. API gateway, database, Docker.]

## License

MIT
