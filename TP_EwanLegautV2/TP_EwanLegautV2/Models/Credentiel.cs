using System;
using System.Collections.Generic;
using System.Text;

namespace TP_EwanLegautV2.Models
{
    public class Credentiel
    {
        public int id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Categorie { get; set; }
        public string Description { get; set; }
    }
}
