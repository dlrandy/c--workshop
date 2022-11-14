using System;
namespace exer03_05
{
    class FuncExam
    {
        static string RemoveAtSign(string address) => address.Replace("@", "");
        static string RemoveDots(string address) => address.Replace(".", "");
        public static void Main(){
            Func<string, string> emailFormatter = RemoveDots;
            const string Address = "admin@google.com";
            var first = emailFormatter(Address);
            Console.WriteLine($"First={first}");
            emailFormatter += RemoveAtSign;
            var second = emailFormatter(Address);
            Console.WriteLine($"Second={second}");
            Console.ReadLine();
        }
    }
}