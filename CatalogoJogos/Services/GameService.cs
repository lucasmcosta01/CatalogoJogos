using CatalogoJogos.Exceptions;
using CatalogoJogos.InputModel;
using CatalogoJogos.Services.Entities;
using CatalogoJogos.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoJogos.Services
{
    public class GameService : IGameServices
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<List<GameViewModel>> Obtain(int page, int amount)
        {
            var games = await _gameRepository.Obtain(page, amount);

            return games.Select(games => new GameViewModel
                                {
                                Id = games.Id,
                                Name = games.Name,
                                Producer = games.Producer,
                                Preco = games.Preco
                                })
                               .ToList();
        }

        public async Task<GameViewModel> Obtain(Guid id)
        {
            var game = await _gameRepository.Obtain(id);

            if (game == null)
                return null;

            return new GameViewModel
            {
                Id = game.Id,
                Name = game.Name,
                Producer = game.Producer,
                Preco = game.Preco
            };
        }

        public async Task<GameViewModel> Insert(GameInputModel game)
        {
            var entityGame = await _gameRepository.Obtain(game.Name, game.Producer);

            if (entityGame.Count > 0)
                throw new GameAlreadyRegisteredExceptions();

            var gameInsert = new Game
            {
                Id = Guid.NewGuid(),
                Name = game.Name,
                Producer = game.Producer,
                Preco = game.Preco
            };

            await _gameRepository.Insert(gameInsert);

            return new GameViewModel
            {
                Id = gameInsert.Id,
                Name = game.Name,
                Producer = game.Producer,
                Preco = game.Preco
            };
        }

        public async Task Update(Guid id, GameInputModel game)
        {
            var entityGame = await _gameRepository.Obtain(id);

            if (entityGame == null)
                throw new GameNotRegisteredException ();

            entityGame.Name = game.Name;
            entityGame.Producer = game.Producer;
            entityGame.Preco = game.Preco;

            await _gameRepository.Update(entityGame);
        }

        public async Task Update(Guid id, double preco)
        {
            var entityGame = await _gameRepository.Obtain(id);

            if (entityGame == null)
                throw new GameNotRegisteredException();

            entityGame.Preco = preco;

            await _gameRepository.Update(entityGame);
        }

        public async Task Delete(Guid id)
        {
            var jogo = await _gameRepository.Obtain(id);

            if (jogo == null)
                throw new GameNotRegisteredException();

            await _gameRepository.Delete(id);
        }

        public void Dispose()
        {
            _gameRepository?.Dispose();
        }

    }
}
