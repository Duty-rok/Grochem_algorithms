using System.Collections.Generic;
using static System.Console;

namespace recursion_binary_search
{
    class Program
    {
        static int binary_search(List<int> lst, int item)
        {
            if(lst.Count==1)
            {
                if (item == lst[0])
                    return 0;
                else return -1;
            }            
            int low = 0,
                high = lst.Count - 1,
                mid, guess;
            mid = (low + high) / 2;
            if (high < low)
                return -1;
            guess = lst[mid];
            if (guess == item)
                return mid;
            if (guess > item)
                return binary_search(lst.GetRange(0, mid), item);
            else
            {
                low = mid + 1;
                int returned = binary_search(lst.GetRange(low, high - low + 1), item);
                if (returned == -1) 
                    return -1;
                return low + returned;
            }
        }
        static void Main(string[] args)
        {
            List<int> lst = new List<int> { 1, 3, 5, 6, 7, 9 };
            WriteLine($"индекс для числа 5 равен {binary_search(lst, 5)}");
            WriteLine($"индекс для числа 9 равен {binary_search(lst, 9)}");
            WriteLine($"индекс для числа 1 равен {binary_search(lst, 1)}");
            WriteLine($"индекс для числа -100 равен {binary_search(lst, -100)}");
            WriteLine($"индекс для числа 2 равен {binary_search(lst, 2)}");
            ReadKey(true);
        }
    }
}
