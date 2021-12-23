using AutoMapper;
using DigiShop.Catalog.API.Exceptions;
using DigiShop.Catalog.API.Models;
using DigiShop.Catalog.API.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigiShop.Catalog.API.Controllers
{
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICatalogService _catalogService;

        public CatalogController(IMapper mapper, ICatalogService catalogService)
        {
            _mapper = mapper;
            _catalogService = catalogService;
        }

        [Route("catalog/product"), HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductRequest productRequest)
        {
            try
            {
                var response = await _catalogService.AddProduct(productRequest);
                if (response.State)
                {
                    return CreatedAtRoute("GetProductById", new { productId = response.Data }, new { result = "Done" });
                }
                else
                {
                    return StatusCode(response.ErrorCode, response.ErrorMessage);
                }
            }
            catch (CustomException customException)
            {
                if (customException.Error.Status == StatusCodes.Status400BadRequest)
                {
                    return BadRequest(new List<ProblemDetails>() { new ProblemDetails() { Status = StatusCodes.Status400BadRequest, Type = "catalogapi", Title = customException.Error.Title, Detail = customException.Error.Detail } });
                }
                else if (customException.Error.Status == StatusCodes.Status500InternalServerError)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Unexpected Error");
                }
                else
                {
                    return UnprocessableEntity(new List<ProblemDetails>() { new ProblemDetails() { Status = StatusCodes.Status422UnprocessableEntity, Type = "catalogapi", Title = customException.Error.Title, Detail = customException.Error.Detail } });
                }
            }
        }

        [Route("catalog/brand"), HttpPost]
        public async Task<IActionResult> AddBrand([FromBody] BrandRequest brandRequest)
        {
            try
            {
                var response = await _catalogService.AddBrand(brandRequest);
                if (response.State)
                {
                    return CreatedAtRoute("GetBrandById", new { brandId = response.Data }, new { result = "Created" });
                }
                else
                {
                    return StatusCode(response.ErrorCode, response.ErrorMessage);
                }
            }
            catch (CustomException customException)
            {
                if (customException.Error.Status == StatusCodes.Status400BadRequest)
                {
                    return BadRequest(new List<ProblemDetails>() { new ProblemDetails() { Status = StatusCodes.Status400BadRequest, Type = "catalogapi", Title = customException.Error.Title, Detail = customException.Error.Detail } });
                }
                else if (customException.Error.Status == StatusCodes.Status500InternalServerError)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Unexpected Error");
                }
                else
                {
                    return UnprocessableEntity(new List<ProblemDetails>() { new ProblemDetails() { Status = StatusCodes.Status422UnprocessableEntity, Type = "catalogapi", Title = customException.Error.Title, Detail = customException.Error.Detail } });
                }
            }
        }

        [Route("catalog/category"),HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] CategoryRequest categoryRequest)
        {
            try
            {
                var response = await _catalogService.AddCategory(categoryRequest);
                if (response.State)
                {
                    return CreatedAtRoute("GetCategoryById",new { categoryId = response.Data},new { result= "Created"});
                }
                else
                {
                    return StatusCode(response.ErrorCode, response.ErrorMessage);
                }

            }
            catch (CustomException customException)
            {
                if (customException.Error.Status == StatusCodes.Status400BadRequest)
                {
                    return BadRequest(new List<ProblemDetails>() { new ProblemDetails() { Status = StatusCodes.Status400BadRequest, Type = "catalogapi", Title = customException.Error.Title, Detail = customException.Error.Detail } });
                }
                else if (customException.Error.Status == StatusCodes.Status500InternalServerError)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Unexpected Error");
                }
                else
                {
                    return UnprocessableEntity(new List<ProblemDetails>() { new ProblemDetails() { Status = StatusCodes.Status422UnprocessableEntity, Type = "catalogapi", Title = customException.Error.Title, Detail = customException.Error.Detail } });
                }
            }

        }

        [HttpGet("catalog/brand", Name = "GetBrandById")]
        public async Task<IActionResult> GetBrandById([FromQuery] int brandId)
        {
            return Ok(brandId);
        }

        [HttpGet("product", Name = "GetProductById")]
        public async Task<IActionResult> GetProductById([FromQuery] int productId)
        {
            return Ok(productId);
        }

        [HttpGet("catalog/category", Name = "GetCategoryById")]
        public async Task<IActionResult> GetCategoryById([FromQuery] int categoryId)
        {
            return Ok(categoryId);
        }
    }
}