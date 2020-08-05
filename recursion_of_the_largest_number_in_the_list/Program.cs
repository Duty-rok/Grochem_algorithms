using System;
using System.Collections.Generic;
using static System.Console;

namespace recursion_of_the_largest_number_in_the_list
{
    class Program
    {
        static int largestInList(List<int> lst)
        {
            int max;
            if (lst.Count == 2)
            {
                if (lst[0] > lst[1])
                    return lst[0];
                else
                    return lst[1];
            }
            List<int> lst1 = new List<int>();
            lst1 = lst.GetRange(1, lst.Count - 1);
            max = largestInList(lst1);
            if (lst[0] > max)
                return lst[0];
            return max;
        }
        static void Main(string[] args)
        {
            Random rand = new Random();
            List<int> lst = new List<int>();
            for(int i = 0; i < 10; i++)
            {
                lst.Add(rand.Next(101));
                Write($"{lst[i]} ");
            }
            WriteLine();
            WriteLine($"наибольшее число в списке: {largestInList(lst)}");
            ReadKey(true);
        }
    }
}
