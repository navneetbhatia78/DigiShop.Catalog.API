using DigiShop.Catalog.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigiShop.Catalog.API.Service
{
    public interface ICatalogService
    {
        Task<ApplicationResponse<int>> AddProduct(ProductRequest product);

        Task<ApplicationResponse<int>> AddBrand(BrandRequest brandRequest);

        Task<ApplicationResponse<int>> AddCategory(CategoryRequest categoryRequest);

        Task<ApplicationResponse<BrandDto>> GetBrandById(int brandId);

        Task<ApplicationResponse<ProductDetailDto>> GetProductById(int productId);

        Task<ApplicationResponse<CategoryDto>> GetCategoryById(int categoryId);

        Task<ApplicationResponse<PaginatedItemsViewModel<List<ProductResponse>>>> GetProducts(int? brandId, int? categoryId, float? priceStartRange, float? priceEndRange, int pageSize, int pageIndex);

        Task<ApplicationResponse<int>> UpdateProduct(int productId, ProductRequest productRequest);

        Task<ApplicationResponse<int>> DeleteProduct(int productId);
    }
}