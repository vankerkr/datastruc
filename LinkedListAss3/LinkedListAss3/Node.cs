using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LinkedListAss3
{
    class Node
    {
        public int info;
        public Node link;

        public Node(int i)
        {
            info = i;
            link = null;
        }
    }
}
