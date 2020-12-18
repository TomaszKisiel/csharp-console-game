using System;
using System.Collections.Generic;

namespace RGame {
    class AreYouSureState : GameState {
        private const string END_GAME = "ZAKOŃCZ";
        private const string CANCEL = "ANULUJ";

        private Menu menu = new Menu(
            new List<string>() { END_GAME, CANCEL }
        );

        public override void Draw() {
            Headers.Menu();

            Console.WriteLine("Czy jesteś pewny, że chcesz zakończyć grę? Pamiętaj, że niezapisane zmiany zostaną utracone.");
            Console.WriteLine();

            menu.Draw();
        }

        public override void DrawHints() {
            Hints.Menu();
        }

        public override bool HandleKeyPress( char choice ) {
            if ( menu.HandleKeyPress( choice) ) {
                return true;
            } else if ( choice == (char) 32 ) {
                if ( menu.GetCurrent() == END_GAME ) {
                    Console.Clear();
                    Environment.Exit(0);
                } else if ( menu.GetCurrent() == CANCEL ) {
                    this.context.SetState( new PauseMenuState() );
                }

                return true;
            }

            return false;
        }
    }
}
