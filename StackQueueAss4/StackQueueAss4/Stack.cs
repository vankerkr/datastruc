using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace StackQueueAss4
{
    class Stack
    {
        private Node top;

        public Stack()
        {
            top = null;
        }

        public void Push(int data)
        {
            Node temp = new Node(data);
            temp.link = top;
            top = temp;
        }

        public int Pop()
        {
            if (top is null)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            int valueOfPoppedNode = top.data;
            top = top.link;
            return valueOfPoppedNode;
        }

        public void Display()
        {
            if (top is null)
            {
                WriteLine("Stack is empty.");
                return;
            }

            WriteLine("The stack is:");
            WriteLine("==============");
            for (Node p = top; p != null; p = p.link)
            {
                WriteLine(p.data);
            }
        }
    }
}
