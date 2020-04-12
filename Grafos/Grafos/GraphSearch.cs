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
            this.origin = listOfVertexes[0];
            this.listOfVertexes = listOfVertexes;
        }

        // Breadth First Search
        public void BFS()
        {
            BFS_INIT();
            queueOfVertexes.Enqueue(origin);
            while (queueOfVertexes.Count != 0)
            {
                this.u = queueOfVertexes.Dequeue();
                foreach (Vertex v in this.u.adjList)
                {
                    if (v.color == "white")
                    {
                        v.color = "gray";
                        v.distance = this.u.distance + 1;
                        v.fatherVertex = this.u;
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
                    Visit(u);
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
