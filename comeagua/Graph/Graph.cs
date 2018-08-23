using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using comeagua.Infra.Tables;
using comeagua.Models;

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

        public static List<Pub> GetPubs(string place)
        {
            var db = new ApplicationDbContext();
            db.Start();

            var Query = (from p in db.Pubs where p.Address.Contains(place) select p).ToList(); ;

            if (Query != null) return Query;
            return new List<Pub>();
        }

        public string BestPub(string place)
        {
            List<Pub> pubs = GetPubs(place);

            //foreach (Pub p in pubs)
            //{
            //    Vertex v1 = new Vertex(); v1.pub = p;
            //    Vertex v2 = new Vertex();
            //    this.InsertEdge(v1, v2, 3);
            //}
            if (pubs.Count() > 0) return pubs[0].Name;
            return "Estimativa de bar não encontrada";
        }

    }
}