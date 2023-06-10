namespace Exer08.Common
{
    public static class EnvironmentVariables
    {
        public static string GetOrThrow(string environmentVariable){
            var variable = Environment.GetEnvironmentVariable(environmentVariable, EnvironmentVariableTarget.User);

            if (string.IsNullOrWhiteSpace(variable))
            {
                throw new ArgumentException($"Environment variable {environmentVariable} not found.");
            }
            return variable;
        }
    }
}