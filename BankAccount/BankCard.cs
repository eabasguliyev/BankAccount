using System;

namespace BankAccount
{
    public class BankCard
    {
        public string BankName { get; set; }
        public string Fullname { get; set; }
        public string CardNumber { get; set; }
        public string PIN { get; set; }
        public string CVC { get; set; }
        public DateTime ExpireDate { get; set; }
        public double Balance { get; set; }

        public void ShowCard()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("-------Bank Card Info-------");
            Console.WriteLine($"Bank name: {BankName}");
            Console.WriteLine($"Fullname: {Fullname}");
            Console.WriteLine($"Card number: {CardNumber}");
            Console.WriteLine($"ExpireDate: {ExpireDate.Month}/{ExpireDate.Year % 100}");
            Console.ResetColor();
        }

        public void ShowBalance()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Balance: {Balance}");
            Console.ResetColor();
        }

    }
}