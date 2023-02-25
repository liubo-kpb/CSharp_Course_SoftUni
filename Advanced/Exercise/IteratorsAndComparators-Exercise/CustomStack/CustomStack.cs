using System.Collections;

namespace CustomStack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private List<T> list;
        public CustomStack()
        {
            this.list = new List<T>();
        }
        public CustomStack(List<T> list)
        {
            this.list = list;
        }
        public T Pop()
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }

            T item = list[list.Count - 1];
            list.Remove(item);
            return item;
        }
        public void Push(T item) => list.Add(item);
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                yield return list[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
