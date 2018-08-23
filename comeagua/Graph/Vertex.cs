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

        ///O vértice pode ser um Pub ou um Evento
        public Pub _pub { get; set; }
        public Event _event { get; set; }
        public List<Vertex> adj { get; set; }

        public Vertex()
        {
            adj = new List<Vertex>();
        }

    }
}