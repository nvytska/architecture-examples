# HTTP request composer

Provided: an `HttpRequest` data class, an `IClient` interface, a real HTTP `Client`.

Implement a fluent API for configuring the URL, method, headers, query parameters, and optional body.

1. Validate the configuration before creating a request.
2. Produce independent requests that remain unchanged after further configuration changes.
3. Save and restore the complete configuration.
4. Undo several configuration changes in reverse order.
5. **Optional:** support logging outgoing requests and blocking requests to hosts outside a configurable allowlist. Both features must be independently enabled or disabled. Do not modify the supplied `Client` class.

Demonstrate creating, modifying, and restoring requests. You can inspect the resulting objects locally; use the supplied client when sending requests to a chosen endpoint.

**50–60 minutes.** Everyone writes their own implementation; groups of three discuss and help debug. Be ready to demonstrate and explain your code during check-ins.

Run from the repository root:

```sh
dotnet run --project Exercise/Exercise.csproj
```

Without an argument, the program prints usage instructions. To send the sample POST request, pass the URL of an endpoint you have running, for example:

```sh
dotnet run --project Exercise/Exercise.csproj -- http://localhost:5000/echo
```

`Program.cs` demonstrates only the supplied data class and client. The real client uses the supplied `HttpClient`; the caller disposes the returned response. Automatic redirects are disabled in the sample, so a redirect does not silently send a request to another host.
