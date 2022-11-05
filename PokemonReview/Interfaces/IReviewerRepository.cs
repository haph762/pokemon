using PokemonReview.Models;

namespace PokemonReview.Interfaces
{
    public interface IReviewerRepository
    {
        ICollection<Reviewer> GetReviewers();
        Reviewer GetReviewer(int reviewId);
        ICollection<Review> GetReviewsByReviewer(int reviewrId);
        bool ReviewerExists(int reviewerId);
    }
}
