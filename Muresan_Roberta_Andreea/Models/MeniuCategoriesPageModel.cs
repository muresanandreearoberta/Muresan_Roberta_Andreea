using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Muresan_Roberta_Andreea.Data;

namespace Muresan_Roberta_Andreea.Models
{
    public class MeniuCategoriesPageModel:PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Muresan_Roberta_AndreeaContext context,
        Meniu meniu)
        {
            var allCategories = context.Category;
            var meniuCategories = new HashSet<int>(
            meniu.MeniuCategories.Select(c => c.MeniuID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = meniuCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateMeniuCategories(Muresan_Roberta_AndreeaContext context,
        string[] selectedCategories, Meniu meniuToUpdate)
        {
            if (selectedCategories == null)
            {
                meniuToUpdate.MeniuCategories = new List<MeniuCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var meniuCategories = new HashSet<int>
            (meniuToUpdate.MeniuCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!meniuCategories.Contains(cat.ID))
                    {
                        meniuToUpdate.MeniuCategories.Add(
                        new MeniuCategory
                        {
                            MeniuID = meniuToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (meniuCategories.Contains(cat.ID))
                    {
                        MeniuCategory courseToRemove
                        = meniuToUpdate
                        .MeniuCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
