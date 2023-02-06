namespace CustomDataStructure
{
    public class CustomList
    {
        private const int initialCapacity = 2;
        private int[] items;

        public CustomList()
        {
            items = new int[initialCapacity];
        }

        public CustomList(int[] items)
        {
            this.items = items;
            Count = items.Length;
            Resize();
        }

        public int Count { get; private set; }

        public int this[int index]
        {
            get
            {
                if (index >= Count || index < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return items[index];
            }
            set
            {
                if (index >= Count || index < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                items[index] = value;
            }
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
        public void Add(int element)
        {
            if (Count == items.Length)
            {
                Resize();
            }
            items[Count++] = element;
        }
        public int RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            int deletedElement = items[index];
            items[index] = default(int);
            Shift(index);
            Count--;
            if (items.Length / 4 > Count)
            {
                Shrink();
            }

            return deletedElement;
        }

        public int Remove()
        {
            if (items.Length == 0)
            {
                throw new InvalidOperationException("CustomList is empty");
            }

            int element = items[--Count];
            items[Count] = default(int);
            if (Count < items.Length / 4)
            {
                Shrink();
            }
            return element;
        }
        private void Shift(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                items[i] = (items[i + 1]);
            }
        }
        private void ShiftToTheRIght(int index)
        {
            for (int i = Count; i > index; i--)
            {
                items[i] = items[i - 1];
            }
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
        public void Insert(int index, int element)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (Count == items.Length)
            {
                Resize();
            }
            ShiftToTheRIght(index);
            items[index] = element;
            Count++;
        }
        public bool Contains(int element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i] == element)
                {
                    return true;
                }
            }
            return false;
        }
        public void Swap(int index1, int index2)
        {
            if (index1 < 0 || index2 < 0 || index1 >= Count || index2 >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            int temp = items[index1];
            items[index1] = items[index2];
            items[index2] = temp;
        }
        public void Reverse()
        {
            int[] copy = new int[items.Length];
            int copyIndex = 0;
            for (int i = Count - 1; i >= 0; i--)
            {
                copy[copyIndex++] = items[i];
            }
            items = copy;
        }
        public override string ToString()
        {
            return string.Join(' ', items);
        }
    }
}
