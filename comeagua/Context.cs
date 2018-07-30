using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace comeagua
{
    public partial class Context : DbContext
    {

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            throw new UnintentionalCodeFirstException();
        }

        public void Start()
        {
            this.Database.CreateIfNotExists();
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Pub> Pubs { get; set; }
        public virtual DbSet<Operation> Operations { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        // public virtual DbSet<Tag_Pub>Tags_Pubs { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Holiday> Holidays { get; set; }
        public virtual DbSet<Guest> Guests { get; set; }
        public virtual DbSet<Week> Weeks { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }

    }
}