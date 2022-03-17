using WestwindSystem.DAL;   // for WestwindContext
using WestwindSystem.Entities;  // for Category

namespace WestwindSystem.BLL
{
    public class CategoryServices
    {
        #region Setup a dbcontext using dependency injection
        // Define a readonly field for the database context that will be assiged 
        // a value in the constructor
        private readonly WestwindContext _context;

        internal CategoryServices(WestwindContext context)
        {
            _context = context;
        }
        #endregion

        public List<Category> Category_List()
        {
            return _context
                .Categories
                .OrderBy(currentItem => currentItem.CategoryName)   // Sort the results by CategoryName
                .ToList();
        }

        public Category? Category_GetById(int categoryId)
        {
            return _context
                .Categories
                .Where(currentItem => currentItem.CategoryId == categoryId)
                .FirstOrDefault();
        }

    }
}
