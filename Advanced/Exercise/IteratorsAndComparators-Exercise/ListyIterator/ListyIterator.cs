using System.Collections;

namespace ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private readonly List<T> collection;
        private int currentIndex;

        public ListyIterator(params T[] values)
        {
            this.collection = new List<T>(values);
            currentIndex = 0;
        }

        public bool Move()
        {
            if (currentIndex < collection.Count - 1)
            {
                currentIndex++;
                return true;
            }
            return false;
        }
        public bool HasNext() => currentIndex < collection.Count - 1;
        public void Print()
        {
            if (collection.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(collection[currentIndex]);
        }
        
        public void PrintAll()
        {
            if (collection.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            foreach (var item in collection)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        public IEnumerator<T> GetEnumerator()
        {
            yield return collection[currentIndex++];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
