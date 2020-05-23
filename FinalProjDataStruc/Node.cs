using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjDataStruc
{
    class Node
    {
        public string Name;
        public long PhoneNumber;
        public long YearsKnown;

        public Node link;

        public Node(String name, long phoneNumber, long yearsKnown)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            YearsKnown = yearsKnown;
            link = null;
        }
    }
}
