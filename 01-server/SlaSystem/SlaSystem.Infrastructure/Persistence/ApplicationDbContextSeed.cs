using System.Reflection;
using System.Text.Json;

namespace SlaSystem.Infrastructure.Persistence;

public class ApplicationDbContextSeed
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        if (!context.Users.Any())
        {
            var usersData = File.ReadAllText(path + @"/Persistence/Data/users.json");
            var users = JsonSerializer.Deserialize<List<User>>(usersData);
            if (users != null) context.Users.AddRange(users);
        }

        if (!context.Requests.Any())
        {
            var requestsData = await File.ReadAllTextAsync(path + @"/Persistence/Data/requests.json");
            var requests = JsonSerializer.Deserialize<List<Request>>(requestsData);
            if (requests != null) context.Requests.AddRange(requests);
        }

        if (!context.Slas.Any())
        {
            var slasData = await File.ReadAllTextAsync(path + @"/Persistence/Data/slas.json");
            var slas = JsonSerializer.Deserialize<List<Sla>>(slasData);
            if (slas != null) context.Slas.AddRange(slas);
        }

        if (!context.Queues.Any())
        {
            var queuesData = await File.ReadAllTextAsync(path + @"/Persistence/Data/queues.json");
            var queues = JsonSerializer.Deserialize<List<Queue>>(queuesData);
            if (queues != null) context.Queues.AddRange(queues);
        }

        if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
    }
}