using System;

namespace GenericBoxOfString
{
    public class Box<T> where T : IComparable
    {
        private const int initialSize = 4;

        public Box()
        {
            this.Items = new List<T>();
        }
        public List<T> Items { get; private set; }
        public int Count(T element)
        {
            int biggerElements = 0;
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].CompareTo(element) > 0)
                {
                    biggerElements++;
                }
            }

            return biggerElements;
        }
        public override string ToString() => $"{typeof(T)}: {Items}";
    }
}
