namespace Exercise;

public class HttpRequest
{
    public string Url { get; set; } = "";
    public string Method { get; set; } = "GET";
    public Dictionary<string, string> Headers { get; set; } = new(StringComparer.OrdinalIgnoreCase);
    public Dictionary<string, string> QueryParameters { get; set; } = new();
    public string? Body { get; set; }
}
