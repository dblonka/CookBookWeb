using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CookBook.Repositories.Models {
    public class Recipe : Entity {
        public string Name { get; set; } = string.Empty;
    }
}
