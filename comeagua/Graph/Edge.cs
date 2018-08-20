using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace comeagua.Graph
{
    public class Edge
    {
        public Vertex V1 { get; set; }
        public Vertex V2 { get; set; }
        public int Weight { get; set; }
    }
}