using System;

namespace POE_Part_1
{
    class Program
    {


        // Pose question to user, parse their input and return it
        static Decimal getDecimalInput(String question)
        {
            Console.Write(question);       // Print question to command line
            String input = Console.ReadLine();  // Get input from user
            input = input.Replace('.', ',');    // Replace dot with comma so program works in most locales

            decimal result;     // Result variable

            // Keep asking for input until a valid Decimal is given
            while (!decimal.TryParse(input, out result))
            {
                Console.WriteLine("Sorry, your response is not a valid amount. Try again...");  // Error message for invalid input
                Console.Write(question);    // Print question to command line
                input = Console.ReadLine();     // Get input from user
                input = input.Replace('.', ',');    // Replace dot with comma so program works in most locales
            }

            return result;      // Return parsed result
        }


        static void Main(string[] args)
        {

            decimal grossMonthlyIncome = getDecimalInput("Enter your gross monthly income before deductions: ");
            decimal monthlyTaxDeducted = getDecimalInput("Enter your estimated monthly tax deducted: ");
            decimal monthlyGroceriesCost = getDecimalInput("Enter your estimated monthly expenditure on Groceries: ");
            decimal monthlyUtilitiesCost = getDecimalInput("Enter your estimated monthly expenditure on Water and lights: ");
            decimal monthlyTravelCost = getDecimalInput("Enter your estimated monthly travel costs including petrol: ");
            decimal monthlyPhoneCost = getDecimalInput("Enter your estimated monthly cellphone and telephone costs: ");
            decimal monthlyOtherCost = getDecimalInput("Enter any the cost of any other estimated monthly costs: ");

            String rentingInput = "";
            do
            {

                Console.Write("Are you renting or buying a property? (Type either renting or buying): ");       // Print question to command line
                rentingInput = Console.ReadLine();  // Get input from user


            } while (!rentingInput.Equals("renting") && !rentingInput.Equals("buying"));

            bool isRenting = false;

            if (rentingInput.Equals("renting"))
            {
                isRenting = true;
            }

            decimal monthlyRent = 0;
            decimal purchasePrice = 0;
            decimal totalDeposit = 0;
            decimal interestRate = 0;
            int repaymentMonths = 0;
            decimal monthlyPayment = 0;


            if (isRenting)
            {
                monthlyRent = getDecimalInput("Enter your monthly rental amount: ");
            }
            else
            {
                purchasePrice = getDecimalInput("Enter the cost of the property: ");
                totalDeposit = getDecimalInput("Enter the total deposit put down on the house (%): ");
                interestRate = getDecimalInput("Enter the interest rate (%): ");
                interestRate /= 100;

                do
                {
                    Console.WriteLine("Enter the repayment length in months: ");
                    String repaymentMonthsStr = Console.ReadLine();
                    int result;     // Result variable

                    // Keep asking for input until a valid time is given
                    while (!int.TryParse(repaymentMonthsStr, out result))
                    {
                        Console.WriteLine("Sorry, your response is not a valid amount. Try again...");  // Error message for invalid input
                        Console.Write("Enter the repayment length in months: ");    // Print question to command line
                        repaymentMonthsStr = Console.ReadLine();     // Get input from user

                    }
                    repaymentMonths = result;

                } while (repaymentMonths < 240 && repaymentMonths > 360);

                decimal repaymentYears = repaymentMonths / 12;
                decimal principal = ((100 - totalDeposit) / 100) * purchasePrice;
                decimal totalAmount = principal * ((decimal)1.0 + (interestRate * repaymentYears));
                monthlyPayment = totalAmount / repaymentMonths;


            }


            if (monthlyPayment > (grossMonthlyIncome / 3))
            {
                Console.WriteLine("YOUR MONTHLY PAYMENT ON YOUR HOME IS MORE THAN ONE THRID OF YOUR MONTHLY INCOME!!!");
            }

            Console.WriteLine("Your gross monthly income is R" + grossMonthlyIncome);
            Console.WriteLine("Your monthly tax deducted is R" + monthlyTaxDeducted);
            Console.WriteLine("Your monthly groceries expenditure is R" + monthlyGroceriesCost);
            Console.WriteLine("Your monthly utilities expenditure is R" + monthlyUtilitiesCost);
            Console.WriteLine("Your monthly repayment is R" + monthlyPayment);


            decimal moneyLeft = grossMonthlyIncome - monthlyTaxDeducted - monthlyGroceriesCost - monthlyUtilitiesCost -
                monthlyTravelCost - monthlyPhoneCost - monthlyOtherCost;

            if (isRenting)
            {
                moneyLeft -= monthlyRent;
            }
            else
            {
                moneyLeft -= monthlyPayment;
            }

            Console.WriteLine("You have R" + moneyLeft + " for the month.");

        }



    }
}
