using System;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            GameController game = GameController.GetInstance();
            game.Start();
        }
    }
}
