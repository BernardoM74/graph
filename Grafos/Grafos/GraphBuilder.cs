using Grafos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    class GraphBuilder
    {
        private int numberOfVertexes;
        private int numberOfEdges;
        public List<Vertex> listOfVertexes = new List<Vertex>();
        public List<int> listExit = new List<int>();

        public GraphBuilder()
        {
            this.numberOfVertexes = 0;
            this.numberOfEdges = 0;
        }

        public GraphBuilder(string[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (this.numberOfEdges > 0)
                {
                    string[] separatedData = data[i].Split(' ');

                    // Search vertex related to U and V values.
                    Vertex v1 = listOfVertexes.Find(someVertex => someVertex.id == Convert.ToInt32(separatedData[0]));
                    Vertex v2 = listOfVertexes.Find(someVertex => someVertex.id == Convert.ToInt32(separatedData[1]));
                    
                    //Add to each vertex his adjacent
                    v1.adjList.Add(v2);
                    v2.adjList.Add(v1);

                    Console.WriteLine("--------- V("+v1.id+") Adjacent List ---------");
                    foreach (Vertex v in v1.adjList)
                    {
                        Console.Write(v.id + "\t");
                    }
                    Console.WriteLine();

                    Console.WriteLine("--------- V(" + v2.id + ") Adjacent List ---------");
                    foreach ( Vertex v in v2.adjList)
                    {
                        Console.Write(v.id + "\t");
                    }
                    Console.WriteLine("\n");

                    this.numberOfEdges--;

                    if (this.numberOfEdges == 0)
                    {
                        listExit.Add(QuantVertexADD());
                    }
                }
                else
                {
                    string[] separatedData = data[i].Split(' ');
                    this.numberOfVertexes = Convert.ToInt32(separatedData[0]);
                    FillVertexList(this.numberOfVertexes);
                    this.numberOfEdges = Convert.ToInt32(separatedData[1]);
                }
            }

            foreach (var item in listExit)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("--------- All Vertex ---------");
            foreach (Vertex v in listOfVertexes)
            {
                Console.Write(v.id + "\t");
            }
            Console.WriteLine();

        }

        private int QuantVertexADD()
        {
            int numberOfAddedEdges = 0;

            foreach (Vertex vertex in listOfVertexes)
            {
                if (vertex.adjList.Count < 2)
                {
                    Vertex minor = FindVertexWithMinorDegree(vertex);
                    vertex.adjList.Add(minor);
                    numberOfAddedEdges++;
                }
            }

            return numberOfAddedEdges;
        }

        private void FillVertexList(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Vertex newVertex = new Vertex();
                newVertex.id = i;
                listOfVertexes.Add(newVertex);
            }
        }

        private Vertex FindVertexWithMinorDegree(Vertex vertexToReceiveEdge)
        {
            Vertex vertexWithMinorDegree = new Vertex();

            foreach (Vertex someVertex in listOfVertexes)
            {
                if (someVertex.id != vertexToReceiveEdge.id)
                {
                    if (vertexWithMinorDegree.id == 0)
                    {
                        vertexWithMinorDegree = someVertex;
                    }
                    else if (vertexWithMinorDegree.adjList.Count > someVertex.adjList.Count)
                    {
                        vertexWithMinorDegree = someVertex;
                    }
                }
            }
            return vertexWithMinorDegree;
        }

        public void Search(string method)
        {
            GraphSearch gs = new GraphSearch(listOfVertexes);
            if ( method == "BFS")
            {
                gs.BFS();
            }
            else
            {
                gs.DFS();
            }
        }




    }
}
