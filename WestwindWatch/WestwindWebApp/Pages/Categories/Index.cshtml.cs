using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using WestwindSystem.BLL;       // for CategoryServices
using WestwindSystem.Entities;  // for Category

namespace WestwindWebApp.Pages.Categories
{
    public class IndexModel : PageModel
    {
        #region use dependency injection to assign value to categoryServices
        private readonly CategoryServices _categoryServices;

        public IndexModel(CategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }
        #endregion

        #region properties access by web page
        public List<Category> CategoryList { get; set; } = new();

        #endregion


        public void OnGet() // This method gets executed in response to an HTTP GET request
        {
            CategoryList = _categoryServices.Category_List();
        }
    }
}
