using CatalogoJogos.InputModel;
using CatalogoJogos.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogoJogos.Services
{
    public interface IGameServices : IDisposable
    {
        Task<List<GameViewModel>> Obtain(int page, int amount);
        Task<GameViewModel> Obtain(Guid id);
        Task<GameViewModel> Insert(GameInputModel game);
        Task Update(Guid id, GameInputModel game);
        Task Update(Guid id, double preco);
        Task Delete(Guid id);


    }
}
