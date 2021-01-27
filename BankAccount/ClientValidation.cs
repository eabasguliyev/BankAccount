namespace BankAccount
{
    public class ClientValidation
    {
        public static bool NameValidate(string name)
        {
            foreach (var @char in "!@#$%^&*()_+/*-1234567890")
            {
                if (name.Contains(@char.ToString()))
                    return false;
            }
            return true;
        }

        public static bool AgeValidate(int age)
        {
            if (age < 18)
                return false;
            return true;
        }

        public static bool SalaryValidate(double salary)
        {
            if (salary >= 0)
                return true;
            return false;
        }
    }
    public class BankCardValidation
    {
        public static bool PinValidate(string PIN)
        {
            foreach (var num in PIN)
            {
                if (!((int)num >= 48 && (int)num <= 57))
                    return false;
            }

            return true;
        }

        public static bool PinLengthValidate(string PIN)
        {
            if (PIN.Length != 4)
                return false;
            return true;
        }

        public static bool PanValidate(string PAN)
        {
            PAN = PAN.Trim();

            if (PAN.Length != 16)
                return false;
            return true;
        }
    }
}