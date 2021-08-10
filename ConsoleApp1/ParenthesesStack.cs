using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinStackTest
{
    public class ParenthesesStack : GenericStack<char>
    {
        //Maximum size of stack: Size = 10^4
        private const int MaxStackSize = 10000;

        public ParenthesesStack(): base()
        {}

        public override void push(char elt)
        {
            if (_elements.Count <= MaxStackSize)
            {
               _elements.Add(elt);                    
            }
            else
            {
               Console.WriteLine("Stack is full!!");
            }
        }
    }
}
