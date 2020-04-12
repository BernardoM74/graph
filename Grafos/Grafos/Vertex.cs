using Graph;
using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    class Vertex
    {
        public int id { get; set; }
        public string color { get; set; }
        public int distance { get; set; }
        public int discoveryTime { get; set; }
        public int endedTime { get; set; }
        public Vertex fatherVertex { get; set; }

        public List<Vertex> adjList = new List<Vertex>();
    }
}
