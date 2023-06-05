using SlaSystem.Domain.Enums;
using SlaSystem.Domain.Primitives;
using SlaSystem.Domain.ValueObjects;

namespace SlaSystem.Domain.Entities;

public class Request : Entity
{
    public static readonly List<Request> Requests = new();
    private SlaStatus _slaStatus = SlaStatus.Active;
    private Request(
        Guid id,
        RequestType requestType,
        string description,
        Guid slaId,
        Guid clientId) : base(id)
    {
        RequestType = requestType;
        Description = description;
        SlaId = slaId;
        ClientId = clientId;
    }

    public RequestType RequestType { get; }
    public string Description { get; private set; }
    public Guid OwnerId { get; private set; }
    public User? Owner { get; private set; }
    public User Client { get; private init; }
    public Guid ClientId { get;  }
    public Sla Sla { get; private set; }
    public Guid SlaId { get; }

    public DateTime CreatedAt { get; } = DateTime.Now;
    public RequestStatus RequestStatus { get; private set; } = RequestStatus.Active;
    
    public SlaStatus SlaStatus {
        get
        {
            if (DateTime.Now >= SlaExpiredOn)
                _slaStatus = SlaStatus.Expired;
            return _slaStatus;
        }
    }
    
    public DateTime SlaExpiredOn { get; private set; }
    public DateTime ClosedAt { get; private set; }

    public void Assign(User owner)
    {
        Owner = owner;
        OwnerId = owner.Id;
    }


    public void Close()
    {
        ClosedAt = DateTime.Now;
        RequestStatus = RequestStatus.Closed;
    }

    public static Request Create(
        RequestType requestType,
        Description description,
        Sla sla,
        User client)
    {
        var request = new Request(Guid.NewGuid(), requestType, description.Value, sla.Id, client.Id)
        {
            Sla = sla,
            Client = client
        };
        request.SetSlaExpiredOn();
        return request;
    }
    
    private void SetSlaExpiredOn() =>   SlaExpiredOn = CreatedAt.AddHours(Sla.DurationInHours);
}