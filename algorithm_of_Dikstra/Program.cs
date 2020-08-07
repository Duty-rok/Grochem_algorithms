using System;
using System.Collections;
using System.Collections.Generic;

namespace algorithm_of_Dikstra
{
    class Program
    {
        static Hashtable graph, costs, parents;
        static List<object> processed = new List<object>();
        static void Main(string[] args)
        {
            graph = new Hashtable();
            graph.Add("start", new Hashtable());
            ((Hashtable)graph["start"]).Add("a", 6);
            ((Hashtable)graph["start"]).Add("b", 2);
            graph.Add("a", new Hashtable());
            ((Hashtable)graph["a"]).Add("fin", 1);
            graph.Add("b", new Hashtable());
            ((Hashtable)graph["b"]).Add("fin", 5);
            ((Hashtable)graph["b"]).Add("a", 3);
            graph.Add("fin", new Hashtable());
            costs = new Hashtable();
            costs.Add("a", 6);
            costs.Add("b", 2);
            costs.Add("fin", double.PositiveInfinity);
            parents = new Hashtable();
            parents.Add("a", "start");
            parents.Add("b", "start");
            parents.Add("fin", "none");
            search_in_algorithm();
            Console.ReadKey(true);
        }
        static object find_lowest_cost_node(/*Hashtable costs*/)
        {
            double lowest_cost = double.PositiveInfinity, cost;
            object lowest_cost_node = "none";
            foreach (object node in costs.Keys)
            {
                cost = Convert.ToDouble(costs[node]);
                if (cost < lowest_cost & (!processed.Contains(node)))
                {
                    lowest_cost = cost;
                    lowest_cost_node = node;
                }
            }
            return lowest_cost_node;
        }
        static void search_in_algorithm()
        {
            object node = find_lowest_cost_node();
            double new_cost;
            while ((string)node != "none")
            {
                double cost = Convert.ToDouble(costs[node]);
                Hashtable neighboors = (Hashtable)graph[node];
                foreach (object n in neighboors.Keys)
                {
                    new_cost = cost + Convert.ToDouble(neighboors[n]);
                    if (Convert.ToDouble(costs[n]) > new_cost)
                    {
                        costs[n] = new_cost;
                        parents[n] = node;
                    }
                }
                processed.Add(node);
                node = find_lowest_cost_node();
            }
            Path();
        }
        static void Path()
        {
            string path = "fin";
            object node = "fin";
            while (parents.ContainsKey(node))
            {
                path += $" ← {parents[node]}";
                node = parents[node];
            }
            Console.WriteLine(path+$" займет {costs["fin"]} минут");
        }                
    }
}
