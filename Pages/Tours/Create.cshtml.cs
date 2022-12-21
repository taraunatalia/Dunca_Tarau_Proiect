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

namespace Dunca_Tarau_Proiect.Pages.Tours
{
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
          var newTour = new Tour();
        if (selectedCategories != null)
        {
          newTour.TourCategories = new List<TourCategory>();
        foreach (var cat in selectedCategories)
        {
          var catToAdd = new TourCategory
        {
          CategoryID = int.Parse(cat)
        };
        newTour.TourCategories.Add(catToAdd);
        }
        }
        //Tour.TourCategories = newTour.TourCategories;
        _context.Tour.Add(newTour);
        await _context.SaveChangesAsync();
        return RedirectToPage("./Index");
            PopulateAssignedCategoryData(_context, newTour);
            return Page();

        }

    }

}

