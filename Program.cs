using System;

namespace RGame {
    public class Program {
        public static void Main( string[] args ) {
            // Finally… spaghetti oriented programming has been extracted :3
            // Demeter płakała jak commit'owała..
            GameController.Instance().Start();
        }
    }
}
