using comeagua.Infra.Tables;
using comeagua.Models;
using comeagua.Models.Infra;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;

namespace comeagua.Infra.DBO
{
    public class DboPub
    {
        public void AddPub(Pub pub)
        {
            var db = new ApplicationDbContext();
            
            db.Start();
            db.Pubs.Add(pub);
            db.SaveChanges();
        }

        public void DeletePub(int id)
        {
            var db = new ApplicationDbContext();
            db.Start();
            var pub = new Pub { ID = id };
            db.Pubs.Attach(pub);
            db.Pubs.Remove(pub);

            db.SaveChanges();

        }

        public void UpdateUser(Pub pub) //pq o nome UpdateUser?
        {
            var db = new ApplicationDbContext();

            db.Start();
            db.Pubs.Attach(pub);
            db.Entry(pub).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}