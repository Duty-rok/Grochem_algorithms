using System.Collections.Generic;
using System.Linq;
using static System.Console;

class Program
{
    static void Main(string[] args)
    {
        List<int> lst = new List<int> { 1, 3, 5, 6, 7, 9 };
        WriteLine(binary_search(lst, 5));
        WriteLine(binary_search(lst, -100));
        ReadKey(true);
    }
    static int binary_search(List<int> lst, int item)
    {
        int low = 0,
            high = lst.Count() - 1,
            mid, guess;
        while (low <= high)
        {
            mid = (low + high) / 2;
            guess = lst[mid];
            if (guess == item)
                return mid;
            if (guess > item)
                high = mid - 1;
            else
                low = mid + 1;
        }
        return -1;
    }
}
