using SlaSystem.Presentation.Api.Contracts.Slas;

namespace SlaSystem.Presentation.Api.Contracts.Requests;

public record RequestDto(string Id, RequestType RequestType, string Description, string OwnerId, UserDto? Owner, 
    UserDto Client, string ClientId, string SlaId, SlaDto Sla, DateTime CreatedAt, RequestStatus RequestStatus, 
    SlaStatus SlaStatus, DateTime SlaExpiredOn, DateTime ClosedAt);