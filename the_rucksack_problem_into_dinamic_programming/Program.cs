using System;
using System.Collections;
using static System.Math;

namespace the_rucksack_problem_into_dinamic_programming
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] things = new string[] { "gitar", "cassette_player", "laptop" };
            Hashtable weight = new Hashtable();
            weight.Add("gitar", 1);
            weight.Add("laptop", 3);
            weight.Add("cassette_player", 4);
            Hashtable cost = new Hashtable();
            cost.Add("gitar", 1500);
            cost.Add("laptop", 2000);
            cost.Add("cassette_player", 3000);
            int[,] cell = new int[3, 4];
            for(int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i == 0)
                    {
                        if (((int)weight[things[i]]) <= j + 1)
                        {
                            cell[i, j] = (int)cost[things[i]];
                        }
                    }
                    else
                    {
                        if (((int)weight[things[i]]) <= j + 1)
                        {
                            int temp;
                            if (j - ((int)weight[things[i]]) < 0)
                                temp = 0;
                            else
                                temp = cell[i - 1, j - ((int)weight[things[i]])];
                            cell[i, j] = Max(cell[i - 1, j], ((int)cost[things[i]]) + temp);
                        }
                        else cell[i, j] = cell[i - 1, j];
                    }
                    Console.Write($"{cell[i, j]} " );
                }
                Console.WriteLine();
            }
            Console.WriteLine(cell[2, 3]);
            Console.ReadKey(true);
        }
    }
}
