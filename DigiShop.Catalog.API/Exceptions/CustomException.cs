using Microsoft.AspNetCore.Mvc;
using System;

namespace DigiShop.Catalog.API.Exceptions
{
    public class CustomException : Exception
    {
        public ProblemDetails Error { get; set; }
    }
}