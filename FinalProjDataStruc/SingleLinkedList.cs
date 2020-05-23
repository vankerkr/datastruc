using System;
using System.Collections.Generic;
using static System.Console;
using System.Text;

namespace FinalProjDataStruc
{
    class SingleLinkedList
    {

        public Node start;
        public string Name;
        public long PhoneNumber;
        public long YearsKnown;


        public SingleLinkedList()
        {
            start = null;
        }

        public void CreateList()
        {
            int i, n;

            Write("Enter the number of contacts: ");

            while (!int.TryParse(ReadLine(), out n) || n < 0)
            {
                WriteLine("Value entered must be an non-negative integer.");
                Write("Enter the number of nodes: ");
            }

            if (n == 0)
                return;

            for (i = 0; i < n; i++)
            {
                WriteLine("Contact " + (i + 1) + ": ");
                WriteLine("Enter the Name: ");
                Name = ReadLine();
                WriteLine("Enter the Phone Number: ");
                PhoneNumber = Convert.ToInt64(ReadLine());
                WriteLine("Enter the Years Known: ");
                YearsKnown = Convert.ToInt64(ReadLine());

                InsertAtEnd(Name, PhoneNumber,YearsKnown);
            }
        }

        public bool IsEmpty()
        {
            return start is null;
        }

        public int Size()
        {
            if (IsEmpty())
            {
                return 0;
            }

            Node p = start.link;
            int size;

            for (size = 1; p != null; p = p.link)
            {
                size++;
            }

            return size;
        }

        public void Display()
        {
            int i = 1;
            if (IsEmpty())
            {
                WriteLine("The list is empty.");
                return;
            }

            WriteLine("The Contact List is: ");
            WriteLine("Name\t\t\tPhone Number\tYears Known");
            for (Node p = start; p != null; p = p.link)
            {
                WriteLine("#" + i + " " + p.Name + "\t\t\t\t" + p.PhoneNumber + "\t" + p.YearsKnown);
                i++;
            }
            WriteLine();
        }

        public void InsertAtBeginning(String name, long phoneNumber, long yearsKnown)
        {
            Node temp = new Node(name, phoneNumber, yearsKnown);

            if (!IsEmpty())
            {
                temp.link = start;
            }

            start = temp;
        }

        public void InsertAtEnd(String name, long phoneNumber, long yearsKnown)
        {
            if (IsEmpty())
            {
                InsertAtBeginning(name, phoneNumber, yearsKnown);
                return;
            }

            Node p;
            for (p = start; p.link != null; p = p.link) { }

            p.link = new Node(name, phoneNumber, yearsKnown);
        }

        public void InsertAtPosition(String name, long phoneNumber, long yearsKnown, int position)
        {
            int highestPosition = Size() + 1;
            if (position < 1 || position > highestPosition)
            {
                WriteLine($"Can\'t insert at position {position}.  Position value must be from 1 to {highestPosition}.");
                return;
            }

            if (position is 1)
            {
                InsertAtBeginning(name, phoneNumber, yearsKnown);
            }
            else if (position == highestPosition)
            {
                InsertAtEnd(name, phoneNumber, yearsKnown);
            }
            else
            {
                Node p = start,
                     temp = new Node(name, phoneNumber, yearsKnown);

                for (int i = 1; i < position - 1; i++)
                {
                    p = p.link;
                }

                temp.link = p.link;
                p.link = temp;
            }
        }

        public string DeleteFirstNode()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException(@"Can't delete from an empty list");
            }

            String nameOfDeletedContact = start.Name;

            if (Size() is 1)
            {
                start = null;
            }
            else
            {
                start = start.link;
            }

            return nameOfDeletedContact;
        }

        public String DeleteLastNode()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException(@"Can't delete from an empty list");
            }

            if (Size() is 1)
            {
                return DeleteFirstNode();
            }

            Node p;

            for (p = start; p.link.link != null; p = p.link) { }

            String nameOfDeletedContact = p.link.Name;
            p.link = null;
            return nameOfDeletedContact;
        }

        public String DeleteNodeAtPosition(int position)
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException(@"Can't delete from an empty list.");
            }

            int highestPosition = Size();
            if (position < 1 || position > highestPosition)
            {
                throw new InvalidOperationException($"Position {position} doesn\'t exist in the list.  Position value must be from 1 to {highestPosition}.");
            }

            if (position is 1)
            {
                return DeleteFirstNode();
            }

            if (position == highestPosition)
            {
                return DeleteLastNode();
            }

            Node p = start;
            for (int i = 1; i < position - 1; i++)
            {
                p = p.link;
            }

            String nameOfDeletedContact = p.link.Name;
            p.link = null;
            return nameOfDeletedContact;
        }

        public void BubbleSortByLinks()
        {
            char pchar;
            char qchar;
            if (IsEmpty())
            {
                WriteLine(@"Can't sort a empty list.");
                return;
            }

            Node end, r, p, q, temp;

            for (end = null; end != start.link; end = p)
            {
                for (r = p = start; p.link != end; r = p, p = p.link)
                {
                    q = p.link;

                    pchar = p.Name[0];
                    qchar = q.Name[0];
                    if (pchar > qchar)
                    {
                        p.link = q.link;
                        q.link = p;

                        if (p != start)
                        {
                            r.link = q;
                        }
                        else
                        {
                            start = q;
                        }

                        temp = p;
                        p = q;
                        q = temp;
                    }
                }
            }
        }
    }
}
