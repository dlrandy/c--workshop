using Octokit;
namespace Exer08.examples.GitHttp{
    public static class Demo
    {
        private static string GitHubPersonAccessToken {get;} = Environment.GetEnvironmentVariable("GitHubPersonalAccess", EnvironmentVariableTarget.User);
        public static async Task Run(){
          
          var oathAccessToken = await GitExample.GetToken();
          await GitExample.UpdateEmploymentStatus(true, oathAccessToken);
          await GitExample.UpdateEmploymentStatus(false, oathAccessToken);

          var basicToken = GitExample.GetBasicToken();
          await GitExample.GetUser61Times(basicToken);
          GitExample.Dispose();
        }
    }
}