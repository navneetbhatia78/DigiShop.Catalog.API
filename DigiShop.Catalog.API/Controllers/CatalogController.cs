using Microsoft.AspNetCore.Mvc;


namespace DigiShop.Catalog.API.Controllers
{
    [ApiController]
    public class CatalogController : ControllerBase
    {
        [Route("default"),HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello World!!!");    
        }
    }
}
