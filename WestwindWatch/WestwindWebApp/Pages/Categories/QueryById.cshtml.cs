using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using WestwindSystem.BLL;       // for CategoryServices
using WestwindSystem.Entities;  // for Category

namespace WestwindWebApp.Pages.Categories
{
    public class QueryByIdModel : PageModel
    {
        // Define a readonly field for CategoryServices
        private readonly CategoryServices _categoryServices;

        // Define greedy constructor with an CategoryServices that is injected by the container
        public QueryByIdModel(CategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        // Define an auto-implemented property for feedback messages
        [TempData]
        public string FeedbackMessage { get; set; } 

        // Define an auto-implemented property for the search value
        [BindProperty(SupportsGet =true)] // allow this property to matched to a routing parameter of the same name
        public int searchId { get; set; }

        // Defne an auto-implemented property for the search result
        public Category searchSingleResult { get; set; }

        public void OnGet()
        {
            if (searchId > 0)
            {
                searchSingleResult = _categoryServices.Category_GetById(searchId);
                if (searchSingleResult == null)
                {
                    FeedbackMessage = $"No result returned for category id {searchId}.";
                }
                else
                {
                    FeedbackMessage = $"CategoryID: {searchSingleResult.CategoryId} <br />"
                        + $"CategoryName: <strong>{searchSingleResult.CategoryName}</strong> <br />"
                        + $"Description: <em>{searchSingleResult.Description}</em>";
                }
            }
        }

        public IActionResult OnPostFetch()
        {
            // Check if the search value is valid
            if (searchId <= 0)
            {
                FeedbackMessage = "Required: Enter a category id to search for";
            }

            return RedirectToPage(new { searchId = searchId });
        }

    }
}
