using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Muresan_Roberta_Andreea.Data;
using Muresan_Roberta_Andreea.Models;

namespace Muresan_Roberta_Andreea.Pages.Meniuri
{
    public class IndexModel : PageModel
    {
        private readonly Muresan_Roberta_Andreea.Data.Muresan_Roberta_AndreeaContext _context;

        public IndexModel(Muresan_Roberta_Andreea.Data.Muresan_Roberta_AndreeaContext context)
        {
            _context = context;
        }

        public IList<Meniu> Meniu { get;set; }
        public MeniuData MeniuD { get; set; }
        public int MeniuID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            MeniuD = new MeniuData();

            MeniuD.Meniuri = await _context.Meniu
            .Include(b => b.Categorie)
            .Include(b => b.MeniuCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Denumire)
            .ToListAsync();
            if (id != null)
            {
                MeniuID = id.Value;
                Meniu meniu = MeniuD.Meniuri
                .Where(i => i.ID == id.Value).Single();
                MeniuD.Categories = meniu.MeniuCategories.Select(s => s.Category);
            }
        }

    }
}
