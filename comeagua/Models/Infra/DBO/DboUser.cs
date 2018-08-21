using comeagua.Infra.Tables;
using comeagua.Models;
using comeagua.Models.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;

namespace comeagua.Infra.DBO
{
    public static class DboUser
    {
        public static string AddUser(User user)
        {
            var db = new ApplicationDbContext();
            db.Start();
            //User user = new User { Name = firstname, LastName = lastname, Birthday = birthday, Email = email, Password = password};
            var Query = (from Log in db.Users where Log.Email == user.Email select Log);

            if (Query is null)
            {
                db.Users.Add(user);

                db.SaveChanges();
                return "Usuario criado com sucesso!";
            }
            return "E-mail já cadastrado, tente novamente com outro e-mail.";
        }

        //public static void deleteuser(int id)
        //{
        //    var db = new contexto();
        //    db.start();
        //    var user = new user { id = id };
        //    db.users.attach(user);
        //    db.users.remove(user);

        //    db.savechanges();

        //}

        //public static void updateuser(user user)
        //{
        //    var db = new contexto();

        //    db.start();
        //    db.users.attach(user);
        //    db.entry(user).state = system.data.entity.entitystate.modified;
        //    db.savechanges();
        //}

        //public static string existuser(string email, string password)
        //{
        //    var db = new contexto();
        //    var query = (from log in db.users where log.email == email select log);

        //    if (query is null)
        //    {
        //        return "e-mail nao cadastrado.";
        //    }
        //    return ""; 
        //}
    }
}