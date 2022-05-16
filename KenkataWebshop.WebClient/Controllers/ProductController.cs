using Microsoft.AspNetCore.Mvc;
using KenkataWebshop.Data;
using KenkataWebshop.WebClient.Models;

namespace KenkataWebshop.WebClient.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClient _httpClient;

        public ProductController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {

            var products = await _httpClient.GetFromJsonAsync<List<ProductDto>>("https://localhost:7009/api/Products");
            var productViewModels = products.MapToViewModel();

            return View(productViewModels);
        }
    }

    public static class ProductMappingExtensions
    {
        public static ProductViewModel MapToViewModel(this ProductDto dto)
        {
            var viewModel = new ProductViewModel
            {
                Name = dto.Name,
            };

            return viewModel;
        }

        public static List<ProductViewModel> MapToViewModel(this List<ProductDto> dtos)
        {
            var viewModels = new List<ProductViewModel>();

            foreach (var dto in dtos)
            {
                viewModels.Add(dto.MapToViewModel());
            }

            return viewModels;
        }
    }
}
