using DigiShop.Catalog.API.Exceptions;
using DigiShop.Catalog.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DigiShop.Catalog.API.Repository
{
    public class CatalogRepository : ICatalogRepository
    {
        private readonly CatalogContext _catalogContext;

        public CatalogRepository(CatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }

        public async Task<int> AddBrand(Brand brand)
        {
            try
            {
                await _catalogContext.Brand.AddAsync(brand);
                await _catalogContext.SaveChangesAsync();
                return brand.BrandId;
            }
            catch (Exception)
            {
                throw new CustomException()
                {
                    Error = new ProblemDetails()
                    {
                        Status = StatusCodes.Status500InternalServerError,
                        Type = "CatalogApi",
                        Detail = CatalogConstants.INTERNAL_SERVER_ERROR_500
                    }
                };
            }
        }

        public async Task<int> AddCategory(Category category)
        {
            try
            {
                await _catalogContext.Category.AddAsync(category);
                await _catalogContext.SaveChangesAsync();
                return category.CategoryId;
            }
            catch (Exception)
            {
                throw new CustomException()
                {
                    Error = new ProblemDetails()
                    {
                        Status = StatusCodes.Status500InternalServerError,
                        Type = "CatalogApi",
                        Detail = CatalogConstants.INTERNAL_SERVER_ERROR_500
                    }
                };
            }
        }

        public async Task<int> AddProduct(Product product)
        {
            try
            {
                await _catalogContext.Product.AddAsync(product);
                await _catalogContext.SaveChangesAsync();
                return product.ProductId;
            }
            catch (Exception)
            {
                throw new CustomException()
                {
                    Error = new ProblemDetails()
                    {
                        Status = StatusCodes.Status500InternalServerError,
                        Type = "CatalogApi",
                        Detail = CatalogConstants.INTERNAL_SERVER_ERROR_500
                    }
                };
            }
        }
    }
}