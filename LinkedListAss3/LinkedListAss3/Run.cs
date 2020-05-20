using System;
using static System.Console;

namespace LinkedListAss3
{
    class Run
    {
        

        public Run()
        {
            int choice, data, position;

            SingleLinkedList list = new SingleLinkedList();

            list.CreateList();
            list.Display();

            while (true)
            {
                WriteLine("1. Display List");
                WriteLine("2. Insert in empty list/insert in beginning");
                WriteLine("3. Insert a node at the end of the list"); ;
                WriteLine("4. Insert a node at a given position");
                WriteLine("5. Delete first node");
                WriteLine("6. Delete last node");
                WriteLine("7. Delete node at a given position");
                WriteLine("8. Reverse list");
                WriteLine("9. Bubble sort by exchanging data");
                WriteLine("10. Bubble sort by exchanging links");
                WriteLine("11. Insert cycle");
                WriteLine("12. Detect cycle");
                WriteLine("13. Remove cycle");
                WriteLine("14. Quit");
                WriteLine();
                Write("What is your selection?: ");
                while (!int.TryParse(ReadLine(), out choice) || choice < 1 || choice > 14)
                {
                    WriteLine("Invaild!  Selection must be between 1 to 14.");
                    Write("What would you like to do?: ");
                }

                if (choice is 14)
                {
                    return;
                }

                switch (choice)
                {
                    case 1:
                        list.Display();
                        break;
                    case 2:
                        Write("Enter value of node to be inserted: ");
                        while (!int.TryParse(ReadLine(), out data))
                        {
                            WriteLine("Value must be an integer!\n");
                            Write("Enter the value of the node to be inserted: ");
                        }

                        list.InsertAtBeginning(data);
                        break;
                    case 3:
                        Write("Enter value node to be inserted: ");
                        while (!int.TryParse(ReadLine(), out data))
                        {
                            WriteLine("Value must be an integer!\n");
                            Write("Enter the value of the node to be inserted: ");
                        }

                        list.InsertAtEnd(data);
                        break;
                    case 4:
                        Write("Enter the value of node to be inserted: ");
                        while (!int.TryParse(ReadLine(), out data))
                        {
                            WriteLine("Value must be an integer!\n");
                            Write("Enter the value of the node to be inserted: ");
                        }

                        Write("Enter the position where the node is to be inserted at: ");
                        while (!int.TryParse(ReadLine(), out position))
                        {
                            WriteLine("Value must be an integer!\n");
                            Write("Enter the position where the node is to be inserted at: ");
                        }

                        list.InsertAtPosition(data, position);
                        break;
                    case 5:
                        try
                        {
                            data = list.DeleteFirstNode();
                            WriteLine($"Value of deleted node was {data}.");
                        }
                        catch (InvalidOperationException ex)
                        {
                            WriteLine(ex.Message);
                        }
                        break;
                    case 6:
                        try
                        {
                            data = list.DeleteLastNode();
                            WriteLine($"Value of deleted node was {data}.");
                        }
                        catch (InvalidOperationException ex)
                        {
                            WriteLine(ex.Message);
                        }
                        break;
                    case 7:
                        try
                        {
                            Write("Enter the position where the node to be deleted is at: ");
                            while (!int.TryParse(ReadLine(), out position))
                            {
                                WriteLine("Value must be an integer!\n");
                                Write("Enter position where the node to be deleted is at: ");
                            }

                            data = list.DeleteNodeAtPosition(position);
                            WriteLine($"Value of the node deleted was {data}.");
                        }
                        catch (InvalidOperationException ex)
                        {
                            WriteLine(ex.Message);
                        }
                        break;
                    case 8:
                        list.ReverseList();
                        break;
                    case 9:
                        list.BubbleSortByData();
                        break;
                    case 10:
                        list.BubbleSortByLinks();
                        break;
                    case 11:
                        Write("Enter the value where a cycle should be inserted: ");

                        while (!int.TryParse(ReadLine(), out data))
                        {
                            WriteLine("Value must be an integer!\n");
                            Write("Enter value where a cycle should be inserted: ");
                        }

                        list.InsertCycle(data);
                        break;
                    case 12:
                        if (list.HasCycle())
                        {
                            WriteLine("Current list has a cycle.\n");
                        }
                        else
                        {
                            WriteLine("Current list doesn\'t have a cycle.\n");
                        }
                        break;
                    case 13:
                        list.RemoveCycle();
                        break;
                }

                WriteLine();
                WriteLine();
            }


        }

    }
}
