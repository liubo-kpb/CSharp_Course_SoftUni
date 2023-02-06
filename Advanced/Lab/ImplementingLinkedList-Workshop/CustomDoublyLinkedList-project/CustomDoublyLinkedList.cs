namespace CustomDoublyLinkedList
{
    public class CustomDoublyLinkedList
    {
        private class ListNode
        {
            public ListNode(int value) => Value = value;
            public int Value { get; set; }
            public ListNode NextNode { get; set; }
            public ListNode PrevioustNode { get; set; }
        }
        private ListNode head;
        private ListNode tail;
        public int Count { get; private set; }

        public void AddFirst(int element)
        {
            if (Count == 0)
            {
                head = tail = new ListNode(element);
            }
            else
            {
                var newHead = new ListNode(element);
                newHead.NextNode = head;
                head.PrevioustNode = newHead;
                head = newHead;
            }
            Count++;
        }

        public void AddLast(int element)
        {
            if (Count == 0)
            {
                head = tail = new ListNode(element);
            }
            else
            {
                var newTail = new ListNode(element);
                newTail.NextNode = tail;
                tail.PrevioustNode = newTail;
                tail = newTail;
            }
            Count++;
        }

        public int RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            var firstElement = head.Value;
            head = head.NextNode;
            if (head != null)
            {
                head.PrevioustNode = null;
            }
            else
            {
                tail = null;
            }
            Count--;

            return firstElement;
        }

        public int RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            var lastElement = tail.Value;

            tail = tail.PrevioustNode;
            if (tail != null)
            {
                tail.NextNode = null;
            }
            else
            {
                head = null;
            }
            Count--;

            return lastElement;
        }

        public void ForEach(Action<int> action)
        {
            var currentNode = head;
            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public int[] ToArray()
        {
            int[] array = new int[Count];
            var currentNode = head;
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = currentNode.Value;
                currentNode = currentNode.NextNode;
            }

            return array;
        }
    }
}
