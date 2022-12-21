using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dunca_Tarau_Proiect.Data;
using Dunca_Tarau_Proiect.Models;

using Dunca_Tarau_Proiect.Models;
using System.Security.Policy;

namespace Dunca_Tarau_Proiect.Pages.Tours
{
    public class EditModel : TourCategoriesPageModel
    {
        private readonly Dunca_Tarau_Proiect.Data.Dunca_Tarau_ProiectContext _context;

        public EditModel(Dunca_Tarau_Proiect.Data.Dunca_Tarau_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tour Tour { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tour = await _context.Tour
                .Include(b => b.Country)
                .Include(b => b.TourCategories).ThenInclude(b => b.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);


            if (Tour == null)
            {
                return NotFound();
            }

            PopulateAssignedCategoryData(_context, Tour);
            ViewData["CountryID"] = new SelectList(_context.Country, "ID","CountryName");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tourToUpdate = await _context.Tour
            .Include(i => i.Country)
            .Include(i => i.TourCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (tourToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Tour>(
       tourToUpdate,
       "Tour"))
            {
                UpdateTourCategories(_context, selectedCategories, tourToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdateTourCategories(_context, selectedCategories, tourToUpdate);
            PopulateAssignedCategoryData(_context, tourToUpdate);
            return Page();


        }
    }
}
