using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Dunca_Tarau_Proiect.Data;
using Dunca_Tarau_Proiect.Models;
using System.Security.Policy;

using Dunca_Tarau_Proiect.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Dunca_Tarau_Proiect.Pages.Tours
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : TourCategoriesPageModel
    {
        private readonly Dunca_Tarau_Proiect.Data.Dunca_Tarau_ProiectContext _context;

        public CreateModel(Dunca_Tarau_Proiect.Data.Dunca_Tarau_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CountryID"] = new SelectList(_context.Set<Country>(), "ID","CountryName");

            var tour = new Tour();
            tour.TourCategories = new List<TourCategory>();
            PopulateAssignedCategoryData(_context, tour);

            return Page();
        }

        [BindProperty]
        public Tour Tour { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
         public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            if (selectedCategories != null)
            {
                Tour.TourCategories = new List<TourCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new TourCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    Tour.TourCategories.Add(catToAdd);
                }
            }
            //Tour.TourCategories = newTour.TourCategories;
            _context.Tour.Add(Tour);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
            PopulateAssignedCategoryData(_context, Tour);
            return Page();

        }

    }

}

