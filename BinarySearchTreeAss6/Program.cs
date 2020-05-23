using System;
using static System.Console;

namespace BinarySearchTreeAss6
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Binary Search Tree\n");
            int choice;
            BinaryTree binaryTree = new BinaryTree();

            binaryTree.Insert(15);
            binaryTree.Insert(47);
            binaryTree.Insert(13);
            binaryTree.Insert(22);
            binaryTree.Insert(43);
            binaryTree.Insert(65);

            WriteLine("Current Tree:");
            binaryTree.InOrderTraversal();


            while (true)
            {
                choice = GetMenuChoice();

                if (choice is 4)
                {
                    break;
                }

                ProcessChoice(binaryTree, choice);
            }

        }

        static int GetMenuChoice()
        {
            int choice;
            WriteLine("\nBinary Search Tree Options");

            WriteLine("1.Add node");
            WriteLine("2.Delete node");
            WriteLine("3.Show Tree");
            WriteLine("4. Quit");
            Write("Enter your choice: ");

            while (!int.TryParse(ReadLine(), out choice) || choice < 1 || choice > 4)
            {
                WriteLine(@"That doesn't exist.");
                Write("Enter your choice (1-4): ");
            }

            WriteLine();
            return choice;
        }

        static void ProcessChoice(BinaryTree Tree, int theChoice)
        {
            int key;

            switch (theChoice)
            {
                case 1: //Add integer to search tree
                    Write("Enter a number to add to the search tree: ");

                    while (!int.TryParse(ReadLine(), out key))
                    {
                        WriteLine("Number entered must be a whole number.  Please try again");
                        Write("Enter a number to add tree: ");
                    }

                    Tree.Insert(key);
                    break;
                case 2: //Delete integer to search tree
                    Write("Enter a number to delete from the search tree: ");

                    while (!int.TryParse(ReadLine(), out key))
                    {
                        WriteLine("Number entered must be a whole number.  Please try again");
                        Write("Enter a number to delete from the search tree: ");
                    }

                    Tree.Remove(key);
                    break;
                case 3: //Display the search tree
                    Tree.InOrderTraversal();
                    break;
                default:
                    WriteLine(@"That did not work.");
                    break;
            }

            WriteLine();
        }
    }
}
