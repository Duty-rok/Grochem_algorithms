using System;
using System.Collections.Generic;
using static System.Console;

namespace quickSort
{
    class Program
    {
        static int[] quickSort(int[] arr)
        {
            if (arr.Length < 2)
                return arr;
            int baseNumber = arr[arr.Length/2];
            
            List<int> less = new List<int>();
            List<int> greater = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (i == arr.Length / 2)
                    continue;
                if (arr[i] <= baseNumber)
                    less.Add(arr[i]);
                else
                    greater.Add(arr[i]);
            }
            int[] small = new int[less.Count],
                big = new int[greater.Count];
            less.CopyTo(small);
            greater.CopyTo(big);
            return massAdd(quickSort(small), massAdd(new int[] { baseNumber }, quickSort(big)));
            
        }
        static int[] massAdd(int[] arr, int[] arr1)
        {
            int[] result = new int[arr.Length + arr1.Length];
            int i = 0;
            for ( ; i < arr.Length; i++)
            {
                result[i] = arr[i];
            }
            for(int j = 0; j < arr1.Length; j++)
            {
                result[i] = arr1[j];
                i++;
            }
            return result;
        }
        static void Main(string[] args)
        {
            Random rand = new Random();
            int[] arr = new int[30];
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(100);
                Write($"{arr[i]} ");
            }
            WriteLine();
            WriteLine("Отсортированный массив: ");
            arr = quickSort(arr);
            for(int i=0; i< arr.Length; i++)
            {
                Write($"{arr[i]} ");
            }
            WriteLine();
            ReadKey(true);
        }
    }
}