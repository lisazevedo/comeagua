using comeagua.Infra.Tables;
using comeagua.Models.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;

namespace comeagua.Infra.DBO
{
    //public class DboPub
    //{
    //    public void AddPub(Pub pub)
    //    {
    //        var db = new Contexto();

    //        db.Start();
    //        db.Pubs.Add(pub);
    //        db.SaveChanges();
    //    }

    //    public void DeletePub(int id)
    //    {
    //        var db = new Contexto();
    //        db.Start();
    //        var pub = new Pub { ID = id };
    //        db.Pubs.Attach(pub);
    //        db.Pubs.Remove(pub);

    //        db.SaveChanges();

    //    }

    //    public void UpdateUser(Pub pub)
    //    {
    //        var db = new Contexto();

    //        db.Start();
    //        db.Pubs.Attach(pub);
    //        db.Entry(pub).State = System.Data.Entity.EntityState.Modified;
    //        db.SaveChanges();
    //    }
    //}
}