using Octokit;
namespace Exer08.examples.GOctokit{
    public static class Demo
    {
        public static async Task Run(){
            var github = new GitHubClient(new ProductHeaderValue("Packet"));
            const string username = "DLrandy";
            var user = await github.User.Get(username);
            Console.WriteLine($"{username} created profile at {user.CreatedAt}");

        }
    }
}