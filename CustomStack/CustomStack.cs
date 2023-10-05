namespace CustomStacks
{
    internal class CustomStack
    {
        private const int InitialCapacity = 4;
        private int[] items;

        public CustomStack()
        {
            items = new int[InitialCapacity];
        }

        public int Count { get; private set; }

        public void Push(int item)
        {
            if (items.Length == Count)
            {
                Resize();
            }

            items[Count] = item;
        }

        public int Pop(int item)
        {
            if (Count < 0)
            {
                ThrowExceptionIfStackIsEmpty(item);
            }

            int removedItem = items[Count - 1];
            items[Count - 1] = default; //- default for integer is 0 -// 
            Count--;

            //TODO Shrink if needed !!!! 

            return removedItem;
        }

        public int Peek(int item)
        {
            if (Count < 0)
            {
                ThrowExceptionIfStackIsEmpty(item);
            }

            return items[Count - 1];
        }

        public void ForEach(Action<int> action)
        {
            //for (int i = 0; i < Count; i++)
            //{
            //    int currentItem = items[i];
            //    action(currentItem);
            //}

            for (int i = Count - 1; i >= 0; i--)
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

        private void ThrowExceptionIfStackIsEmpty(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("CustomStack is empty");
            }
        }
    }
}
