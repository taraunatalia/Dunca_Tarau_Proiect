using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Dunca_Tarau_Proiect.Data;
using Dunca_Tarau_Proiect.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Dunca_Tarau_Proiect.Pages.Categories
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly Dunca_Tarau_Proiect.Data.Dunca_Tarau_ProiectContext _context;

        public CreateModel(Dunca_Tarau_Proiect.Data.Dunca_Tarau_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Category.Add(Category);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
