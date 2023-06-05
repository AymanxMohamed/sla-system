using SlaSystem.Domain.Shared;

namespace SlaSystem.Domain.Errors;

public static class DomainErrors
{
    public static class Request
    {
        public static readonly Error SlaExpired = new("Request.SlaExpired", 
            "Can't Close this request because the sla has been expired");
        public static readonly Error InvalidClient = new("Request.InvalidClient", 
            "Their is no client with this Id");
    }

    public static class User
    {
        public static readonly Error DuplicateUserName = new("User.DuplicateUserName", 
            "Can't Create Request with this user because it's used before");
        
        public static readonly Error InvalidUserName = new("User.InvalidUserName", 
            "Invalid User Name");
            
        public static readonly Error InvalidPassword = new("User.InvalidPassword", 
            "Invalid Password");
    }
}