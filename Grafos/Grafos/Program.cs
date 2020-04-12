using System;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            string [] allDataFromFile = System.IO.File.ReadAllLines("Entrada.txt");
            GraphBuilder G = new GraphBuilder(allDataFromFile);
            G.Search("BFS");
        }
    }
}
