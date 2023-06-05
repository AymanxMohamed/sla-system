namespace SlaSystem.Presentation.Api.Contracts.Requests;

public sealed record CreateRequestPayload(RequestType RequestType, string Description, string ClientId);
