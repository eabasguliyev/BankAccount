using System;

namespace BankAccount
{
    public class ClientException:System.Exception
    {
        public override string Message { get; }

        public ClientException(string message)
        {
            Message = message;
        }
    }
    public class BankCardException : System.Exception
    {
        public override string Message { get; }

        public BankCardException(string message)
        {
            Message = message;
        }
    }
    public class InsufficientAmountException : SystemException
    {
        public override string Message { get; }

        public InsufficientAmountException(string message)
        {
            Message = message;
        }
    }
}