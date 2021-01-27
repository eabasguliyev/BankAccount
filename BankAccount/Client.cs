using System;

namespace BankAccount
{
    public class Client
    {
        public int Id { get; private set; }
        
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (!ClientValidation.NameValidate(value))
                    throw new ClientException("Name can not be contain numeric value!");

                _name = value.Trim();
            }
        }

        private string _surname;

        public string Surname
        {
            get => _surname;
            set
            {
                if (!ClientValidation.NameValidate(value))
                    throw new ClientException("Surname can not be contain numeric value!");

                _surname = value.Trim();
            }
        }

        private int _age;

        public int Age
        {
            get => _age;
            set
            {
                if (!ClientValidation.AgeValidate(value))
                    throw new ClientException("Age can be minimum 18!");

                _age = value;
            }
        }

        private int _salary;

        public int Salary
        {
            get => _salary;
            set
            {
                if (!ClientValidation.SalaryValidate(value))
                    throw new ClientException("Salary must be positive value!");

                _salary = value;
            }
        }

        public BankCard ClientCard { get; set; } = null;
        public Log[] Logs { get; private set; }
        public static int ClientId { get; private set; } = default;

        public Client()
        {
            Id = ++ClientId;
        }

        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("-------Client Info-------");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Surname: {Surname}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Salary: {Salary}");
            Console.ResetColor();
        }

        public void AddLog(Log log)
        {
            var newLength = (Logs != null) ? Logs.Length + 1 : 1;
            var temp = new Log[newLength];

            if (temp != null)
            {
                if (Logs != null)
                {
                    Array.Copy(Logs, temp, Logs.Length);
                }

                temp[newLength - 1] = log;
            }

            Logs = temp;
        }

        public Log GetLog(int id)
        {
            return Array.Find(Logs, log => log.Id == id);
        }

        public void LogFilter(int lastDays)
        {
            if (Logs == null)
                throw new Exception("There is no log!");

            foreach (var log in Logs)
            {
                var date = DateTime.Now.AddDays(-lastDays);

                if(log.date >= date)
                    log.Show();
            }
        }
    }
}