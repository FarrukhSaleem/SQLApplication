using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SQLApplication.Models;
using SQLApplication.Services;

namespace SQLApplication.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> Products;

        public void OnGet()
        {
            ProductService productsService = new ProductService();
            Products=productsService.GetProducts();
        }
    }
}
