using System;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            // Finally… spaghetti oriented programming has been extracted :3
            GameController game = GameController.GetInstance();
            game.Start();
        }
    }
}
