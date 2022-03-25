using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#region Add namespaces for WestWindSystem class library for BLL classes and entity class
using WestWindSystem.BLL;
using WestWindSystem.Entities;
#endregion

namespace WestWindWebApp.Pages.Products
{
    public class QueryModel : PageModel
    {
        #region Define a CategoryServices field and initialize it using constructor injection
        private readonly CategoryServices _categoryServices;
        private readonly ProductServices _productServices;
        public QueryModel(CategoryServices categoryServices, ProductServices productServices)
        {
            _categoryServices = categoryServices;
            _productServices = productServices;
        }
        #endregion

        #region Define properties for data the web page needs to access
        [TempData]
        public string FeedbackMessage { get; set; }
        public List<Category> CategoryList { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public int SelectedCategoryID { get; set; }

        public List<Product> ProductQueryResultList { get; set; } = new();
        #endregion

        public void OnGet()
        {
            CategoryList = _categoryServices.Category_List();

            if (SelectedCategoryID > 0)
            {
                ProductQueryResultList = _productServices.Product_GetByCategoryID(SelectedCategoryID);
                FeedbackMessage = $"Search returned {ProductQueryResultList.Count} result(s).";
            }
        }

        public IActionResult OnPostSearch()
        {
            if (SelectedCategoryID == 0)
            {
                FeedbackMessage = "You must select a category";
            }
            return RedirectToPage(new { SelectedCategoryID = SelectedCategoryID });
        }

        public IActionResult OnPostClear() // This method gets executed when asp-page-handler="Clear"
        {
            FeedbackMessage = "";
            ModelState.Clear();
            ProductQueryResultList.Clear();
            return RedirectToPage(new { SelectedCategoryID = (string?)null });
        }
    }
}
