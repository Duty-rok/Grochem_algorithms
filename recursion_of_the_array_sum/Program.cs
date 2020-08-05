using System;
using System.Collections.Generic;
using static System.Console;

namespace recursion_of_the_array_sum
{
    class Program
    {
        static int arraySum(int[] arr)
        {
            if (arr.Length == 1)
                return arr[0];
            int[] mass=new int[arr.Length-1];
            Array.Copy(arr, 1, mass, 0, arr.Length - 1);
            return arr[0] + arraySum(mass);
        }        
        static void Main(string[] args)
        {
            Random rand = new Random();
            int[] mass = new int[10];
            for(int i = 0; i < mass.Length; i++)
            {
                mass[i] = rand.Next(10);
                Write($"{mass[i]} ");
            }
            WriteLine();
            WriteLine($"сумма массива: {arraySum(mass)}");
            ReadKey(true);
        }
    }
}
