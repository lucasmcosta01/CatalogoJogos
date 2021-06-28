using System;

namespace CatalogoJogos.ViewModel
{
    public class GameViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Producer { get; set; }
        public double Preco { get; set; }
    }
}
