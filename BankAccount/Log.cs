using System;

namespace BankAccount
{
    public class Log
    {
        public int Id { get; private set; }
        public string Title { get; set; }
        public string Info { get; set; }
        public DateTime date { get; private set; }
        public static int LogId { get; private set; } = default;

        public Log()
        {
            Id = ++LogId;
            date = DateTime.Now;
        }
        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("-----------Log Info-----------");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Info: {Info}");
            Console.WriteLine($"Date: {date:G}");
            Console.ResetColor();
        }
    }
}