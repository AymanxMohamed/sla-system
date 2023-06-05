using System.Reflection;
using System.Text.Json;
using SlaSystem.Domain.ValueObjects;

namespace SlaSystem.Infrastructure.Persistence;

public static class TempApplicationDbContextSeed
{
    public static void Seed()
    {
        if (!Queue.Queues.Any())
        {
            Queue.Queues.AddRange(new []
            {
                Queue.Create(RequestType.Invoice, QueueName.Create("Invoice Request Type")),
                Queue.Create(RequestType.Payment, QueueName.Create("Payment Request Type")),
            });
        }
        
        if (!Sla.Slas.Any())
        {
            Sla.Slas.AddRange(new []
            {
                Sla.Create(RequestType.Invoice, Severity.High, 2),
                Sla.Create(RequestType.Payment, Severity.Medium, 4)
            });
        }

        if (!User.Users.Any())
        {
            User.Users.AddRange(new []
            {
                CreateUser("egypt_admin", "egypt_admin", "EGP",null , Role.Admin),
                CreateUser("uae_admin", "uae_admin", "UAE", null, Role.Admin),
                CreateUser("egypt_user", "egypt_user", "EGP", Queue.Queues[0], Role.User),
                CreateUser("uae_user", "uae_user", "UAE", Queue.Queues[1], Role.User),
                CreateUser("egypt_client", "egypt_client", "EGP", null, Role.User),
                CreateUser("uae_client", "uae_client", "EGP", null, Role.User),
            });
        }

        if (!Request.Requests.Any())
        {
            Request.Requests.AddRange(new []
            {
                Request.Create(RequestType.Invoice, Description.Create("Invoice Request Type"),Sla.Slas[0], 
                    User.Users[4]),
                Request.Create(RequestType.Payment, Description.Create("Payment Request Type"),Sla.Slas[1], 
                    User.Users[5]),
            });
        }


        
    }

    private static User CreateUser(string userName, string password, string zone, Queue? queue, Role role)
    { 
        return User.Create(UserName.Create(userName), Password.Create(password), Zone.Create(zone), queue, role);
    }

}