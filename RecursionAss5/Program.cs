using System;
using static System.Console;

namespace RecursionAss5
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;

            while (true)
            {
                choice = GetMenuChoice();

                if (choice is 6)
                {
                    return;
                }

                AppOperations(choice);
            }
        }

        static int GetMenuChoice()
        {
            int choice;
            WriteLine();
            WriteLine("1. Find the factorial of a number");
            WriteLine("2. Print a number as as binary, octal, and hexadecimal");
            WriteLine("3. Find the Greatest Common Divisor of two numbers");
            WriteLine("4. Print the first n-terms of the Fibonacci series");
            WriteLine("5. Solve the Towers of Hanoi for n disks");
            WriteLine("6. Quit");
            Write("Enter your choice: ");

            while (!int.TryParse(ReadLine(), out choice) || choice < 1 || choice > 6)
            {
                WriteLine(@"That option doesn't exist!  Please try again.");
                Write("Enter your choice (1-6): ");
            }

            WriteLine();
            return choice;
        }

        static void AppOperations(int choice)
        {
            int n1, n2;

            switch (choice)
            {
                case 1:
                    Write("Enter a integer: ");
                    while (!int.TryParse(ReadLine(), out n1) || n1 < 0)
                    {
                        WriteLine("Number must be an non-negative integer.");
                        Write("Enter an non-negative integer: ");
                    }

                    WriteLine($"{n1}! is {Recursion.Factorial(n1)}.");
                    break;
                case 2:
                    Write("Enter a integer: ");
                    while (!int.TryParse(ReadLine(), out n1) || n1 < 1)
                    {
                        WriteLine("Number must be an positive integer.");
                        Write("Enter an positive integer: ");
                    }

                    WriteLine($"Your Number: {n1}");
                    Write($"In Binary: ");
                    Recursion.ConvertBase(n1, 2);
                    Write('\n');
                    Write($"In Octal: ");
                    Recursion.ConvertBase(n1, 8);
                    Write('\n');
                    Write($"In Hexadecimal: ");
                    Recursion.ConvertBase(n1, 16);
                    Write('\n');
                    break;
                case 3:
                    Write("Enter your first integer: ");
                    while (!int.TryParse(ReadLine(), out n1))
                    {
                        WriteLine("Number must be an integer.");
                        Write("Enter an integer: ");
                    }

                    Write("Enter your second integer: ");
                    while (!int.TryParse(ReadLine(), out n2))
                    {
                        WriteLine("Number must be an integer.");
                        Write("Enter an integer: ");
                    }

                    WriteLine($"The GCD of {n1} and {n2} is {Recursion.GCD(n1, n2)}.");
                    break;
                case 4:
                    Write("How many terms of the Fibonacci series would you like to see?: ");
                    while (!int.TryParse(ReadLine(), out n1) || n1 < 1)
                    {
                        WriteLine("You must choose to see at least 1 term.");
                        Write("How many terms of the Fibonacci series would you like to see?: ");
                    }

                    string printHeaderEnding = n1 is 1 ? "term is" : "terms are";
                    Write($"The first {n1} {printHeaderEnding}: ");
                    for (int i = 1; i <= n1; i++)
                    {
                        Write($"{Recursion.Fibonacci(i)}");
                        if (i != n1)
                        {
                            Write(", ");
                        }
                    }
                    break;
                case 5:
                    Write("how many disks do you want to solve for?: ");
                    while (!int.TryParse(ReadLine(), out n1) || n1 < 1)
                    {
                        WriteLine("You must choose to solve for at least 1 disk.");
                        Write("how many disks do you want to solve for?: ");
                    }

                    WriteLine();
                    Recursion.Hanoi(n1, 'A', 'B', 'C');
                    break;
            }

            WriteLine();
        }
    }
}
