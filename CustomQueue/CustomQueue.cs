namespace CustomQueues
{
    internal class CustomQueue
    {
        private const int InitialCapacity = 4;
        private const int FirstElementIndex = 0;
        private int[] items;

        public CustomQueue()
        {
            items = new int[InitialCapacity];
        }
        public int Count { get; private set; }

        public void Enqueue(int item)
        {
            if (items.Length == Count)
            {
                Resize();
            }

            items[Count] = item;
            Count++;
        }

        public int Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("CustomQueue is empty!");
            }

            int removedItem = items[FirstElementIndex];

            ShiftLeft();
            // if needed SHRINK 

            return removedItem;
        }

        public int Peek(int item)
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("CustomQueue is empty!");
            }

            return items[Count - 1];
        }

        public void Clear()
        {
            items = new int[InitialCapacity];
            Count = 0;
        }

        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < Count; i++)
            {
                int currentItem = items[i];
                action(currentItem);
            }
        }

        private void Resize()
        {
            int[] copy = new int[items.Length * 2];

            for (int i = 0; i < Count; i++)
            {
                copy[i] = items[i];
            }

            items = copy;
        }
        private void ShiftLeft()
        {
            for (int i = FirstElementIndex; i < Count - 1; i++)
            {
                items[i] = items[i + 1];
            }

            items[Count - 1] = default; // only for debugging 
        }

    }
}
