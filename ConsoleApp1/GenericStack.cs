using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinStackTest
{
    public abstract class GenericStack<T>
    {
        //Stack elements container 
        protected List<T> _elements;

        public GenericStack()
        {
            _elements = new List<T>();
        }

        //Add element onto the stack
        public abstract void push(T elt);
        
        //Remove top of the stack element
        public void pop()
        {
            if (stackEmpty())
            {
                Console.WriteLine("Stack is empty!");
                return;
            }
            _elements.RemoveAt(_elements.Count - 1);
        }

        //Return top element of the stack
        public T top()
        {
            if (stackEmpty())
            {
                Console.WriteLine("Stack is empty!");
                return default(T);
            }
            return _elements[_elements.Count - 1];
        }

        //Check if stack is empty
        public bool stackEmpty()
        {
            return _elements.Count < 1;
        }
    }
}
