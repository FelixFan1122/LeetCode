namespace LeetCode
{
    public class Deque<T>
    {
        private T[] deque;
        private int front = 0;
        private int rear = -1;
        public Deque(int capacity)
        {
            deque = new T[capacity];
        }

        public bool IsEmpty
        {
            get
            {
                return Size == 0;
            }

        }

        public int Size
        {
            get
            {
                return (rear - front + 1 + deque.Length) % deque.Length;
            }
        }

        public void AddRear(T element)
        {
            rear = (rear + 1) % deque.Length;
            deque[rear] = element;
        }

        public T PeekFront()
        {
            return deque[front];
        }

        public T PeekRear()
        {
            return deque[rear];
        }

        public void RemoveFront()
        {
            front = (front + 1) % deque.Length;
        }

        public void RemoveRear()
        {
            rear = rear == 0 ? deque.Length - 1 : rear - 1;
        }
    }
}