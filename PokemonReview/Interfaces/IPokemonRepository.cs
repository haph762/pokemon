using PokemonReview.Models;

namespace PokemonReview.Interfaces
{
    public interface IPokemonRepository
    {
        public ICollection<Pokemon> GetPokemons();
    }
}
