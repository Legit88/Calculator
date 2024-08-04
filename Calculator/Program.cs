// See https://aka.ms/new-console-template for more information

using System.Linq.Expressions;
using System.Text.RegularExpressions;

class Calculator
{
    public static double DoOperation(double num1, double num2, string op)
    {
        double result = double.NaN; //Default value is "not-a-number" if an operation, such as division, could result in error.
        
        //using switch statement to do the math
        switch(op)
        {
            case "a":
                result = num1 + num2;
            break;
            case "s":
                result = num1 - num2;
            break;
            case "m":
                result = num1 * num2;
                break;

            case "d":
                  
                //ask the user to enter a non-zero divisor
                if(num2 != 0)
                {
                    result = num1 / num2;
                }
                break;

            //Return text for an incorrect option entry
            default:
                break;

               
        }
        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        bool endApp = false;
        //Display title as the C# console calculator app.
        Console.WriteLine("Console Calculator in C#\r");
        Console.WriteLine("---------------------------\n");

        while (!endApp)
        {
            //Declare variables and set to empty
            //use Nullable types (with ?) to match type of system.Console.ReadLine
            string? numInput1 = "";
            string? numInput2 = "";
            double result = 0;

            //Ask the user to type the first number
            Console.Write("Type a number and press Enter: ");
            numInput1 = Console.ReadLine();

            double cleanNum1 = 0;
            while (!double.TryParse(numInput1, out cleanNum1))
                
            {
                Console.Write("This is not valid input. Please enter a numeric value: ");
                numInput1 = Console.ReadLine();
            }

            //Ask the user to type the second number
            Console.Write("Type another number and press Enter: ");
            numInput2 = Console.ReadLine();

            double cleanNum2 = 0; //create a variable and assign to zero

            //a while loop that will keep running until the user enters a numeric value

            while (!double.TryParse(numInput2, out cleanNum2))//double.tryparse analyzes numinput2 to check if it's a number and if it is, it assigns out the number to cleanNum2
            {
                Console.Write("This is not a valid input. Please enter a numeric value: ");
                numInput2 = Console.ReadLine();
            }


            //Ask the user to choose an Operator
            Console.WriteLine("Choose an operator from the List below: ");
            Console.WriteLine("\ta - Add");
            Console.WriteLine("\ts - Subtract");
            Console.WriteLine("\tm - Multiply");
            Console.WriteLine("\td - Divide");
            Console.Write("Your Option: ");

            String? op = Console.ReadLine();

            //validate input is not null, and matches any of the strings above

            if (op == null || !Regex.IsMatch(op, "[a|s|m|d]")) // if the user's input is empty, or does not match any of the characters(a,s,m,d)

            {
                Console.WriteLine("Error: Unrecognized input.");

            }
            else
            {
                try
                {
                    result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in mathematical error. \n ");

                    }
                    else
                    {
                        Console.WriteLine("Your result: {0:0.##}\n", result);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! An exception occurred trying to do the math. \n - Details: " + e.Message);
                }
            }

            Console.WriteLine("-----------------------\n");
            //wait for the user to respond before closing
            Console.WriteLine("Press 'n' and ENTER to close the app, or press any other key and ENTER to continue");
            if (Console.ReadLine() == "n") endApp = true;

            Console.WriteLine("\n"); //this is just a friendly spacing
        }
        return;
    }
        
}