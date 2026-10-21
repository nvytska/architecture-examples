using System.Text;

namespace Exercise;

public sealed class Client : IClient
{
    private readonly HttpClient httpClient;

    public Client(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<HttpResponseMessage> SendAsync(
        HttpRequest request, CancellationToken cancellationToken = default)
    {
        var uri = new UriBuilder(request.Url);
        var parameters = string.Join("&", request.QueryParameters.Select(parameter =>
            $"{Uri.EscapeDataString(parameter.Key)}={Uri.EscapeDataString(parameter.Value)}"));

        if (parameters.Length > 0)
        {
            var existingQuery = uri.Query.TrimStart('?');
            uri.Query = existingQuery.Length == 0 ? parameters : $"{existingQuery}&{parameters}";
        }

        using var message = new HttpRequestMessage(new HttpMethod(request.Method), uri.Uri);
        if (request.Body is not null)
        {
            message.Content = new StringContent(request.Body, Encoding.UTF8);
        }

        foreach (var header in request.Headers)
        {
            if (message.Headers.TryAddWithoutValidation(header.Key, header.Value))
            {
                continue;
            }

            if (message.Content is null)
            {
                throw new InvalidOperationException($"Header '{header.Key}' requires request content.");
            }

            message.Content.Headers.Remove(header.Key);
            message.Content.Headers.Add(header.Key, header.Value);
        }

        return await httpClient.SendAsync(message, cancellationToken);
    }
}
