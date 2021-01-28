using System;
using System.Text;

namespace BankAccount
{
    public class BankHelper
    {
        public static Random random { get; set; }

        static BankHelper()
        {
            random = new Random();
        }

        public static string GetRandomPan()
        {
            var sBuilder = new StringBuilder();
            sBuilder.Append(random.Next(1000, 9999).ToString())
                .Append(random.Next(1000, 9999).ToString())
                .Append(random.Next(1000, 9999).ToString())
                .Append(random.Next(1000, 9999).ToString());

            return sBuilder.ToString();
        }

        public static string GetFullName(string name, string surname) => String.Format($"{name} {surname}");

        public static string GetRandomCvc()
        {
            return random.Next(100, 999).ToString();
        }

        public static DateTime GetExpireDate(int years) => DateTime.Now.AddYears(years);

        public static double GetRandomBalance()
        {
            return random.Next(10, 1000);
        }
    }
}