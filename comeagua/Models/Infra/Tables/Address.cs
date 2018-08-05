using comeagua.Infra.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace comeagua.Models.Infra.Tables
{
    public class Address
    {
        public int ID { get; set; }
        public int X { get; set; }
        public int y { get; set; }


        public int Zip { get; set; } //cep
        public string Neighborhood { get; set; } //Bairro
        public int Number { get; set; } //numero
        public string Street { get; set; }//rua

        // [ForeignKey("Pub")]
        //public int PubID { get; set; }
        //public virtual Pub Pub { get; set; }
    }
}