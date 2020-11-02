# Smapiot Backend Case Study

My solution for a Billing Engine API that consumes data from a request data collector.
This API has a single endpoint: `/api/report` with parameters "year", "month" and "subscription".

## How to run
This API is a .NET Core 3.1 Web API, so the dotnet runtime is required.
Also, `SmapiotCaseStudy/SmapiotCaseStudy.Api/appsettings.json` is a required file, with the following format *as an **example***. 

```json
{
  "RequestDataCollector": {
    "BaseUrl": "https://smapiot-requests.azurewebsites.net/api/requests/",
    "APIKey": "***apiKey_here***"
  },
  "ServicePricing": {
    "template": 17.5,
    "document": 15,
    "feed": 10,
    "invoice": 2.12,
    "mail": 0.25,
    "checkout": 1.33,
    "thumbnail": 0.0125,
    "payment": 1.123
  },
  "CORS": {
    "Origins": [
      "https://localhost:5001",
      "http://localhost:5000"
    ],
    "Methods": [
      "GET"
    ]
  }
}

```
Please note that an API key for the request data collector service has to be provided.
