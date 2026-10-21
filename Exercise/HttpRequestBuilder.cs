namespace Exercise;

public class HttpRequestBuilder
{
    private string url = "";
    private string method = "GET";
    private Dictionary<string, string> headers = new(StringComparer.OrdinalIgnoreCase);
    private Dictionary<string, string> query = new();
    private string? body;

    public HttpRequestBuilder Url(string value)
    {
        url = value;
        return this;
    }

    public HttpRequestBuilder Method(string value)
    {
        method = value;
        return this;
    }

    public HttpRequestBuilder Header(string key, string value)
    {
        headers[key] = value;
        return this;
    }

    public HttpRequestBuilder QueryParameter(string key, string value)
    {
        query[key] = value;
        return this;
    }

    public HttpRequestBuilder Body(string value)
    {
        body = value;
        return this;
    }

    private static readonly HashSet<string> AllowedMethods =
        new(StringComparer.OrdinalIgnoreCase) { "GET", "POST", "PUT", "PATCH", "DELETE", "HEAD" };

    private void Validate()
    {
        if (string.IsNullOrWhiteSpace(url))
            throw new InvalidOperationException("URL is required.");

        if (!Uri.TryCreate(url, UriKind.Absolute, out var uri) || (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps))
            throw new InvalidOperationException($"Invalid URL: '{url}'. Must be absolute http/https.");

        if (!AllowedMethods.Contains(method))
            throw new InvalidOperationException($"Unsupported HTTP method: '{method}'.");

        if (body is not null && (method.Equals("GET", StringComparison.OrdinalIgnoreCase) || method.Equals("HEAD", StringComparison.OrdinalIgnoreCase)))
            throw new InvalidOperationException($"{method} request cannot have a body.");
    }

    public HttpRequest Build()
    {
        Validate();
        return new HttpRequest
        {
            Url = url,
            Method = method,
            Headers = new Dictionary<string, string>(headers, StringComparer.OrdinalIgnoreCase),
            QueryParameters = new Dictionary<string, string>(query),
            Body = body
        };
    }
}