using SlaSystem.Presentation.Api.Contracts.Queues;
using SlaSystem.Presentation.Api.Contracts.Requests;
using SlaSystem.Presentation.Api.Contracts.Slas;

namespace SlaSystem.Presentation.Api.Utils;

public static class AutoMapper
{
    public static UserDto MapUser(User user)
    {
        return new UserDto(
            user.Id.ToString(),
            user.UserName,
            user.Password,
            user.Role.ToString(),
            user.Zone,
            user.QueueId.ToString()!);
    }

    public static QueueDto MapQueue(Queue queue)
    {
        var usersDtos = queue.Users.Select(MapUser).ToList();
        
        return  new QueueDto(
            queue.Id.ToString(),
            queue.QueueName,
            queue.RequestType.ToString(),
            usersDtos);
    }

    public static SlaDto MapSla(Sla sla)
    {
        return new SlaDto(
            sla.Id.ToString(),
            sla.RequestType.ToString(),
            sla.Severity.ToString(),
            sla.DurationInHours);
    }
    //
    // public record RequestDto(string Id, string RequestType, string Description, string OwnerId, UserDto Owner, 
    //     UserDto Client, string ClientId, string SlaId, SlaDto Sla, DateTime CreatedAt, string RequestStatus, 
    //     string SlaStatus, DateTime SlaExpiredOn, DateTime ClosedAt);

    public static RequestDto MapRequest(Request request)
    {
        var ownerDto = request.Owner != null ? MapUser(request.Owner) : null;
        var clientDto = MapUser(request.Client);
        var slaDto = MapSla(request.Sla);

        return new RequestDto(
            request.Id.ToString(),
            request.RequestType.ToString(),
            request.Description,
            request.OwnerId.ToString(),
            ownerDto,
            clientDto,
            request.ClientId.ToString(),
            request.SlaId.ToString(),
            slaDto,
            request.CreatedAt,
            request.RequestStatus.ToString(),
            request.SlaStatus.ToString(),
            request.SlaExpiredOn,
            request.ClosedAt    
            );
    }
}