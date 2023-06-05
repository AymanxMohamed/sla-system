using SlaSystem.Presentation.Api.Contracts.Slas;

namespace SlaSystem.Presentation.Api.Contracts.Requests;

public record RequestDto(string Id, string RequestType, string Description, string OwnerId, UserDto? Owner, 
    UserDto Client, string ClientId, string SlaId, SlaDto Sla, DateTime CreatedAt, string RequestStatus, 
    string SlaStatus, DateTime SlaExpiredOn, DateTime ClosedAt);