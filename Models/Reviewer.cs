#nullable disable
namespace PokemonReview.Models
{
    public class Reviewer
    {
        public int Id { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}