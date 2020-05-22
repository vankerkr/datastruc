using System;
using static System.Console;


namespace StackQueueAss4
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack theStack = new Stack();
            Queue theQueue = new Queue();
            int choice;

            while (true)
            {
                choice = GetOptionChoice();

                if (choice is 7)
                {
                    return;
                }

                AppOperations(theStack, theQueue, choice);
            }
        }

        static int GetOptionChoice()
        {
            int choice;
            WriteLine("\n1. Add an element to the stack.");
            WriteLine("2. Remove an element from the stack.");
            WriteLine("3. Display the stack.");
            WriteLine("4. Add an element to the queue.");
            WriteLine("5. Remove an element from the queue.");
            WriteLine("6. Display the queue.");
            WriteLine("7. Quit");
            Write("Enter your choice: ");

            while (!int.TryParse(ReadLine(), out choice) || choice < 1 || choice > 7)
            {
                WriteLine(@"That option doesn't exist!  Please try again.");
                Write("Enter your choice: ");
            }

            WriteLine();
            return choice;
        }

        static void AppOperations(Stack stack, Queue queue, int choice)
        {
            int data;
            switch (choice)
            {
                case 1: //Add an element to the stack
                    Write("Enter an integer to add to the stack: ");

                    if (!int.TryParse(ReadLine(), out data))
                    {
                        WriteLine("Value entered must be an integer.");
                        Write("Enter an integer to add to the stack: ");
                    }

                    stack.Push(data);
                    WriteLine($"{data} was added to the stack.");
                    break;
                case 2: //Remove an element from the stack
                    try
                    {
                        WriteLine($"The value of the element removed is {stack.Pop()}.");
                    }
                    catch (InvalidOperationException ex)
                    {
                        WriteLine(ex.Message);
                    }
                    break;
                case 3: //Display the stack
                    stack.Display();
                    break;
                case 4: //Add an element to the queue
                    Write("Enter an integer to add to the queue: ");

                    if (!int.TryParse(ReadLine(), out data))
                    {
                        WriteLine("Value entered must be an integer.");
                        Write("Enter an integer to add to the queue: ");
                    }

                    queue.Enqueue(data);
                    WriteLine($"{data} was added to the queue.");
                    break;
                case 5: //Remove an element from the queue
                    try
                    {
                        WriteLine($"The value of the element removed is {queue.Dequeue()}.");
                    }
                    catch (InvalidOperationException ex)
                    {
                        WriteLine(ex.Message);
                    }
                    break;
                case 6: //Display the queue
                    queue.Display();
                    break;
            }
            WriteLine();
        }
    }
}
