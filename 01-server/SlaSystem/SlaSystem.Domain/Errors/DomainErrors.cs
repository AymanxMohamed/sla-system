using SlaSystem.Domain.Shared;

namespace SlaSystem.Domain.Errors;

public static class DomainErrors
{
    public static class Request
    {
        public static readonly Error SlaExpired = new("Request.SlaExpired", 
            "Can't Close this request because the sla has been expired");
    }
}