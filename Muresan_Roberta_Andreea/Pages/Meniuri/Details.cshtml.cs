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
    public class DetailsModel : PageModel
    {
        private readonly Muresan_Roberta_Andreea.Data.Muresan_Roberta_AndreeaContext _context;

        public DetailsModel(Muresan_Roberta_Andreea.Data.Muresan_Roberta_AndreeaContext context)
        {
            _context = context;
        }

        public Meniu Meniu { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Meniu = await _context.Meniu.FirstOrDefaultAsync(m => m.ID == id);

            if (Meniu == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
