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
    public class CatalogCategoryController : ControllerBase
    {
        private readonly ICatalogService _catalogService;
        private readonly ICatalogLogic _catalogLogic;

        public CatalogCategoryController(ICatalogService catalogService,ICatalogLogic catalogLogic)
        {
            _catalogService = catalogService;
            _catalogLogic = catalogLogic;
        }

        [Route("catalog/category"), HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] CategoryRequest categoryRequest)
        {
            try
            {
                var response = await _catalogService.AddCategory(categoryRequest);
                if (response.State)
                {
                    return CreatedAtRoute("GetCategoryById", new { categoryId = response.Data }, new { result = "Created" });
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

        [HttpGet("catalog/category", Name = "GetCategoryById")]
        public async Task<IActionResult> GetCategoryById([FromQuery][Required] int categoryId)
        {
            try
            {
                var response = await _catalogService.GetCategoryById(categoryId);
                if (response.State)
                {
                    return StatusCode(StatusCodes.Status200OK, response.Data);
                }
                else
                {
                    return NotFound(new List<ProblemDetails>() { new ProblemDetails() { Status = response.ErrorCode, Type = "catalogapi", Title = response.ErrorMessage, Detail = response.ErrorMessage, Instance = "/catalog/category" } });
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