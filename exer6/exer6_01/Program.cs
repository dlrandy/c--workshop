using System;
namespace Exer06
{
    class Program
    {
        public static string GlobalFactoryConnectionString { get;} = GetEnvironmentVariableOrThrow("GlobalFactory"); 
        public static string AdventureWorksConnectionString { get;} = GetEnvironmentVariableOrThrow("AdventureWorks"); 
        // public static string TruckLogisticsConnectionString { get;} = GetEnvironmentVariableOrThrow("TruckLogistics"); 
        static void Main(string[] args){
            // Exer06.exers.exer01.Demo.Run();
            //  Exer06.TalkingWithDb.Orm.Demo.Run();
            //  Exer06.Crud.Demo.Run();
             exer6_01.GlobalFactory2021.Demo.Run();
        }
        private static string GetEnvironmentVariableOrThrow(string environmentVariable){
            var variable = Environment.GetEnvironmentVariable(environmentVariable, EnvironmentVariableTarget.Process);
            if (string.IsNullOrWhiteSpace(variable))
            {
                throw new ArgumentException($"Environment variable {environmentVariable} not found.");
            }
            return variable;
        }
    }    
}