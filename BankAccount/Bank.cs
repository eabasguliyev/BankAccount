using System;

namespace BankAccount
{
    public class Bank
    {
        public string Name { get; set; }

        public Client[] Clients { get; private set; }
        
        public BankCard CreateBankCard(Client client, string pin, int expireYears)
        {
            if (String.IsNullOrWhiteSpace(pin))
                throw new ArgumentNullException(nameof(pin), "PIN can not be null");

            if (!BankCardValidation.PinValidate(pin))
                throw new BankCardException("PIN must be numeric value!");


            var bankCard = new BankCard
            {
                BankName = Name,
                Fullname = BankHelper.GetFullName(client.Name, client.Surname),
                CardNumber = BankHelper.GetRandomPan(),
                PIN = pin,
                CVC = BankHelper.GetRandomCvc(),
                ExpireDate = BankHelper.GetExpireDate(expireYears),
                Balance = BankHelper.GetRandomBalance()
            };

            return bankCard;
        }

        public void ShowCardBalance(string PAN, string PIN)
        {
           // var indexOfClient = Array.FindIndex(Clients, client => client.ClientCard?.CardNumber == PAN);

            var client = Array.Find(Clients, client1 => client1.ClientCard.CardNumber == PAN);

            if (client != null)
            {
                if(client.ClientCard.PIN == PIN)
                    client.ClientCard.ShowBalance();

                throw new ClientException("Your PIN number is wrong!");
            }
            else
            {
                throw new ClientException($"There is no Card associated this PAN -> {PAN}");
            }
        }

        public void AddClient(Client client)
        {
            var newLength = (Clients != null) ? Clients.Length + 1 : 1;
            var temp = new Client[newLength];

            if(temp != null)
            {
                if(Clients != null)
                    Array.Copy(Clients, temp, Clients.Length);

                temp[newLength - 1] = client;
            }

            Clients = temp;
        }

        public Client GetClient(string PAN, string PIN)
        {
            var client = Array.Find(Clients, client1 => client1.ClientCard.CardNumber == PAN);

            if (client != null)
            {
                if(client.ClientCard.PIN == PIN)
                    return client;

                throw new ClientException("Your PIN number is wrong!");
            }
            else
            {
                throw new ClientException($"There is no Card associated this PAN -> {PAN}");
            }
        }

        public void ShowClients()
        {
            if (Clients != null)
            {
                foreach (var client in Clients)
                {
                    client.Show();
                    client.ClientCard.ShowCard();
                }
            }
        }

        public void Withdraw(BankCard bankCard, double amount)
        {
            if (amount > bankCard.Balance)
                throw new InsufficientAmountException("There is no sufficient amount in balance");

            bankCard.Balance -= amount;
        }

        public void CardToCard(BankCard from, string toPan, double amount)
        {
            var client = Array.Find(Clients, client1 => client1.ClientCard.CardNumber == toPan);

            if (client != null)
            {
                if (amount > from.Balance)
                    throw new InsufficientAmountException($"There is no sufficient amount this card -> {toPan}");

                from.Balance -= amount;
                client.ClientCard.Balance += amount;
            }
            else
            {
                throw new ClientException($"There is no Card associated this PAN -> {toPan}");
            }
        }
    }
}