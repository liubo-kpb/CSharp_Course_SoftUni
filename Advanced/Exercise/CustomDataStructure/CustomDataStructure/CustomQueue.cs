namespace CustomDataStructure
{
    public class CustomQueue
    {
        private const int initialCapacity = 4;
        private const int firstElementIndex = 0;
        private int[] items;

        public CustomQueue()
        {
            Queue<int> queue = new Queue<int>();
            items = new int[initialCapacity];
            Count = 0;
        }

        public int Count { get; private set; }

        public void Enqueue(int element)
        {
            if (Count == items.Length)
            {
                Resize();
            }
            items[Count++] = element;
        }
        public int Dequeue()
        {
            IsEmpty();

            int element = items[firstElementIndex];
            Shift();
            items[Count--] = default(int);
            if (Count < items.Length / 4)
            {
                Shrink();
            }
            return element;
        }
        public int Peek()
        {
            IsEmpty();
            return items[firstElementIndex];
        }
        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < Count; i++)
            {
                action(items[i]);
            }
        }
        public int Clear()
        {
            IsEmpty();
            items = new int[initialCapacity];
            int removedElements = Count;
            Count = 0;
            return removedElements;
        }
        private void Resize()

        {
            int[] copy = new int[(items.Length / 2) * 2];

            for (int i = 0; i < Count; i++)
            {
                copy[i] = items[i];
            }
            items = copy;
        }
        private void Shrink()
        {
            int[] copy = new int[items.Length / 2];
            for (int i = 0; i < Count; i++)
            {
                copy[i] = items[i];
            }
            items = copy;
        }
        private void Shift()
        {
            for (int i = firstElementIndex; i < Count - 1; i++)
            {
                items[i] = (items[i + 1]);
            }
        }
        private void IsEmpty()
        {
            if (items.Length == 0)
            {
                throw new InvalidOperationException("CustomStack is empty");
            }
        }
    }
}
