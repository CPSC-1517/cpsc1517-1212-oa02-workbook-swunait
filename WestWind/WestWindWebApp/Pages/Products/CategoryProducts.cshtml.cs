using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using WestWindSystem.BLL;   // for CategoryServices
using WestWindSystem.Entities;  // for Category

namespace WestWindWebApp.Pages.Products
{
    public class CategoryProductsModel : PageModel
    {
        private readonly CategoryServices _categoryServices;
        private readonly ProductServices _productServices;
        private readonly SupplierServices _supplierServices;

        public CategoryProductsModel(
            CategoryServices categoryServices, 
            ProductServices productServices,
            SupplierServices supplierServices)
        {
            _categoryServices = categoryServices;
            _productServices = productServices;
            _supplierServices = supplierServices;

            SupplierList = _supplierServices.Supplier_List();
        }

        public List<Supplier> SupplierList { get; set; } = new();
        public List<Product> CategoryProductList { get; private set; } = new();
        public List<Category> CategoryList { get; private set; } = new();

        [BindProperty(SupportsGet = true)]
        public int SelectedCategoryID { get; set; } 

        [TempData]
        public string FeedbackMessage { get; set; }


        public void OnGet()
        {
            CategoryList = _categoryServices.Category_List();

            if (SelectedCategoryID > 0)
            {
                CategoryProductList = _productServices.Product_GetByCategoryID(SelectedCategoryID);
                FeedbackMessage = $"Query return {CategoryProductList.Count} record(s).";
            }

        }

        public IActionResult OnPostFetch()
        {            
            return RedirectToPage("/Products/CategoryProducts", 
                new { SelectedCategoryID = SelectedCategoryID });
        }

        public void OnPostClear()
        {

        }

        public void OnPostNew()
        {

        }
    }
}
