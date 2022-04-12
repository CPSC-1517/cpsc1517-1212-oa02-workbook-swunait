using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using WestWindSystem.BLL;   
using WestWindSystem.Entities;

namespace WestWindWebApp.Pages.Products
{
    public class ProductCRUDModel : PageModel
    {
        private readonly CategoryServices _categoryServices;
        private readonly ProductServices _productServices;
        private readonly SupplierServices _supplierServices;

        public ProductCRUDModel(CategoryServices categoryServices,
            ProductServices productServices,
            SupplierServices supplierServices)
        {
            _categoryServices = categoryServices;   
            _productServices = productServices; 
            _supplierServices = supplierServices;

            SupplierList = _supplierServices.Supplier_List();
            CategoryList = _categoryServices.Category_List();
        }

        public List<Supplier> SupplierList { get; private set; }
        [BindProperty]
        public int? SelectedSupplierID { get; set; }
       
        public List<Category> CategoryList { get; private set; }
        [BindProperty]
        public int? SelectedCategoryID { get; set; }

        [BindProperty]
        public Product CurrentProduct { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? ProductID { get; set; }
        
        public IActionResult OnGet()
        {
            if (ProductID == null)
            {
                CurrentProduct = new Product();
                return Page();
            }

            CurrentProduct = _productServices.Product_GetByID((int)ProductID);
            if (CurrentProduct == null)
            {
                return RedirectToPage("/Products/CategoryProducts");
            }
            return Page();
        }

        [TempData]
        public string FeedbackMessage { get; set; }
        public IActionResult OnPostNew()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int newProductID = _productServices.Product_AddProduct(CurrentProduct);
                    FeedbackMessage = $"ProductID ({newProductID}) has been added to the system";
                    return RedirectToPage(new { productID = newProductID });
                }
                catch (Exception ex)
                {
                    FeedbackMessage = GetInnerException(ex).Message;
                }
            }
            return Page();

        }

        public IActionResult OnPostClear()
        {
            FeedbackMessage = "";
            ModelState.Clear();
            return RedirectToPage(new { productID = (int?) null});
        }

        public IActionResult OnPostSearch()
        {
            return Redirect("/Products/CategoryProducts");
        }

        public IActionResult OnPostUpdate()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int rowsUpdated = _productServices.Product_UpdateProduct(CurrentProduct);
                    FeedbackMessage = $"Successfully updated {rowsUpdated} product";
                }
                catch (Exception ex)
                {
                    FeedbackMessage = $"Error updating product with exception {ex.Message}";
                }
            }

            return Page();
        }

        public IActionResult OnPostDelete()
        {
            try
            {
                int rowsDeleted = _productServices.Product_DeleteProduct(CurrentProduct);
                if (rowsDeleted > 0)
                {
                    FeedbackMessage = $"Successfully discontinued {rowsDeleted} records.";
                    CurrentProduct.Discontinued = true;
                    return RedirectToPage(new { productID = CurrentProduct.ProductID });
                }
                else
                {
                    FeedbackMessage = $"No products were affected. Refresh search and try again.";
                }
               
            }
            catch (Exception ex)
            {
                FeedbackMessage = $"Error deleting product with exception {ex.Message}";
            }
            return Page();
        }


        private Exception GetInnerException(Exception ex)
        {
            //drill down to the REAL ERROR message
            while (ex.InnerException != null)
                ex = ex.InnerException;
            return ex;
        }
    }
}
