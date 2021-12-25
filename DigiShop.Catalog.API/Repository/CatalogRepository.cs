using DigiShop.Catalog.API.Exceptions;
using DigiShop.Catalog.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<int> DeleteProduct(int productId)
        {
            try
            {
                var product = _catalogContext.Product.SingleOrDefault(p => p.ProductId == productId);
                _catalogContext.Product.Remove(product);
                await _catalogContext.SaveChangesAsync();
                return productId;
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

        public async Task<Brand> GetBrandById(int brandId)
        {
            try
            {
                return _catalogContext.Brand.SingleOrDefault(c => c.BrandId == brandId);
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

        public async Task<Category> GetCategoryById(int categoryId)
        {
            try
            {
                return _catalogContext.Category.SingleOrDefault(p => p.CategoryId == categoryId);
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

        public async Task<Product> GetProductById(int productId)
        {
            try
            {
                return _catalogContext.Product.SingleOrDefault(p => p.ProductId == productId);
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

        public async Task<PaginatedItemsViewModel<List<ProductResponse>>> GetProducts(int? brandId, int? categoryId, float? priceStartRange, float? priceEndRange, int pageSize, int pageIndex)
        {
            try
            {
                PaginatedItemsViewModel<List<ProductResponse>> paginatedItemsViewModel;
                var response = _catalogContext.Product.AsQueryable();
                var res = from prod in response
                          join categ in _catalogContext.Category
                          on prod.CategoryId equals categ.CategoryId
                          join brand in _catalogContext.Brand
                          on prod.BrandId equals brand.BrandId
                          where brandId != null ? prod.BrandId == brandId : true
                          && categoryId != null ? prod.CategoryId == categoryId : true
                          && priceStartRange != null ? prod.Price >= priceStartRange : true
                          && priceEndRange != null ? prod.Price <= priceEndRange : true
                          select new ProductResponse()
                          {
                              ProductId = prod.ProductId,
                              ProductBrand = brand.BrandName,
                              ProductCategory = categ.CategoryName,
                              ProductName = prod.ProductName,
                              ProductImage = prod.ImagePath,
                              ProductPrice = prod.Price
                          };
                int count = res.Count();

                var productResponse = res.Skip(pageIndex * pageSize).Take(pageSize).ToList();
                paginatedItemsViewModel = new PaginatedItemsViewModel<List<ProductResponse>>(pageSize, pageIndex, count, productResponse);
                return paginatedItemsViewModel;
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

        public async Task<int> UpdateProduct(Product product)
        {
            try
            {
                _catalogContext.Product.Update(product);
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