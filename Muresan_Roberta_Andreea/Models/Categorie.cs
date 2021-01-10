using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Muresan_Roberta_Andreea.Models
{
    public class Categorie
    {
        public int ID { get; set; }
        public string NumeCategorie { get; set; }
        public ICollection<Meniu> Meniuri { get; set; }
    }
}
