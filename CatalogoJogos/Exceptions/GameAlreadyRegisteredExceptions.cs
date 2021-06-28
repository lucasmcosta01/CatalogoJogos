using System;

namespace CatalogoJogos.Exceptions
{
    public class GameAlreadyRegisteredExceptions : Exception
    {
        public GameAlreadyRegisteredExceptions()
            :base("Game already registered")
        { }
    }
}
