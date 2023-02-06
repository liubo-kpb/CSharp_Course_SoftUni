namespace BoxOfT
{
    public class Box<T>
    {
        private const int initialCapacity = 4;
        private T[] array;
        public Box()
        {
            array = new T[initialCapacity];
        }

        public int Count { get; private set; }
        public void Add(T item)
        {
            if (Count == array.Length)
            {
                Resize();
            }
            array[Count++] = item;
        }
        public T Remove()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Box is empty!");
            }
            T lastElement = array[Count - 1];
            array[--Count] = default(T);
            if (Count < array.Length / 4)
            {
                Shrink();
            }
            return lastElement;
        }
        private void Resize()
        {
            T[] copy = new T[array.Length * 2];

            for (int i = 0; i < Count; i++)
            {
                copy[i] = array[i];
            }
            array = copy;
        }
        private void Shrink()
        {
            T[] copy = new T[array.Length / 2];
            for (int i = 0; i < Count; i++)
            {
                copy[i] = array[i];
            }
            array = copy;
        }
    }
}
