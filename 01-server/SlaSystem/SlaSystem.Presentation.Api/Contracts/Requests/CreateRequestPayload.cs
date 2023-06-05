namespace SlaSystem.Presentation.Api.Contracts.Requests;

public class CreateRequestPayload
{
    public RequestType RequestType { get; set; }
    public string Description { get; set; } = string.Empty;
    public string ClientId { get; set; } = string.Empty;
}