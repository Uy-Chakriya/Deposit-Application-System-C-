using System;

namespace DepositApplicationSystem
{
    class Program
    {
        static void Main(string[] args)
        {

            // use the do while loop 
            string choice;
            do
            {
                Console.WriteLine("Deposit Application System");

                double deposit = GetDepositAmount();
                int currencyType = GetCurrencyType();
                int durationType = GetDurationType();

                int months;
                double interestRate;

                GetInterestRateAndMonths(currencyType, durationType, out interestRate, out months);

                double interest, totalMoney, monthlyInterest;
                CalculateDeposit(deposit, interestRate, months, out interest, out totalMoney, out monthlyInterest);

                string currencyLabel = (currencyType == 1) ? "R" : "$";

                DisplayResult(interest, totalMoney, monthlyInterest, currencyLabel);

                Console.Write("Do you want to continue? Yes/No: ");
                choice = Console.ReadLine();
                Console.WriteLine("--------------------------------");

            } while (choice.ToLower() == "yes");
        }

        // -------- Methods --------

        static double GetDepositAmount()
        {
            Console.Write("Deposit: ");
            return Convert.ToDouble(Console.ReadLine());
        }

        static int GetCurrencyType()
        {
            Console.WriteLine("Currency:\n1.Riel\n2.Dollar");
            Console.Write("Please enter your transaction: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        static int GetDurationType()
        {
            Console.WriteLine("Duration:");
            Console.WriteLine("1. 1 month\n2. 2 months\n3. 3 months\n4. 6 months\n5. 12 months");
            Console.Write("Please enter your transaction: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        static void GetInterestRateAndMonths(int currencyType, int durationType, out double interestRate, out int months)
        {
            interestRate = 0;
            months = 0;

            if (currencyType == 1) // Riel
            {
                switch (durationType)
                {
                    case 1: interestRate = 0.035 / 12; months = 1; break;
                    case 2: interestRate = 0.04 / 6; months = 2; break;
                    case 3: interestRate = 0.045 / 4; months = 3; break;
                    case 4: interestRate = 0.0675 / 2; months = 6; break;
                    case 5: interestRate = 0.085; months = 12; break;
                }
            }
            else // Dollar
            {
                switch (durationType)
                {
                    case 1: interestRate = 0.03 / 12; months = 1; break;
                    case 2: interestRate = 0.035 / 6; months = 2; break;
                    case 3: interestRate = 0.04 / 4; months = 3; break;
                    case 4: interestRate = 0.055 / 2; months = 6; break;
                    case 5: interestRate = 0.08; months = 12; break;
                }
            }
        }

        static void CalculateDeposit(double deposit, double interestRate, int months,
                                     out double interest, out double totalMoney, out double monthlyInterest)
        {
            interest = (deposit * interestRate) - ((deposit * interestRate) * 0.06);
            totalMoney = deposit + interest;
            monthlyInterest = interest / months;
        }

        static void DisplayResult(double interest, double totalMoney, double monthlyInterest, string currencyLabel)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Interest: {interest:F2}{currencyLabel}");
            Console.WriteLine($"Total Money: {totalMoney:F2}{currencyLabel}");
            Console.WriteLine($"Monthly Interest: {monthlyInterest:F2}{currencyLabel}");
        }
    }
}
