using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dunca_Tarau_Proiect.Data;
using Dunca_Tarau_Proiect.Models;
using Dunca_Tarau_Proiect.Models.ViewModels;

namespace Dunca_Tarau_Proiect.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Dunca_Tarau_Proiect.Data.Dunca_Tarau_ProiectContext _context;

        public IndexModel(Dunca_Tarau_Proiect.Data.Dunca_Tarau_ProiectContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;
       
        public CategoryIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }
        public int TourID { get; set; }

        public async Task OnGetAsync(int? id, int? TourID)
        {

            CategoryData = new CategoryIndexData();
            CategoryData.Categories = await _context.Category
                .Include(i => i.TourCategories)
                .ThenInclude(i => i.Tour)
                .OrderBy(i => i.CategoryName)
                .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;
                Category category = CategoryData.Categories.Where(i => i.ID == id.Value).Single();
                CategoryData.TourCategories = category.TourCategories;

            }
        }
    }
}
