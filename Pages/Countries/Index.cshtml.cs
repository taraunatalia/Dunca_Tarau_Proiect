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
using System.Security.Policy;

namespace Dunca_Tarau_Proiect.Pages.Countries
{
    public class IndexModel : PageModel
    {
        private readonly Dunca_Tarau_Proiect.Data.Dunca_Tarau_ProiectContext _context;

        public IndexModel(Dunca_Tarau_Proiect.Data.Dunca_Tarau_ProiectContext context)
        {
            _context = context;
        }

        public IList<Country> Country { get;set; } = default!;

        public CountryIndexData CountryData { get; set; }
        public int CountryID { get; set; }
        public int TourID { get; set; }

        public async Task OnGetAsync(int? id, int? tourID)
        {
            CountryData = new CountryIndexData();
            CountryData.Countries = await _context.Country
            .Include(i => i.Tours)
            .OrderBy(i => i.CountryName)
            .ToListAsync();
            if (id != null)
            {
                CountryID = id.Value;
                Country country = CountryData.Countries
                .Where(i => i.ID == id.Value).Single();
                CountryData.Tours = country.Tours;
            }

        }
    }
}
