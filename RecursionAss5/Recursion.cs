using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace RecursionAss5
{
    class Recursion
    {
        public static int Factorial(int n)
        {
            if (n < 2)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }

        public static void ConvertBase(int n, int b)
        {
            if (n is 0)
            {
                return;
            }

            ConvertBase(n / b, b);
            int remainder = n % b;

            if (remainder < 10)
            {
                Write(remainder);
            }
            else
            {
                Write((char)(remainder - 10 + 'A'));
            }
        }

        public static int GCD(int a, int b)
        {
            if (b is 0)
            {
                return a;
            }

            return GCD(b, a % b);
        }

        public static int Fibonacci(int n)
        {
            if (n is 0 || n is 1)
            {
                return n;
            }

            return Fibonacci(n - 2) + Fibonacci(n - 1);
        }

        public static void Hanoi(int disks, char source, char temp, char dest)
        {
            if (disks is 1)
            {
                WriteLine($"Move disk {disks} from {source} to {dest}.");
                return;
            }

            Hanoi(disks - 1, source, dest, temp);
            WriteLine($"Move disk {disks} from {source} to {dest}.");
            Hanoi(disks - 1, temp, source, dest);
        }
    }
}
