using AutoMapper;
using DigiShop.Catalog.API.Exceptions;
using DigiShop.Catalog.API.Models;
using DigiShop.Catalog.API.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace DigiShop.Catalog.API.Controllers
{
    [ApiController]
    public class CatalogProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICatalogService _catalogService;

        public CatalogProductController(IMapper mapper, ICatalogService catalogService)
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

        [HttpGet("catalog/product", Name = "GetProductById")]
        public async Task<IActionResult> GetProductById([FromQuery][Required] int productId)
        {
            try
            {
                var response = await _catalogService.GetProductById(productId);
                if (response.State)
                {
                    return StatusCode(StatusCodes.Status200OK, response.Data);
                }
                else
                {
                    return NotFound(new List<ProblemDetails>() { new ProblemDetails() { Status = response.ErrorCode, Type = "catalogapi", Title = response.ErrorMessage, Detail = response.ErrorMessage, Instance = "/catalog/brand" } });
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

        [Route("catalog/products"), HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] int? brandId, [FromQuery] int? categoryId, [FromQuery] float? priceStartRange, [FromQuery] float? priceEndRange, [FromQuery] int pageSize = 6, [FromQuery] int pageIndex = 0)
        {
            try
            {
                var response = await _catalogService.GetProducts(brandId, categoryId, priceStartRange, priceEndRange, pageSize, pageIndex);
                if (response.State)
                {
                    return StatusCode(StatusCodes.Status200OK, response.Data);
                }
                else
                {
                    return NotFound(new List<ProblemDetails>() { new ProblemDetails() { Status = response.ErrorCode, Type = "catalogapi", Title = response.ErrorMessage, Detail = response.ErrorMessage, Instance = "/catalog/brand" } });
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

        [Route("catalog/product"), HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody][Required] ProductRequest productRequest, [Required][FromQuery] int productId)
        {
            try
            {
                var response = await _catalogService.UpdateProduct(productId, productRequest);
                if (response.State)
                {
                    return StatusCode(StatusCodes.Status200OK, new { Id = response.Data, response = "Updated" });
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

        [Route("/catalog/product"), HttpDelete]
        public async Task<IActionResult> DeleteProduct([FromQuery][Required] int productId)
        {
            try
            {
                var response = await _catalogService.DeleteProduct(productId);
                if (response.State)
                {
                    return StatusCode(StatusCodes.Status200OK, new { Id = response.Data, response = "Deleted" });
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
    }
}