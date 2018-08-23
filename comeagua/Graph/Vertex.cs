using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using comeagua.Infra.Tables;

namespace comeagua.Graph
{
    public class Vertex
    {
        public int Value { get; set; }
        public Pub pub { get; set; }
        public List<Vertex> adj { get; set; }

        public Vertex()
        {
            adj = new List<Vertex>();
           
        }

    }
}