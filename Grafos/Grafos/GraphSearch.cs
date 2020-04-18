using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graph
{
    class GraphSearch
    {
        private Vertex origin;
        private Vertex u;
        private int timestamp;
        private Queue<Vertex> queueOfVertexes;
        private List<Vertex> listOfVertexes;

        public GraphSearch(List<Vertex> listOfVertexes)
        {
            this.u = new Vertex();
            this.listOfVertexes = listOfVertexes;
            this.origin = listOfVertexes[FirstVertex()];
        }

        private int FirstVertex()
        {
            Console.WriteLine("--------- Choose the vertex to begin with: ---------");
            foreach (Vertex vertex in this.listOfVertexes)
            {
                Console.WriteLine("(" + vertex.id +")");
            }
            Console.WriteLine();
            string selectedVertex = Console.ReadLine();
            
            return this.listOfVertexes.FindIndex(vertex => vertex.id == selectedVertex);
        }
        
            
        // Breadth First Search
        public void BFS()
        {
            BFS_INIT();
            queueOfVertexes.Enqueue(origin);
            while (queueOfVertexes.Count != 0)
            {
                this.u = queueOfVertexes.Dequeue();
                for (int i = 0; i < this.u.adjList.Count; i++)
                {
                    Vertex v = MinorVertex(this.u.adjList);

                    if (v.color == "white")
                    {
                        v.color = "gray";
                        v.distance = this.u.distance + 1;
                        v.fatherVertex = this.u;
                        foreach( Vertex predecessor in this.u.predecessors)
                        {
                            v.predecessors.Add(predecessor);
                        }
                        v.predecessors.Add(this.u);
                        queueOfVertexes.Enqueue(v);
                    }

                }
                this.u.color = "black";
            }
            BFS_PRINT();
        }

        private void BFS_INIT()
        {
            foreach (Vertex u in this.listOfVertexes)
            {
                if (u != this.origin)
                {
                    u.color = "white";
                    u.distance = Int32.MaxValue;
                    u.fatherVertex = null;
                }
                this.u = u;
            }
            this.origin.color = "gray";
            this.origin.distance = 0;
            this.origin.fatherVertex = null;
            queueOfVertexes = new Queue<Vertex>();
        }

        private void BFS_PRINT()
        {
            Console.WriteLine("\n--- Distances ---");
            foreach (Vertex vertex in this.listOfVertexes)
            {
                Console.Write(vertex.id + "\t->\t");
                Console.Write(vertex.distance);
                Console.WriteLine();
            }

            Console.WriteLine("\n--- Fathers ---");
            foreach (Vertex vertex in this.listOfVertexes)
            {
                Console.Write(vertex.id + "\t->\t");
                if (vertex.fatherVertex != null)
                {
                    Console.Write(vertex.fatherVertex.id);
                }
                else
                {
                    Console.Write("- \t ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n--- Path ---");
            foreach (Vertex vertex in this.listOfVertexes)
            {
                Console.Write(vertex.id + "\t->\t");
                if (vertex.predecessors != null)
                {
                    foreach( Vertex predecessor in vertex.predecessors)
                    {
                        Console.Write(predecessor.id + "  ");
                    }
                }
                else
                {
                    Console.Write("- \t ");
                }
                Console.WriteLine();
            }

        }

        private Vertex GetFirstWhite(List<Vertex> adjacentList)
        {
            Vertex firstWhite = new Vertex();
            for (int j = 0; j < adjacentList.Count; j++)
            {
                if (adjacentList[j].color == "white")
                {
                    firstWhite = adjacentList[j];
                    return firstWhite;
                }
            }
            return firstWhite;
        }

        private Vertex MinorVertex(List<Vertex> adjacentList)
        {
            Vertex minor = GetFirstWhite(adjacentList);
            if ( minor.id != null)
            {
                for (int i = 0; i < adjacentList.Count; i++)
                {
                    Vertex aux = adjacentList[i];
                    if (aux.color == "white" && aux.id.CompareTo(minor.id) < 0)
                    {
                        minor = aux;
                    }
                }
            } 
            return minor;
        }

        // Depth First Search
        public void DFS()
        {
            DFS_INIT();
        }

        private void Visit(Vertex u)
        {
            this.timestamp += 1;
            u.discoveryTime = this.timestamp;
            u.color = "gray";
            this.u = u;
            foreach (Vertex v in u.adjList)
            {
                if (v.color == "white")
                {
                    v.fatherVertex = u;
                    Visit(v);
                }
            }
            this.timestamp++;
            u.endedTime = this.timestamp;
            this.u = u;
        }

        private void DFS_INIT()
        {
            foreach (Vertex u in this.listOfVertexes)
            {
                u.color = "white";
                u.fatherVertex = null;
                this.u = u;
            }
            this.timestamp = 0;
            foreach (Vertex u in this.listOfVertexes)
            {
                if (u.color == "white")
                {
                    Visit(u);
                }
            }
        }

        private void DFS_PRINT()
        {
            Console.WriteLine("\n--- Discover Time ---");
            foreach (Vertex vertex in this.listOfVertexes)
            {
                Console.Write(vertex.id + "\t->\t");
                Console.Write(vertex.discoveryTime);
                Console.WriteLine();
            }

            Console.WriteLine("\n--- Final Time ---");
            foreach (Vertex vertex in this.listOfVertexes)
            {
                Console.Write(vertex.id + "\t->\t");
                Console.Write(vertex.endedTime);
                Console.WriteLine();
            }

            Console.WriteLine("\n--- Fathers ---");
            foreach (Vertex vertex in this.listOfVertexes)
            {
                Console.Write(vertex.id + "\t->\t");
                if (vertex.fatherVertex != null)
                {
                    Console.Write(vertex.fatherVertex.id);
                }
                else
                {
                    Console.Write("- \t ");
                }
                Console.WriteLine();
            }

        }

    }
}
