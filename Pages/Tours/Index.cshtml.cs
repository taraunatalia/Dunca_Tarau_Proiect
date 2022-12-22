using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dunca_Tarau_Proiect.Data;
using Dunca_Tarau_Proiect.Models;
using System.Net;
using Microsoft.Data.SqlClient;
using System.Threading;

namespace Dunca_Tarau_Proiect.Pages.Tours
{
    public class IndexModel : PageModel
    {
        private readonly Dunca_Tarau_Proiect.Data.Dunca_Tarau_ProiectContext _context;

        public IndexModel(Dunca_Tarau_Proiect.Data.Dunca_Tarau_ProiectContext context)
        {
            _context = context;
        }

        public IList<Tour> Tour { get; set; } = default!;
        public TourData TourD { get; set; }
        public int TourID { get; set; }
        public int CategoryID { get; set; }

        public string GroupSizeSort { get; set; }
        public string TimeSort { get; set; }

        public string CurrentFilter { get; set; }


        public async Task OnGetAsync(int? id, int? categoryID, string sortOrder, string
searchString)
        {
            TourD = new TourData();

            GroupSizeSort = String.IsNullOrEmpty(sortOrder) ? "groupsize_desc" : "";
            TimeSort = String.IsNullOrEmpty(sortOrder) ? "time_desc" : "";

            CurrentFilter = searchString;

            TourD.Tours = await _context.Tour
            .Include(b => b.Country)
            .Include(b => b.TourCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Name)
            .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                TourD.Tours = TourD.Tours.Where(s => s.Time.Contains(searchString)

               || s.GroupSize.Contains(searchString));
            }

            if (id != null)
            {
                TourID = id.Value;
                Tour tour = TourD.Tours
                .Where(i => i.ID == id.Value).Single();
                TourD.Categories = tour.TourCategories.Select(s => s.Category);
            }

            switch (sortOrder)
            {
                case "groupsize_desc":
                    TourD.Tours = TourD.Tours.OrderByDescending(s =>
                   s.GroupSize);
                    break;
                case "time_desc":
                    TourD.Tours = TourD.Tours.OrderByDescending(s =>
                   s.Time);
                    break;


            }
        }
    }
}
