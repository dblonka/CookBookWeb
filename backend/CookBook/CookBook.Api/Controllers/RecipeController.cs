using CookBook.Models;
using CookBook.Services;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _service;
        private readonly ILogger<RecipeController> _logger;

        public RecipeController(IRecipeService service, ILogger<RecipeController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost(Name = "CreateRecipe")]
        public async Task<ActionResult<RecipeResponse>> Create(RecipeRequest request)
        {
            var result = await _service.CreateRecipe(request);
            if (result.IsSuccess) {
                return Ok(result.Value);
            } else {
                return StatusCode(500, result.Error);
            }
        }
        [HttpGet("{id}", Name = "GetRecipe")]
        public async Task<ActionResult<RecipeResponse>> Get(string id) {
            return Ok(null);
        }

    }
}
