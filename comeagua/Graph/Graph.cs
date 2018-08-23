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

        public void InsertEdge(Vertex v1, Vertex v2, DateTime weight)
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
                List<Event> events = DboEvent.GetEvents(p.ID);
                if (events.Count() > 0)
                {
                    Vertex vPub = new Vertex { _pub = p };
                    this.InsertVertex(vPub);
                    foreach (Event e in events)
                    {
                        Vertex vEvent = new Vertex { _event = e };
                        this.InsertEdge(vPub, vEvent, vEvent._event.Date);
                    }
                }
            }
        }

        public void SearchPub()
        {
            if (this.Vertices.Count() > 0)
            {
                foreach (Vertex vPub in this.Vertices)
                {
                    foreach (Vertex vEvent in vPub.adj)
                    {
                        //vEvent._event.Date.
                    }
                }
            }
           
        }

        public string BestPub(string place)
        {
            this.Start(place);
            this.SearchPub();

            //if (pubs.Count() > 0) return pubs[0].Name;
            return "Estimativa de bar não encontrada";
        }

    }
}