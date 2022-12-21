using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dunca_Tarau_Proiect.Data;
using Dunca_Tarau_Proiect.Models;

namespace Dunca_Tarau_Proiect.Pages.Tours
{
    public class DetailsModel : PageModel
    {
        private readonly Dunca_Tarau_Proiect.Data.Dunca_Tarau_ProiectContext _context;

        public DetailsModel(Dunca_Tarau_Proiect.Data.Dunca_Tarau_ProiectContext context)
        {
            _context = context;
        }

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
    }
}
