using System;
using System.Collections.Generic;

namespace GenericsExcercise
{

    public class Container<T> : IComparable<Container<T>> where T: IComparable<T>
    {
        private T element;

        public Container(T e)
        {
            this.element = e;
        }

        public T Element
        {
            get
            {
                return this.element;
            }
            set
            {
                this.element = value;
            }
        }
        public int CompareTo(Container<T> other)
        {
            return element.CompareTo(other.Element);
        }

        public override string ToString() 
        {
            return string.Format($"{typeof(T).FullName}: {element}");
        }
    }

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<Container<string>> elementsList = new List<Container<string>>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                var container = new Container<string>(input);

                elementsList.Add(container);
            }

            string elementToCompare = Console.ReadLine();

            var elementComparer = new Container<string>(elementToCompare);

            Console.WriteLine(elementToCompare.ToString());
            GenericCompare(elementsList, elementComparer);
        }

        public static int GenericCompare<T>(List<T> elementsList, T elem) where T : IComparable<T>
        {
            int count = 0;

            foreach (var item in elementsList)
            {
                var x = item.CompareTo(elem);
                if (x > 0)
                {
                    count++;
                }

            }

            return count;
        }
    }
}
