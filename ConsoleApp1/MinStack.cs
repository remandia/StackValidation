using System;
using System.Collections.Generic;
using System.Linq;

namespace MinStackTest
{
    public class MinStack: GenericStack<int>
    { 
        //Maximum size for stack element value
        private const int MaxElementSize = int.MaxValue;

        //Maximum size for stack element value
        private const int MinElementSize = int.MinValue;

        //Maximum size of stack: Size = 3*10^4
        private const int MaxStackSize = 30000;
                
        //Current minimum value in the stack
        private int minValue;       
        
        public MinStack(): base()
        {}

        public override void push(int elt)
        {
            if (elt >= MinElementSize && elt <= MaxElementSize)
            {
                if (_elements.Count < MaxStackSize)
                {
                    _elements.Add(elt);
                    if (elt <= minValue) minValue = elt;
                }
                else
                {
                    Console.WriteLine("Stack is full!!");
                }
            }
            else
            {
                Console.WriteLine("Input value out of bounds: " + elt);
            }        
        }

        //Get min value in the stack
        public int getMin()
        {
            if (stackEmpty())
            {
                Console.WriteLine("Stack is empty!");
               return default(int);
            }
            return _elements.AsQueryable().Min();
        }

    }
}
