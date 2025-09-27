using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp
{
    internal class Contact
    {
        public string nom { get; set; }
        public string email { get; set; }
        public int telephone { get; set; }

        public Contact(string nom, string email, int telephone)
        {
            this.nom = nom;
            this.email = email;
            this.telephone = telephone;
        }

        public override string ToString()
        {
            return "nom : " + nom + "\n" + "email : "  + email + "\n" + "tel : " + telephone;
        } 
       
    }
}
