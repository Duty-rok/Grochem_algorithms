using System.Collections;

namespace searchInWidth
{
    class Deque:Queue
    {
        public Deque() { }
        public Deque(params object[] massive)
        {
            foreach (object obj in massive)
                Enqueue(obj);
        }
        public static Deque operator +(Deque deq1, Deque deq2)
        {
            Deque resDeq = new Deque();
            foreach (object obj in deq1)
                resDeq.Enqueue(obj);
            foreach (object obj in deq2)
                resDeq.Enqueue(obj);
            return resDeq;
        }
    }
}
