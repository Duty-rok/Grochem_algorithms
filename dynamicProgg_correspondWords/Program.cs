using System.Threading;
using static System.Console;
using static System.Math;

namespace dynamicProgg_correspondWords
{
    class Program
    {
        static string[] words;
        static void Main(string[] args)
        {
            Write("Ведите два слова через пробел: ");
            string s = ReadLine();
            words = s.Split(' ');
            if (words.Length != 2)
            {
                WriteLine("Надо ввести два слова, ни больше, ни меньше \nПриложение закрывается через секунду ...");
                Thread.Sleep(1000);
                return;
            }
            WriteLine($"{corresspond()}\nДля выхода нажмите Enter...");
            ReadKey(true);
        }
        static string corresspond()
        {
            int[,] comparingTable = new int[words[0].Length, words[1].Length];
            int max = 0;
            bool equality;
            for(int i=0;i< words[0].Length; i++)
            {
                for (int j = 0; j < words[1].Length; j++)
                {
                    equality = words[0][i] == words[1][j];
                    if (i == 0 | j == 0)
                    {
                        if (equality)
                            comparingTable[i, j] = 1;
                        else if (i == 0 & j == 0)
                            comparingTable[i, j] = 0;
                        else if (i == 0)
                            comparingTable[i, j] = comparingTable[i, j - 1];
                        else if (j == 0)
                            comparingTable[i, j] = comparingTable[i - 1, j];
                    }
                    else
                    {
                        if (equality)
                            comparingTable[i, j] = comparingTable[i - 1, j - 1] + 1;
                        else
                            comparingTable[i, j] = Max(comparingTable[i, j - 1], comparingTable[i - 1, j]);
                    }
                    if (comparingTable[i,j] > max)
                        max = comparingTable[i, j];
                    Write($"{comparingTable[i, j]} ");
                }
                WriteLine();
            }
            return $"Количество схожих последовательностей: {max}";
        }
    }
}
