# authpolicyrepro
Reproduction of Bug involving IIS / IIS Express, AuthorizationPolicy and Windows Auth

Issue Ref: https://github.com/dotnet/aspnetcore/issues/39901

## Instructions

Run this in IIS or IIS Express with Windows Authentication enabled. 

This is a standard WeatherController Web API created with `dotnet new webapi`. The only additions to this were adding "Windows" as an authentication scheme, and defining an AuthorizationPolicy + AuthorizationHandler + AuthorizationRequirement.

The behavior defined in the AuthorizationHandler named `SomeAuthHandler` is to mark the authorization successful only if the user principal is a `WindowsPrincipal` object. The project is configured to 

In the `appsettings.json`, remove "Windows" from the `AuthSchemes` key and make it an empty array to produce a successful response to the WeatherController.