using DigiShop.Catalog.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace DigiShop.Catalog.API.Controllers
{
    public class CatalogReviewController : ControllerBase
    {
        private readonly ICatalogService _catalogService;

        public CatalogReviewController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }
    }
}