using AutoMapper;
using DigiShop.Catalog.API.Exceptions;
using DigiShop.Catalog.API.Models;
using DigiShop.Catalog.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigiShop.Catalog.API.Service
{
    public class CatalogService : ICatalogService
    {
        private readonly ICatalogRepository _catalogRepository;
        private readonly IMapper _mapper;

        public CatalogService(ICatalogRepository catalogRepository, IMapper mapper)
        {
            _catalogRepository = catalogRepository;
            _mapper = mapper;
        }

        public async Task<ApplicationResponse<int>> AddBrand(BrandRequest brandRequest)
        {
            try
            {
                ApplicationResponse<int> applicationResponse;
                var brand = _mapper.Map<Brand>(brandRequest);
                var response = await _catalogRepository.AddBrand(brand);
                applicationResponse = new ApplicationResponse<int>()
                {
                    State = true,
                    Data = response
                };
                return applicationResponse;
            }
            catch (CustomException ex)
            {
                throw new CustomException()
                {
                    Error = new ProblemDetails()
                    {
                        Detail = ex.Error.Detail,
                        Type = ex.Error.Type,
                        Status = ex.Error.Status
                    }
                };
            }
            catch (Exception ex)
            {
                throw new CustomException()
                {
                    Error = new ProblemDetails()
                    {
                        Detail = ex.Message,
                        Type = "CatalogApi",
                        Title = "Error in Creating Brand",
                        Instance = "/catalog/brand"
                    }
                };
            }
        }

        public async Task<ApplicationResponse<int>> AddCategory(CategoryRequest categoryRequest)
        {
            try
            {
                ApplicationResponse<int> applicationResponse;
                var category = _mapper.Map<Category>(categoryRequest);
                var response = await _catalogRepository.AddCategory(category);
                applicationResponse = new ApplicationResponse<int>()
                {
                    State = true,
                    Data = response
                };
                return applicationResponse;
            }
            catch (CustomException ex)
            {
                throw new CustomException()
                {
                    Error = new ProblemDetails()
                    {
                        Detail = ex.Error.Detail,
                        Type = ex.Error.Type,
                        Status = ex.Error.Status
                    }
                };
            }
            catch (Exception ex)
            {
                throw new CustomException()
                {
                    Error = new ProblemDetails()
                    {
                        Detail = ex.Message,
                        Type = "CatalogApi",
                        Title = "Error in Creating Brand",
                        Instance = "/catalog/brand"
                    }
                };
            }
        }

        public async Task<ApplicationResponse<int>> AddProduct(ProductRequest productRequest)
        {
            try
            {
                ApplicationResponse<int> applicationResponse;
                var product = _mapper.Map<Product>(productRequest);
                var response = await _catalogRepository.AddProduct(product);
                applicationResponse = new ApplicationResponse<int>()
                {
                    State = true,
                    Data = response
                };
                return applicationResponse;
            }
            catch (CustomException ex)
            {
                throw new CustomException()
                {
                    Error = new ProblemDetails()
                    {
                        Detail = ex.Error.Detail,
                        Type = ex.Error.Type,
                        Status = ex.Error.Status
                    }
                };
            }
            catch (Exception ex)
            {
                throw new CustomException()
                {
                    Error = new ProblemDetails()
                    {
                        Detail = ex.Message,
                        Type = "Productapi",
                        Title = "AddProduct"
                    }
                };
            }
        }

        public async Task<ApplicationResponse<int>> DeleteProduct(int productId)
        {
            try
            {
                var response = await _catalogRepository.DeleteProduct(productId);
                return new ApplicationResponse<int>()
                {
                    State = true,
                    Data = response
                };
            }
            catch (CustomException ex)
            {
                throw new CustomException()
                {
                    Error = new ProblemDetails()
                    {
                        Detail = ex.Error.Detail,
                        Type = ex.Error.Type,
                        Status = ex.Error.Status
                    }
                };
            }
            catch (Exception ex)
            {
                throw new CustomException()
                {
                    Error = new ProblemDetails()
                    {
                        Detail = ex.Message,
                        Type = "Productapi",
                        Title = "GetBrandById"
                    }
                };
            }
        }

        public async Task<ApplicationResponse<BrandDto>> GetBrandById(int brandId)
        {
            try
            {
                ApplicationResponse<BrandDto> applicationResponse;
                var brand = await _catalogRepository.GetBrandById(brandId);
                if (brand != null)
                {
                    var brandResponse = _mapper.Map<BrandDto>(brand);
                    applicationResponse = new ApplicationResponse<BrandDto>()
                    {
                        State = true,
                        Data = brandResponse
                    };
                }
                else
                {
                    applicationResponse = new ApplicationResponse<BrandDto>()
                    {
                        State = false,
                        ErrorCode = StatusCodes.Status404NotFound,
                        ErrorMessage = CatalogConstants.ERROR_404_DESC
                    };
                }
                return applicationResponse;
            }
            catch (CustomException ex)
            {
                throw new CustomException()
                {
                    Error = new ProblemDetails()
                    {
                        Detail = ex.Error.Detail,
                        Type = ex.Error.Type,
                        Status = ex.Error.Status
                    }
                };
            }
            catch (Exception ex)
            {
                throw new CustomException()
                {
                    Error = new ProblemDetails()
                    {
                        Detail = ex.Message,
                        Type = "Productapi",
                        Title = "GetBrandById"
                    }
                };
            }
        }

        public async Task<ApplicationResponse<CategoryDto>> GetCategoryById(int categoryId)
        {
            try
            {
                ApplicationResponse<CategoryDto> applicationResponse;
                var response = await _catalogRepository.GetCategoryById(categoryId);
                if (response != null)
                {
                    var categoryResponse = _mapper.Map<CategoryDto>(response);
                    applicationResponse = new ApplicationResponse<CategoryDto>()
                    {
                        State = true,
                        Data = categoryResponse
                    };
                }
                else
                {
                    applicationResponse = new ApplicationResponse<CategoryDto>()
                    {
                        State = false,
                        ErrorCode = StatusCodes.Status404NotFound,
                        ErrorMessage = CatalogConstants.ERROR_404_DESC
                    };
                }
                return applicationResponse;
            }
            catch (CustomException ex)
            {
                throw new CustomException()
                {
                    Error = new ProblemDetails()
                    {
                        Detail = ex.Error.Detail,
                        Type = ex.Error.Type,
                        Status = ex.Error.Status
                    }
                };
            }
            catch (Exception ex)
            {
                throw new CustomException()
                {
                    Error = new ProblemDetails()
                    {
                        Detail = ex.Message,
                        Type = "Productapi",
                        Title = "GetProduct"
                    }
                };
            }
        }

        public async Task<ApplicationResponse<ProductDetailDto>> GetProductById(int productId)
        {
            try
            {
                ApplicationResponse<ProductDetailDto> applicationResponse;
                var response = await _catalogRepository.GetProductById(productId);
                if (response != null)
                {
                    var productResponse = _mapper.Map<ProductDetailDto>(response);
                    applicationResponse = new ApplicationResponse<ProductDetailDto>()
                    {
                        State = true,
                        Data = productResponse
                    };
                }
                else
                {
                    applicationResponse = new ApplicationResponse<ProductDetailDto>()
                    {
                        State = false,
                        ErrorCode = StatusCodes.Status404NotFound,
                        ErrorMessage = CatalogConstants.ERROR_404_DESC
                    };
                }
                return applicationResponse;
            }
            catch (CustomException ex)
            {
                throw new CustomException()
                {
                    Error = new ProblemDetails()
                    {
                        Detail = ex.Error.Detail,
                        Type = ex.Error.Type,
                        Status = ex.Error.Status
                    }
                };
            }
        }

        public async Task<ApplicationResponse<PaginatedItemsViewModel<List<ProductResponse>>>> GetProducts(int? brandId, int? categoryId, float? priceStartRange, float? priceEndRange, int pageSize, int pageIndex)
        {
            try
            {
                ApplicationResponse<PaginatedItemsViewModel<List<ProductResponse>>> applicationResponse;
                var productsResponse = await _catalogRepository.GetProducts(brandId, categoryId, priceStartRange, priceEndRange, pageSize, pageIndex);
                if (productsResponse != null && productsResponse.TotalItems > 0)
                {
                    applicationResponse = new ApplicationResponse<PaginatedItemsViewModel<List<ProductResponse>>>()
                    {
                        State = true,
                        Data = productsResponse
                    };
                }
                else
                {
                    applicationResponse = new ApplicationResponse<PaginatedItemsViewModel<List<ProductResponse>>>()
                    {
                        State = false,
                        ErrorCode = StatusCodes.Status404NotFound,
                        ErrorMessage = CatalogConstants.ERROR_404_DESC
                    };
                }
                return applicationResponse;
            }
            catch (CustomException ex)
            {
                throw new CustomException()
                {
                    Error = new ProblemDetails()
                    {
                        Detail = ex.Error.Detail,
                        Type = ex.Error.Type,
                        Status = ex.Error.Status
                    }
                };
            }
            catch (Exception ex)
            {
                throw new CustomException()
                {
                    Error = new ProblemDetails()
                    {
                        Detail = ex.Message,
                        Type = "Productapi",
                        Title = "GetProduct"
                    }
                };
            }
        }

        public async Task<ApplicationResponse<int>> UpdateProduct(int productId, ProductRequest productRequest)
        {
            try
            {
                ApplicationResponse<int> applicationResponse;
                var product = _mapper.Map<Product>(productRequest);
                product.ProductId = productId;
                var response = await _catalogRepository.UpdateProduct(product);
                applicationResponse = new ApplicationResponse<int>()
                {
                    State = true,
                    Data = response
                };
                return applicationResponse;
            }
            catch (CustomException ex)
            {
                throw new CustomException()
                {
                    Error = new ProblemDetails()
                    {
                        Detail = ex.Error.Detail,
                        Type = ex.Error.Type,
                        Status = ex.Error.Status
                    }
                };
            }
            catch (Exception ex)
            {
                throw new CustomException()
                {
                    Error = new ProblemDetails()
                    {
                        Detail = ex.Message,
                        Type = "Productapi",
                        Title = "GetProduct"
                    }
                };
            }
        }
    }
}