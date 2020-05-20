using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace LinkedListAss3
{
    class SingleLinkedList
    {
        public Node start;

        public SingleLinkedList()
        {
            start = null;
        }

        public void CreateList()
        {
            int i, n, data;

            Write("Enter the number of nodes: ");

            while (!int.TryParse(ReadLine(), out n) || n < 0)
            {
                WriteLine("Value entered must be an non-negative integer.");
                Write("Enter the number of nodes: ");
            }

            if (n == 0)
                return;

            for (i = 0; i < n; i++)
            {
                Write("Enter the element to be inserted: ");
                while (!int.TryParse(ReadLine(), out data))
                {
                    WriteLine("Value entered must be an integer.");
                    Write("Enter the element to be inserted: ");
                } 

                InsertAtEnd(data);
            }
        }

        public bool IsEmpty()
        {
            return start is null;
        }

        public int Size()
        {
            if(IsEmpty())
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
            if(IsEmpty())
            {
                WriteLine("The list is empty.");
                return;
            }

            Write("The list is: ");
            for(Node p = start; p != null; p = p.link)
            {
                Write($"{p.info} ");
            }
            WriteLine();
        }

        public void InsertAtBeginning(int info)
        {
            Node temp = new Node(info);
            
            if(!IsEmpty())
            {
                temp.link = start;
            }

            start = temp;
        }

        public void InsertAtEnd(int info)
        {
            if(IsEmpty())
            {
                InsertAtBeginning(info);
                return;
            }

            Node p;
            for (p = start; p.link != null; p = p.link) { }

            p.link = new Node(info);
        }

        public void InsertAtPosition(int info, int position)
        {
            int highestPosition = Size() + 1;
            if(position < 1 || position > highestPosition)
            {
                WriteLine($"Can\'t insert at position {position}.  Position value must be from 1 to {highestPosition}.");
                return;
            }
            
            if(position is 1)
            {
                InsertAtBeginning(info);
            }
            else if(position == highestPosition)
            {
                InsertAtEnd(info);
            }
            else
            {
                Node p = start,
                     temp = new Node(info);

                for(int i = 1; i < position-1; i++)
                {
                    p = p.link;
                }

                temp.link = p.link;
                p.link = temp;
            }
        }

        public int DeleteFirstNode()
        {
            if(IsEmpty())
            {
                throw new InvalidOperationException(@"Can't delete from an empty list");
            }

            int valueOfDeletedNode = start.info;

            if(Size() is 1)
            {
                start = null;
            }
            else
            {
                start = start.link;
            }

            return valueOfDeletedNode;
        }

        public int DeleteLastNode()
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

            int valueOfDeletedNode = p.link.info;
            p.link = null;
            return valueOfDeletedNode;
        }

        public int DeleteNodeAtPosition(int position)
        {
            if(IsEmpty())
            {
                throw new InvalidOperationException(@"Can't delete from an empty list.");
            }

            int highestPosition = Size();
            if(position < 1 || position > highestPosition)
            {
                throw new InvalidOperationException($"Position {position} doesn\'t exist in the list.  Position value must be from 1 to {highestPosition}.");
            }

            if(position is 1)
            {
                return DeleteFirstNode();
            }

            if(position == highestPosition)
            {
                return DeleteLastNode();
            }

            Node p = start;
            for(int i = 1; i < position-1; i++)
            {
                p = p.link;
            }

            int valueOfDeletedNode = p.link.info;
            p.link = p.link.link;
            return valueOfDeletedNode;
        }

        public void ReverseList()
        {
            if(IsEmpty())
            {
                WriteLine(@"Can't reverse a empty list.");
                return;
            }

            //Check to see if there's more than one node in the list.
            if (start.link is null)
            {
                return;
            }

            Node previous = null,
                 current = start,
                 next;

            while (current != null) //While there's still nodes to reverse
            {
                next = current.link;     //Identifies the next node to reverse
                current.link = previous; //Points link to node before it originally
                previous = current;      //Moves one step deeper into list for new position of previous
                current = next;          //Moves one step deeper into list for new position of next
            }

            start = previous; //Previous is the former end of the list. Now, become the start of the list.
        }

        public void BubbleSortByData()
        {
            if(IsEmpty())
            {
                WriteLine(@"List is empty");
                return;
            }

            Node end, p, q;

            for (end = null; end != start.link; end = p)
            {
                for (p = start; p.link != end; p = p.link)
                {
                    q = p.link;
                    if (p.info > q.info)
                    {
                        int temp = p.info;
                        p.info = q.info;
                        q.info = temp;
                    }
                }
            }
        }

        public void BubbleSortByLinks()
        {
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
                    if (p.info > q.info)
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

        public bool HasCycle()
        {
            if (FindCycle() is null)
            {
                return false;
            }

            return true;
        }

        private Node FindCycle()
        {
            if (start is null || start.link is null)
            {
                return null;
            }

            Node slowR = start,
                 fastR = start;

            while (fastR != null || fastR.link != null)
            {
                slowR = slowR.link;
                fastR = fastR.link.link;

                if (slowR == fastR)
                {
                    return slowR;
                }
            }

            return null;
        }

        public void RemoveCycle()
        {
            Node c = FindCycle();

            if (c is null)
            {
                return;
            }

            WriteLine($"Value of the node at which the cycle was detected is {c.info}");

            Node p = c,
                 q = c;

            int lenCycle = 0;

            do
            {
                lenCycle++;
                q = q.link;
            } while (p != q);

            WriteLine($"Length of cycle is {lenCycle}");

            int lenRemList;
            p = start;

            for (lenRemList = 0; p != q; lenRemList++)
            {
                p = p.link;
                q = q.link;
            }

            WriteLine($"Number of nodes not included in the cycle are {lenRemList}");

            int lengthList = lenCycle + lenRemList;
            WriteLine($"Length of the list is {lengthList}");

            p = start;
            for (int i = 1; i <= lengthList - 1; i++)
            {
                p = p.link;
            }

            p.link = null;
        }

        public void InsertCycle(int x)
        {
            if (start is null)
            {
                WriteLine(@"Can't insert a cycle on a empty list.");
                return;
            }

            Node p,
                 px = null,
                 prev = null;

            for(p = start; p != null; p = p.link)
            {
                if (p.info == x)
                {
                    px = p;
                }

                prev = p;
            }

            if (px != null)
            {
                prev.link = px;
            }
            else
            {
                WriteLine($"{x} is not present in the list.");
            }
        }
    }
}
