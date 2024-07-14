using CookBook.Models;

namespace CookBook.Services {
    public interface IRecipeService {
        Task<ServiceResult<RecipeResponse>> CreateRecipe(RecipeRequest request);
    }
}