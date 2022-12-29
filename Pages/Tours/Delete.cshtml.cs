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

namespace Dunca_Tarau_Proiect.Pages.Tours
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
      public Tour Tour { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tour == null)
            {
                return NotFound();
            }

            var tour = await _context.Tour.FirstOrDefaultAsync(m => m.ID == id);

            if (tour == null)
            {
                return NotFound();
            }
            else 
            {
                Tour = tour;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Tour == null)
            {
                return NotFound();
            }
            var tour = await _context.Tour.FindAsync(id);

            if (tour != null)
            {
                Tour = tour;
                _context.Tour.Remove(Tour);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
