using System.ComponentModel.DataAnnotations;

namespace RecipeShare.Models
{
    public class Recipe
    {
        [Key]
        public int RecipeId { get; set; }
        [Required(ErrorMessage = "The recipe title is required.")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Please provide ingredients.")]
        public string Ingredients { get; set; } 
        [Required]
        public string Steps { get; set; }

        [Required(ErrorMessage = "Cooking time is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Cooking time must be greater than zero.")]
        public int CookingTimeMinutes { get; set; }
        public string DietaryTags { get; set; }
    }
}
