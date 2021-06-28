using System;

namespace CatalogoJogos.Services.Entities
{
    public class Game
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Producer { get; set; }
        public double Preco { get; set; }
    }
}