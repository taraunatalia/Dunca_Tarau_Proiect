using Microsoft.AspNetCore.Mvc.RazorPages;
using Dunca_Tarau_Proiect.Data;

namespace Dunca_Tarau_Proiect.Models
{
    public class TourCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Dunca_Tarau_ProiectContext context,
        Tour tour)
        {
            var allCategories = context.Category;
            var tourCategories = new HashSet<int>(
            tour.TourCategories.Select(c => c.CategoryID)); //
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = tourCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateTourCategories(Dunca_Tarau_ProiectContext context,
        string[] selectedCategories, Tour tourToUpdate)
        {
            if (selectedCategories == null)
            {
                tourToUpdate.TourCategories = new List<TourCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var tourCategories = new HashSet<int>
            (tourToUpdate.TourCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!tourCategories.Contains(cat.ID))
                    {
                        tourToUpdate.TourCategories.Add(
                        new TourCategory
                        {
                            TourID = tourToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (tourCategories.Contains(cat.ID))
                    {
                        TourCategory courseToRemove
                        = tourToUpdate
                        .TourCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
