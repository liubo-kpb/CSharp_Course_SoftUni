namespace CustomDataStructure
{
    public class CustomStack
    {
        private const int initialCapacity = 4;
        private int[] items;

        public CustomStack()
        {
            items = new int[initialCapacity];
            Count = 0;
        }

        public int Count { get; private set; }

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
        public void Push(int element)
        {
            if (Count == items.Length)
            {
                Resize();
            }
            items[Count++] = element;
        }
        public int Pop()
        {
            if(items.Length == 0)
            {
                throw new InvalidOperationException("CustomStack is empty");
            }

            int element = items[--Count];
            items[Count] = default(int);
            if (Count < items.Length / 4)
            {
                Shrink();
            }
            return element;
        }
        public int Peek()
        {
            if (items.Length == 0)
            {
                throw new InvalidOperationException("CustomStack is empty!");
            }
            return items[Count - 1];
        }
        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < Count; i++)
            {
                action(items[i]);
            }
        }
    }
}
