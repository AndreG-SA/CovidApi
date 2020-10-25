﻿using Microsoft.AspNetCore.Mvc;

namespace Covid.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
