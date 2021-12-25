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
    public class CatalogBrandController : ControllerBase
    {
        private readonly ICatalogService _catalogService;

        public CatalogBrandController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
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

        [HttpGet("catalog/brand", Name = "GetBrandById")]
        public async Task<IActionResult> GetBrandById([FromQuery][Required] int brandId)
        {
            try
            {
                var response = await _catalogService.GetBrandById(brandId);
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
    }
}