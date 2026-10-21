namespace Exercise;

public interface IClient
{
    Task<HttpResponseMessage> SendAsync(HttpRequest request, CancellationToken cancellationToken = default);
}
