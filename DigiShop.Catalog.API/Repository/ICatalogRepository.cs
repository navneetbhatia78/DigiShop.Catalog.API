using DigiShop.Catalog.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigiShop.Catalog.API.Repository
{
    public interface ICatalogRepository
    {
        Task<int> AddProduct(Product product);

        Task<int> AddBrand(Brand brand);

        Task<int> AddCategory(Category category);

        Task<Brand> GetBrandById(int brandId);

        Task<Product> GetProductById(int productId);

        Task<Category> GetCategoryById(int categoryId);

        Task<PaginatedItemsViewModel<List<ProductResponse>>> GetProducts(int? brandId, int? categoryId, float? priceStartRange, float? priceEndRange, int pageSize, int pageIndex);

        Task<int> UpdateProduct(Product product);

        Task<int> DeleteProduct(int productId);
    }
}