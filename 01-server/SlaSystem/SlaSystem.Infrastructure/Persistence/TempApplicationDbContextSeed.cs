using System.Reflection;
using System.Text.Json;

namespace SlaSystem.Infrastructure.Persistence;

public static class TempApplicationDbContextSeed
{
    public static async Task SeedAsync()
    {
        var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        if (!User.Users.Any())
        {
            var usersData = File.ReadAllText(path + @"/Persistence/Data/users.json");
            var users = JsonSerializer.Deserialize<List<User>>(usersData);
            if (users != null) User.Users.AddRange(users);
        }

        if (!Request.Requests.Any())
        {
            var requestsData = await File.ReadAllTextAsync(path + @"/Persistence/Data/requests.json");
            var requests = JsonSerializer.Deserialize<List<Request>>(requestsData);
            if (requests != null) Request.Requests.AddRange(requests);
        }

        if (!Sla.Slas.Any())
        {
            var slasData = await File.ReadAllTextAsync(path + @"/Persistence/Data/slas.json");
            var slas = JsonSerializer.Deserialize<List<Sla>>(slasData);
            if (slas != null) Sla.Slas.AddRange(slas);
        }

        if (!Queue.Queues.Any())
        {
            var queuesData = await File.ReadAllTextAsync(path + @"/Persistence/Data/queues.json");
            var queues = JsonSerializer.Deserialize<List<Queue>>(queuesData);
            if (queues != null) Queue.Queues.AddRange(queues);
        }
    }
}