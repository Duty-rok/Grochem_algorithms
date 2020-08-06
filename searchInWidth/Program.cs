using System.Collections;
using System.Collections.Generic;
using static System.Console;

namespace searchInWidth
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable graph = new Hashtable();
            graph.Add("you", new Deque("alice", "bob", "claire"));
            graph.Add("bob", new Deque("anuj", "peggy"));
            graph.Add("alice", new Deque("peggy"));
            graph.Add("claire", new Deque("thom", "jonny"));
            graph.Add("anuj", new Deque());
            graph.Add("peggy", new Deque());
            graph.Add("thom", new Deque());
            graph.Add("jonny", new Deque());
            if (!search(graph, "you"))
                WriteLine("We can't find a mango seller");
            ReadKey(true);
        }
        static bool personIsSeller(string name)
        {
            return name[name.Length - 1] == 'm';
        }
        static bool search(Hashtable graph, string startName)
        {
            Deque search_queue = new Deque();
            search_queue += (Deque)graph[startName];
            List<string> searched = new List<string>();
            string person;
            while (search_queue.Count != 0)
            {
                person = (string)search_queue.Dequeue();
                if (!searched.Contains(person))
                {
                    if (personIsSeller(person))
                    {
                        WriteLine($"{person} is a mango seller");
                        return true;
                    }
                    else
                    {
                        search_queue += (Deque)graph[person];
                        searched.Add(person);
                    }
                }
            }
            return false;
        }
    }
}
