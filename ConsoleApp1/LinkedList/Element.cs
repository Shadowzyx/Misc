using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.LinkedList
{
    [Serializable]
    class Element
    {
        public int item { get; set; }
        public Element next { get; set; }

        public Element(int item, Element next)
        {
            this.item = item;
            this.next = next;
        }

        public Element(int item) : this(item, null)
        {
        }

        public override string ToString()
        {
            return "item : " + item;
        }

        public override bool Equals(object obj)
        {
            var elt = obj as Element;
            if (elt == null)
                return false;

            return elt.item == this.item;
        }
    }
}
