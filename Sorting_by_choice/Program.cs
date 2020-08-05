using System;
using System.Collections.Generic;
using static System.Console;

namespace Sorting_by_choice
{
    class Program
    {
        static Random rand = new Random();
        static int findSmallest(List<int> arr)
        {
            int smallest = arr[0],
                smallest_index = 0;
            for(int i = 1; i < arr.Count; i++)
            {
                if (arr[i] < smallest)
                {
                    smallest = arr[i];
                    smallest_index = i;
                }                
            }
            return smallest_index;            
        }
        static List<int> selectionSort(List<int> arr)
        {
            int smallest,
                index = arr.Count;
            List<int> lst = new List<int>();
            for(int i = 0; i < index; i++)
            {
                smallest = findSmallest(arr);
                lst.Add(arr[smallest]);
                arr.RemoveAt(smallest);               
            }
            return lst;
        }
        static void selectionSort(int[] arr)
        {
            int min, temp;
            for(int i = 0; i < arr.Length - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min])
                        min = j;
                }
                temp = arr[min];
                arr[min] = arr[i];
                arr[i] = temp;
            }
        }
        public static void Main(string[] args)
        {
            //List<int> lst = new List<int>();
            //for (int i = 0; i < 10; i++)
            //{
            //    lst.Add(rand.Next(100));
            //    Write($"{lst[i]} ");
            //}
            //lst = selectionSort(lst);
            //WriteLine();
            //for (int i = 0; i < 10; i++)
            //{
            //    Write($"{lst[i]} ");
            //}
            int[] mas = new int[30];
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i]=rand.Next(100);
                Write($"{mas[i]} ");
            }
            selectionSort(mas);
            WriteLine();
            for (int i = 0; i < mas.Length; i++)
            {
                Write($"{mas[i]} ");
            }            
            ReadKey(true);
        }
    }
}
