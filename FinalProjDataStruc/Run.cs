using System;
using static System.Console;
using System.Collections.Generic;
using System.Text;

namespace FinalProjDataStruc
{
    class Run
    {
        public Run()
        {
            int choice, position;
            String data;
            String newName;
            long newNumber;
            long newYears;

            SingleLinkedList list = new SingleLinkedList();

            list.CreateList();
            list.Display();

            while (true)
            {
                newName = null;
                newNumber = 0;
                newYears = 0;



                WriteLine("1. Display List");
                WriteLine("2. Insert in empty list/insert in beginning");
                WriteLine("3. Insert a contact at the end of the list"); ;
                WriteLine("4. Insert a contact at a given position");
                WriteLine("5. Delete first contact");
                WriteLine("6. Delete last contact");
                WriteLine("7. Delete contact at a given position");
                WriteLine("8. Sort by name");
                WriteLine("9. Quit");
                WriteLine();
                Write("What is your selection?: ");
                while (!int.TryParse(ReadLine(), out choice) || choice < 1 || choice > 14)
                {
                    WriteLine("Invaild!  Selection must be between 1 to 14.");
                    Write("What would you like to do?: ");
                }

                if (choice is 9)
                {
                    return;
                }

                switch (choice)
                {
                    case 1:
                        list.Display();
                        break;
                    case 2:
                        WriteLine("Enter the Name: ");
                        newName = ReadLine();
                        WriteLine("Enter the Phone Number: ");
                        newNumber = Convert.ToInt64(ReadLine());
                        WriteLine("Enter the Years Known: ");
                        newYears = Convert.ToInt64(ReadLine());

                        list.InsertAtBeginning(newName, newNumber, newYears);
                        break;
                    case 3:
                        WriteLine("Enter the Name: ");
                        newName = ReadLine();
                        WriteLine("Enter the Phone Number: ");
                        newNumber = Convert.ToInt64(ReadLine());
                        WriteLine("Enter the Years Known: ");
                        newYears = Convert.ToInt64(ReadLine());

                        list.InsertAtEnd(newName, newNumber, newYears);
                        break;
                    case 4:
                        Write("Enter the position where the contact is to be inserted at: ");
                        while (!int.TryParse(ReadLine(), out position))
                        {
                            WriteLine("Value must be an integer!\n");
                            Write("Enter the position where the contact is to be inserted at: ");
                        }

                        WriteLine("Enter the Name: ");
                        newName = ReadLine();
                        WriteLine("Enter the Phone Number: ");
                        newNumber = Convert.ToInt64(ReadLine());
                        WriteLine("Enter the Years Known: ");
                        newYears = Convert.ToInt64(ReadLine());

                        list.InsertAtPosition(newName,newNumber,newYears,position);
                        break;

                    case 5:
                        try
                        {
                            data = list.DeleteFirstNode();
                            WriteLine($"Name of the deleted contact was {data}.");
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
                            WriteLine($"Name of the deleted contact was {data}.");
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
                            WriteLine($"Name of the deleted contact deleted was {data}.");
                        }
                        catch (InvalidOperationException ex)
                        {
                            WriteLine(ex.Message);
                        }
                        break;
                    case 8:
                        list.BubbleSortByLinks();
                        break;
                }

                WriteLine();
                WriteLine();
            }


        }
    }
}
