using Exercise;

//  Validation
Console.WriteLine("=== 1. Validation ===");
TryBuild("no URL", new HttpRequestBuilder());
TryBuild("relative URL", new HttpRequestBuilder().Url("/echo"));
TryBuild("bad method", new HttpRequestBuilder().Url("http://localhost:5000").Method("POTS"));
TryBuild("GET with body", new HttpRequestBuilder().Url("http://localhost:5000").Body("{}"));
TryBuild("valid POST", new HttpRequestBuilder().Url("http://localhost:5000").Method("POST").Body("{}"));

//  independent requests
Console.WriteLine();
Console.WriteLine("=== 2. Independent requests ===");
var builder = new HttpRequestBuilder()
    .Url("http://localhost:5000/echo")
    .Method("POST")
    .Header("Content-Type", "application/json")
    .QueryParameter("preview", "true")
    .Body("{\"product\":\"Keyboard\",\"quantity\":2}");

var first = builder.Build();

builder
    .Header("Content-Type", "text/plain")
    .QueryParameter("preview", "false")
    .Header("X-Trace", "abc");

var second = builder.Build();

Print("first ", first);
Print("second", second);

// // Optional: send the first request if a URL is passed
// if (args.Length > 0)
// {
//     using var httpClient = new HttpClient(new HttpClientHandler { AllowAutoRedirect = false });
//     IClient client = new Client(httpClient);
//
//     var request = builder.Url(args[0]).Header("Content-Type", "application/json").Build();
//     using var response = await client.SendAsync(request);
//     Console.WriteLine();
//     Console.WriteLine($"Status: {(int)response.StatusCode} {response.StatusCode}");
//     Console.WriteLine(await response.Content.ReadAsStringAsync());
// }

static void TryBuild(string label, HttpRequestBuilder builder)
{
    try
    {
        builder.Build();
        Console.WriteLine($"{label}: OK");
    }
    catch (InvalidOperationException e)
    {
        Console.WriteLine($"{label}: {e.Message}");
    }
}

static void Print(string label, HttpRequest request)
{
    var headers = string.Join(", ", request.Headers.Select(h => $"{h.Key}={h.Value}"));
    var query = string.Join(", ", request.QueryParameters.Select(q => $"{q.Key}={q.Value}"));
    Console.WriteLine($"{label}: {request.Method} {request.Url} | headers: {headers} | query: {query}");
}
