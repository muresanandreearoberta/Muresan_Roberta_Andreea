using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Muresan_Roberta_Andreea.Data;
using Muresan_Roberta_Andreea.Models;

namespace Muresan_Roberta_Andreea.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Muresan_Roberta_Andreea.Data.Muresan_Roberta_AndreeaContext _context;

        public IndexModel(Muresan_Roberta_Andreea.Data.Muresan_Roberta_AndreeaContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }
    }
}
