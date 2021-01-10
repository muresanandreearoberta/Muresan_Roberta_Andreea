using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Muresan_Roberta_Andreea.Models
{
    public class MeniuData
    {
        public IEnumerable<Meniu> Meniuri { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<MeniuCategory> MeniuCategories { get; set; }
    }
}
