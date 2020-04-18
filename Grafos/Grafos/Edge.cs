using Graph;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grafos
{
    class Edge
    {
        public int id { get; set; }
        public int weight { get; set; }
        public Vertex v1 { get; set; }
        public Vertex v2 { get; set; }

    }
}
