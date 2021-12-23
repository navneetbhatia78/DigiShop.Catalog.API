using DigiShop.Catalog.API.Models;
using System.Threading.Tasks;

namespace DigiShop.Catalog.API.Repository
{
    public interface ICatalogRepository
    {
        Task<int> AddProduct(Product product);

        Task<int> AddBrand(Brand brand);
        Task<int> AddCategory(Category category);
    }
}