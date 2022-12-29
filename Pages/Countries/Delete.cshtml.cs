using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dunca_Tarau_Proiect.Data;
using Dunca_Tarau_Proiect.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Dunca_Tarau_Proiect.Pages.Countries
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly Dunca_Tarau_Proiect.Data.Dunca_Tarau_ProiectContext _context;

        public DeleteModel(Dunca_Tarau_Proiect.Data.Dunca_Tarau_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Country Country { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Country == null)
            {
                return NotFound();
            }

            var country = await _context.Country.FirstOrDefaultAsync(m => m.ID == id);

            if (country == null)
            {
                return NotFound();
            }
            else 
            {
                Country = country;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Country == null)
            {
                return NotFound();
            }
            var country = await _context.Country.FindAsync(id);

            if (country != null)
            {
                Country = country;
                _context.Country.Remove(Country);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
