using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using comeagua.Infra.DBO;
using comeagua.Infra.Tables;
using comeagua.Models;
using comeagua.Models.Infra.DBO;

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

        public void InsertEdge(Vertex v1, Vertex v2, List<DateTime> weight)
        {
            if (!v1.adj.Contains(v2))
            {
                this.Edges.Add(new Edge { V1 = v1, V2 = v2, Weight = weight });
                v1.adj.Add(v2);
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

        public void Start(string place)
        {
            List<Pub> pubs = DboPub.GetPubs(place);

            foreach (Pub p in pubs)
            {
                Vertex vPub = new Vertex { _pub = p };
                this.InsertVertex(vPub);

                List<Event> events = DboEvent.GetEvents(p.ID);
                if (events.Count() > 0)
                {
                    foreach (Event e in events)
                    {
                        List<DateTime> acD = new List<DateTime>();
                        acD.Add(e.Date); acD.Add(e.Hour);
                        Vertex vEvent = new Vertex { _event = e };
                        this.InsertEdge(vPub, vEvent, acD);
                    }
                }
            }
        }

        public string SearchPub()
        {
            if (this.Vertices.Count() > 0)
            {
                Vertex bp = Vertices.First();
                int qtE = 0;
                foreach (Vertex vPub in this.Vertices)
                {
                    if (vPub.adj.Count() > qtE)
                    {
                        bp = vPub;
                        qtE = bp.adj.Count();
                    }

                    foreach (Edge e in this.Edges)
                    {
                        if (e.V1 == vPub && e.Weight[0].DayOfYear == DateTime.Now.DayOfYear && e.Weight[1].Hour == DateTime.Now.Hour)
                        {
                            bp = vPub;
                            qtE = bp.adj.Count();
                        }
                    }
                }
                if (bp.adj.Count() > 0) return bp._pub.Name;
            }
            return "Sem eventos para esta região!";
        }

        public string BestPub(string place)
        {
            this.Start(place);
            return this.SearchPub();
        }

    }
}