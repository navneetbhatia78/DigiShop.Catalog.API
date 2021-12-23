using AutoMapper;
using DigiShop.Catalog.API.Exceptions;
using DigiShop.Catalog.API.Models;
using DigiShop.Catalog.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
    }
}