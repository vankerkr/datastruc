using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace StackQueueAss4
{
    class Queue
    {
        private Node front;

        public Queue()
        {
            front = null;
        }

        public void Enqueue(int data)
        {
            Node temp = new Node(data);
            if (front is null)
            {
                front = temp;
                return;
            }

            Node p;
            for (p = front; p.link != null; p = p.link) { }

            p.link = temp;
        }

        public int Dequeue()
        {
            if (front is null)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            int valueOfDequeuedNode = front.data;
            front = front.link;
            return valueOfDequeuedNode;
        }

        public void Display()
        {
            if (front is null)
            {
                WriteLine("Queue is empty.");
                return;
            }

            Write("The queue is: ");
            for (Node p = front; p != null; p = p.link)
            {
                Write($"{p.data} ");
            }
        }

    }
}
