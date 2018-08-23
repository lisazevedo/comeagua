using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using comeagua.Infra.Tables;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace comeagua.Models
{
    // É possível adicionar dados do perfil do usuário adicionando mais propriedades na sua classe ApplicationUser, visite https://go.microsoft.com/fwlink/?LinkID=317594 para obter mais informações.
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public DateTime BirthDate { get; set; }
        public String Image { get; set; }
        public int Gender { get; set; }
        public int ReviewID { get; set; }
        public virtual List<Event> Events { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)//Login passa por aqui.
        {
            // Observe que o authenticationType deve corresponder àquele definido em CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Adicionar declarações de usuário personalizado aqui
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public void Start()
        {
            this.Database.CreateIfNotExists();
        }

        //public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Pub> Pubs { get; set; }
        //public virtual DbSet<Operation> Operations { get; set; }
        //public virtual DbSet<Address> Addresses { get; set; }
        //public virtual DbSet<Photo> Photos { get; set; }
        //public virtual DbSet<Tag> Tags { get; set; }
        // public virtual DbSet<Tag_Pub>Tags_Pubs { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        //public virtual DbSet<Holiday> Holidays { get; set; }
        //public virtual DbSet<Guest> Guests { get; set; }
        //public virtual DbSet<Week> Weeks { get; set; }
        //public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<ErrorLog> ErrorLogs { get; set; }
    }
}