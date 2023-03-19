using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using  System.Globalization;
namespace exer05
{

    public enum RegionName
    {
        North, East, South, West
    }
    public record User
    {
        public User(string userName, RegionName region) => (UserName, Region) = (userName, region);
        public string UserName { get; }
        public string ID { get; set; }
        public RegionName Region { get; }
    }
    public class AsyncExer
    {


        public static async Task Main()
        {
            Console.WriteLine($"ETA: {DelayTime.TotalSeconds:N}seconds");
            TimeSpan? maxWaitingTime;
            while (true)
            {
                maxWaitingTime = ReadConsoleMaxTime("Fetch");
                if (maxWaitingTime == null)
                {
                    break;
                }
                using var tokenSource = new CancellationTokenSource(maxWaitingTime.Value);
                var token = tokenSource.Token;
                token.Register(() => Logger.Log($"Fetch: Cancelled token={token.GetHashCode()}"));
                var resultTask = FetchLoop(DelayTime, token);
                // var resultTask = Fetch(DelayTime, token);
                try
                {
                    await resultTask;
                    if (resultTask.IsCompletedSuccessfully)
                    {
                        Logger.Log($"Fetch: Result={resultTask.Result:N0}");
                    } else {
                        Logger.Log($"Fetch: Status={resultTask.Status}");
                    }

                }
                catch (TaskCanceledException ex)
                {
                    Logger.Log($"Fetch: TaskCanceledException {ex.Message}");
                }
            }
        }
        public static Task<double> Fetch(TimeSpan delay, CancellationToken token){
            return Task.Run(()=>{
                var now = DateTime.Now;
                Logger.Log("Fetch: Sleeping");
                Thread.Sleep(delay);
                Logger.Log("Fetch: Awake");
                return DateTime.Now.Subtract(now).TotalSeconds;
            }, token);
        }
        public static Task<double?> FetchLoop(TimeSpan delay, CancellationToken token){
            return Task.Run(() => {
                const int TimeSlice = 500;
                var iterations = (int) (delay.TotalMilliseconds / TimeSlice);
                Logger.Log($"FetchLoop: Iterations={iterations} token={token.GetHashCode()}");
                var now = DateTime.Now;
                for (var i = 0; i < iterations; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        Logger.Log($"FetchLoop: Iteration {i + 1} detected cancellation token={token.GetHashCode()}");
                        return (double?)null;
                    }
                    Logger.Log($"FetchLoop:Iteration {i + 1} Sleeping");
                    Thread.Sleep(TimeSlice);
                    Logger.Log($"FetchLoop: Iteration {i + 1} Awake");
                }
                Logger.Log("FetchingLoop: done");
                return DateTime.Now.Subtract(now).TotalSeconds;

            }, token);
        }
        private static readonly TimeSpan DelayTime=TimeSpan.FromSeconds(3);
        private static TimeSpan? ReadConsoleMaxTime(string message){
            Console.Write($"{message} Max Waiting Time (seconds):");
            var input = Console.ReadLine();
            if (int.TryParse(input,NumberStyles.Any, CultureInfo.CurrentCulture, out var intResult))
            {
                return TimeSpan.FromSeconds(intResult);
            }
            return null;
        }
        public static async Task Mainww()
        {
            const string Url = "https://www.packetpub.com";
            using var client = new WebClient();
            client.DownloadDataCompleted += async (sender, args) =>
            {
                Logger.Log("Inside DownloadDataCompoleted...looking busy");
                await Task.Delay(500);
                Logger.Log("Inside DownloadDataCompleted...all done now");
            };
            // Logger.Log($"DownloadData: {Url}");
            // var data = client.DownloadData(Url);
            // Logger.Log($"DownloadData: Length={data.Length:N0}");
            Logger.Log($"DownloadDataTaskAsync: {Url}");
            var downloadTask = client.DownloadDataTaskAsync(Url);
            var downloadBytes = await downloadTask;
            Logger.Log($"DownloadDataTaskAsync: Length={downloadBytes.Length:N0}");
            Console.ReadLine();
        }
        public async Task CreateAccounts()
        {
            var users = await FetchPendingAccounts();
            foreach (var user in users)
            {
                var id = await GenerateId();
                user.ID = id;
            }
            var accountCreationTasks = users.Select(user => user.Region == RegionName.North ?
                Task.Run(() => CreateNorthernAccount(user)) :
                Task.Run(() => CreateOtherAccount(user))
            ).ToList();
            Logger.Log($"Creating {accountCreationTasks.Count} accounts");
            await Task.WhenAll(accountCreationTasks);
            var updatedAccountTask = UpdatePendingAccounts(users);
            await updatedAccountTask;
            Logger.Log($"Updated {updatedAccountTask.Result} pending accounts");
        }
        private async Task<List<User>> FetchPendingAccounts()
        {
            Logger.Log("Fetching pending accounts...");
            await Task.Delay(TimeSpan.FromSeconds(3D));
            var users = new List<User>{
                new User("AnnH", RegionName.North),
                new User("EmmaJ", RegionName.North),
                new User("SophieA", RegionName.South),
                new User("LucyG", RegionName.West),
            };
            Logger.Log($"Found {users.Count} pending account");
            return users;
        }
        private static Task<string> GenerateId()
        {
            return Task.FromResult(Guid.NewGuid().ToString());
        }
        private static async Task<bool> CreateNorthernAccount(User user)
        {
            await Task.Delay(TimeSpan.FromSeconds(2D));
            Logger.Log($"Created northern account for {user.UserName}");
            return true;
        }
        private static async Task<bool> CreateOtherAccount(User user)
        {
            await Task.Delay(TimeSpan.FromSeconds(1D));
            Logger.Log($"Created other account for {user.UserName}");
            return true;
        }
        private static async Task<int> UpdatePendingAccounts(IEnumerable<User> users)
        {
            var updateAccountTasks = users.Select(user => Task.Run(async () =>
            {
                await Task.Delay(TimeSpan.FromSeconds(2D));
                return true;
            })).ToList();
            await Task.WhenAll(updateAccountTasks);
            return updateAccountTasks.Count(t => t.Result);
        }
        public static async Task Maind()
        {
            Logger.Log("starting");
            await new AsyncExer().CreateAccounts();
            Logger.Log("All Done");
            Console.ReadLine();
        }
        public static async Task MainAsync()
        {
            Logger.Log("starting");
            await BuildGreetings();
            Logger.Log("press enter");
            Console.ReadLine();
        }
        private static async Task BuildGreetings()
        {
            var message = "Morning";
            Logger.Log($"{message}");
            await Task.Delay(TimeSpan.FromSeconds(10D));
            message += "...afternoon";
            Logger.Log($"{message}");
            await Task.Delay(TimeSpan.FromSeconds(1D));
            message += "...Evening";
            Logger.Log($"{message}");
        }
    }
}