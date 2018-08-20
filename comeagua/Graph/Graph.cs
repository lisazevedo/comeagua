using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace comeagua.Graph
{
    public class Graph
    {
        public List<Edge> Edges { get; set; }
        public List<Vertex> Vertices { get; set; }

        public int NumVertices {
            get {
                return Vertices.Count();
            }
        }

        public Graph()
        {
            Edges = new List<Edge>();
            Vertices = new List<Vertex>();
        }

        public void InsertVertex(Vertex v)
        {
            this.Vertices.Add(v);
        }

        public void InsertEdge(Vertex v1, Vertex v2, int weight)
        {
            if (!v1.adj.Contains(v2))
            {
                this.Edges.Add(new Edge { V1 = v1, V2 = v2, Weight = weight });
                v1.adj.Add(v2);

                this.Edges.Add(new Edge { V1 = v2, V2 = v1, Weight = weight });
                v2.adj.Add(v1);

            }
        }

        public bool EdgeExists(int valueV1, int valueV2)
        {
            bool exists = false;
            var edge = (from a in this.Edges where a.V1.Value == valueV1 && a.V2.Value == valueV2 select a).FirstOrDefault();
            exists = edge != null;
            return exists;
        }

        public Edge GetEdge(Vertex v1, Vertex v2)
        {
            Edge edge = (from a in this.Edges where a.V1 == v1 && a.V2 == v2 select a).FirstOrDefault();
            return edge;
        }

    }
}