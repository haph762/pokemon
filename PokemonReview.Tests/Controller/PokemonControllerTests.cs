using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using PokemonReview.Controllers;
using PokemonReview.Dto;
using PokemonReview.Interfaces;
using PokemonReview.Models;

namespace PokemonReview.Tests.Controller
{
    public class PokemonControllerTests
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IReviewRepository _reviewsRepository;
        private readonly IMapper _mapper;
        public PokemonControllerTests()
        {
            _pokemonRepository = A.Fake<IPokemonRepository>();
            _reviewsRepository = A.Fake<IReviewRepository>();
            _mapper = A.Fake<IMapper>();
        }

        [Fact]
        public void PokemonControler_GetPokemons_RetunOk()
        {
            //arrange
            var pokemons = A.Fake<ICollection<PokemonDto>>();
            var pokemonList = A.Fake<List<PokemonDto>>();
            A.CallTo(() => _mapper.Map<List<PokemonDto>>(pokemons)).Returns(pokemonList);
            var controller = new PokemonController(_pokemonRepository, _mapper, _reviewsRepository);

            //act
            var result = controller.GetPokemons();

            //assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void PokemonController_CreatePokemon_ReturnOk()
        {
            //arrange
            int ownerId = 1;
            int catId = 2;
            var pokemon = A.Fake<Pokemon>();
            var pokemonCreate = A.Fake<PokemonDto>();
            var pokemons = A.Fake<ICollection<PokemonDto>>();
            var pokemonList = A.Fake<List<PokemonDto>>();
            A.CallTo(() => _pokemonRepository.GetPokemonTrimToUpper(pokemonCreate)).Returns(pokemon);
            A.CallTo(() => _mapper.Map<Pokemon>(pokemonCreate)).Returns(pokemon);
            A.CallTo(() => _pokemonRepository.CreatePokemon(ownerId, catId, pokemon)).Returns(true);
            var controller = new PokemonController(_pokemonRepository, _mapper, _reviewsRepository);

            //act
            var result = controller.CreatePokemon(ownerId, catId, pokemonCreate);

            //Assert
            result.Should().NotBeNull();
        }
    }
}
