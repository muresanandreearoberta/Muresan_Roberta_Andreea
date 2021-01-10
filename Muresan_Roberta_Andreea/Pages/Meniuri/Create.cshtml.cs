using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Muresan_Roberta_Andreea.Data;
using Muresan_Roberta_Andreea.Models;

namespace Muresan_Roberta_Andreea.Pages.Meniuri
{
    public class CreateModel : MeniuCategoriesPageModel
    {
        private readonly Muresan_Roberta_Andreea.Data.Muresan_Roberta_AndreeaContext _context;

        public CreateModel(Muresan_Roberta_Andreea.Data.Muresan_Roberta_AndreeaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CategorieID"] = new SelectList(_context.Set<Categorie>(), "ID", "NumeCategorie");

            var meniu = new Meniu();
            meniu.MeniuCategories = new List<MeniuCategory>();
            PopulateAssignedCategoryData(_context, meniu);


            return Page();

        }

        [BindProperty]
        public Meniu Meniu { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newMeniu = new Meniu();
            if (selectedCategories != null)
            {
                newMeniu.MeniuCategories = new List<MeniuCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new MeniuCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newMeniu.MeniuCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Meniu>(
            newMeniu,
            "Meniu",
            i => i.Denumire, i => i.Gramaj,
            i => i.Price, i => i.DataExpirarii, i => i.CategorieID))
            {
                _context.Meniu.Add(newMeniu);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newMeniu);
            return Page();
        }
    }
}
