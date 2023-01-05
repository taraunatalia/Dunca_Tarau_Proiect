using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Dunca_Tarau_Proiect.Data;
using Dunca_Tarau_Proiect.Models;

namespace Dunca_Tarau_Proiect.Pages.Borrowings
{
    public class CreateModel : PageModel
    {
        private readonly Dunca_Tarau_Proiect.Data.Dunca_Tarau_ProiectContext _context;

        public List<SelectListItem> Tours { get; set; }
        
        public List<SelectListItem> Members { get; set; }

        public CreateModel(Dunca_Tarau_Proiect.Data.Dunca_Tarau_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var tours = _context.Tour.ToList();
            var members = _context.Member.ToList();

            Tours = tours.Select(t => new SelectListItem(t.Name, t.ID.ToString())).ToList();
            Members = members.Select(m => new SelectListItem(m.FullName, m.ID.ToString())).ToList();
            
            return Page();
        }

        [BindProperty]
        public Borrowing Borrowing { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Borrowing.Add(Borrowing);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
