using System.Collections;
using static System.Console;

namespace greedy_algorithm
{
    class Program
    {
        static Plenty<string> states_needed;
        static Hashtable stations;
        static Plenty<string> final_stations;
        static void Main(string[] args)
        {
            states_needed = new Plenty<string>("mt", "wa", "or", "id", "nv", "ut", "ca", "az");
            stations = new Hashtable();
            stations.Add("kone", new Plenty<string>("id", "nv", "ut"));
            stations.Add("ktwo", new Plenty<string>("id", "wa", "mt"));
            stations.Add("kthree", new Plenty<string>("or", "nv", "ca"));
            stations.Add("kfour", new Plenty<string>("nv", "ut"));
            stations.Add("kfive", new Plenty<string>("ca", "az"));
            final_stations = new Plenty<string>();
            while (states_needed.Count != 0)
            {
                string best_station = "none";
                Plenty<string> states_covered = new Plenty<string>();
                foreach(object station in stations.Keys)
                {
                    Plenty<string> covered = states_needed * ((Plenty<string>)stations[station]);
                    if (covered.Count > states_covered.Count)
                    {
                        best_station = (string)station;
                        states_covered = covered;
                    }
                }
                final_stations.Add(best_station);
                states_needed -= states_covered;
            }
            foreach (string station in final_stations)
                Write($"{station} ");
        }
    }
}
