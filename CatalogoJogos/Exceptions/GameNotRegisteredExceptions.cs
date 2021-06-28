using System;

namespace CatalogoJogos.Exceptions
{
    public class GameNotRegisteredException : Exception

    {
        public GameNotRegisteredException()
            :base("This game is not registered")
        {

        }
    }
}
