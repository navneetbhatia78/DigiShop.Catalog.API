using DigiShop.Catalog.API.Models;
using System.Threading.Tasks;

namespace DigiShop.Catalog.API.Service
{
    public interface ICatalogService
    {
        public Task<ApplicationResponse<int>> AddProduct(ProductRequest product);

        public Task<ApplicationResponse<int>> AddBrand(BrandRequest brandRequest);
        Task<ApplicationResponse<int>> AddCategory(CategoryRequest categoryRequest);
    }
}