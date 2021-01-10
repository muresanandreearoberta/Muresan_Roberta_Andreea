using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Muresan_Roberta_Andreea.Models
{
    public class Meniu
    {
        public int ID { get; set; }
        public string Denumire { get; set; }
        [Column(TypeName = "decimal(6, 2)")]


        public decimal Gramaj { get; set; }
        [Column(TypeName = "decimal(6, 2)")]

        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataExpirarii { get; set; }
        public int CategorieID { get; set; }
        public Categorie Categorie { get; set; }
        public ICollection<MeniuCategory> MeniuCategories { get; set; }

        


    }
}
