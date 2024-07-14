using CookBook.Models;
using CookBook.Repositories;
using CookBook.Repositories.Models;

namespace CookBook.Services
{
    public class RecipeService : IRecipeService {
        private readonly IBaseRepository<Recipe> _repository;
        public RecipeService(IBaseRepository<Recipe> repository) {
            _repository = repository;
        }

        public async Task<ServiceResult<RecipeResponse>> CreateRecipe(RecipeRequest request) {
            try {
                var recipe = new Recipe { Name = request.Name };
                await _repository.Create(recipe);
                var response = new RecipeResponse {
                    Id = recipe.Id,
                    Name = recipe.Name
                };
                return new ServiceResult<RecipeResponse>(response);
            } catch {
                return new ServiceResult<RecipeResponse>("Cant create recipe");
            }
        }
    }
}
