﻿using SlaSystem.Domain.Enums;
using SlaSystem.Domain.Primitives;
using SlaSystem.Domain.ValueObjects;

namespace SlaSystem.Domain.Entities;

public class Request : Entity
{
    private SlaStatus _slaStatus = SlaStatus.Active;
    private Request(
        Guid id,
        RequestType requestType,
        Description description,
        Sla sla,
        User client) : base(id)
    {
        RequestType = requestType;
        Description = description;
        Sla = sla;
        Client = client;
    }

    public RequestType RequestType { get; }
    public Description Description { get; private set; }
    public User? Owner { get; private set; }
    public User Client { get; }
    public Sla Sla { get; }

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

    public void Assign(User owner) => Owner = owner;


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
        var request = new Request(new Guid(), requestType, description, sla, client);
        request.SetSlaExpiredOn();
        return request;
    }
    
    private void SetSlaExpiredOn() =>   SlaExpiredOn = CreatedAt.AddHours(Sla.DurationInHours);
}