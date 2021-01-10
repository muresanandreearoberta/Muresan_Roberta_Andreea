using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Muresan_Roberta_Andreea.Data;
using Muresan_Roberta_Andreea.Models;

namespace Muresan_Roberta_Andreea.Pages.Meniuri
{
    public class EditModel : MeniuCategoriesPageModel
    {
        private readonly Muresan_Roberta_Andreea.Data.Muresan_Roberta_AndreeaContext _context;

        public EditModel(Muresan_Roberta_Andreea.Data.Muresan_Roberta_AndreeaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Meniu Meniu { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Meniu = await _context.Meniu
 .Include(b => b.Categorie)
 .Include(b => b.MeniuCategories).ThenInclude(b => b.Category)
 .AsNoTracking()
 .FirstOrDefaultAsync(m => m.ID == id);

            if (Meniu == null)
            {
                return NotFound();
            }

            PopulateAssignedCategoryData(_context, Meniu);


            ViewData["CategorieID"] = new SelectList(_context.Set<Categorie>(), "ID", "NumeCategorie");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var meniuToUpdate = await _context.Meniu
            .Include(i => i.Categorie)
            .Include(i => i.MeniuCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (meniuToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Meniu>(
            meniuToUpdate,
            "Meniu",
            i => i.Denumire,i => i.Gramaj, i => i.Price, i => i.DataExpirarii,i => i.Categorie))
            {
                UpdateMeniuCategories(_context, selectedCategories, meniuToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateMeniuCategories(_context, selectedCategories, meniuToUpdate);
            PopulateAssignedCategoryData(_context, meniuToUpdate);
            return Page();
        }
    }
}
