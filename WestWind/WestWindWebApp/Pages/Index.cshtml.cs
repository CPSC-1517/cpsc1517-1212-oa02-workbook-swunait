using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WestWindWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;


        Random rand = new Random();

        public string[] names = { "Shane", "Kim", "Nidaa", "Nghi", "Ian" };

        public string RandomName { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            int randomIndex = rand.Next(0, names.Length);
            RandomName = names[randomIndex];

        }
    }
}