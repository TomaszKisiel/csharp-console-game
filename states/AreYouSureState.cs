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


//        private int cursorPos = 0;
//        private string[] options = { "NOWA GRA", "WCZYTAJ GRE", "KONIEC GRY" };
//
//        public override void Draw() {
//            Headers.Menu();
//
//            for ( int i = 0; i < options.Length; i++ ) {
//                if ( cursorPos == i ) {
//                    Console.ForegroundColor = ConsoleColor.Red;
//                    Console.Write("> ");
//                    Console.ForegroundColor = ConsoleColor.White;
//                } else {
//                    Console.Write("  ");
//                }
//
//                Console.WriteLine( options[i] );
//            }
//            Console.WriteLine();
//        }
//
//        public override void Hints() {
//            Utils.PrintHint( "[SPACE]", "Wybierz" );
//            Utils.PrintHint( "[W]", "Góra" );
//            Utils.PrintHint( "[S]", "Dół" );
//            Console.WriteLine();
//        }
//
//        public override void HandleKeyPress( char choice ) {
//            if ( choice == 'w' ) {
//                cursorPos = ( cursorPos - 1 ) % options.Length;
//                if ( cursorPos < 0 ) {
//                    cursorPos = options.Length - 1;
//                }
//            } else if ( choice == 's' ) {
//                cursorPos = ( cursorPos + 1 ) % options.Length;
//            } else if ( choice == (char) 32 ) {
//                if ( options[ cursorPos ] == "NOWA GRA" ) {
//                    Console.WriteLine( "Jeszcze nie czas" );
//                } else if ( options[ cursorPos ] == "WCZYTAJ GRE" ) {
//                    // WCZYTAJ
//                } else if ( options[ cursorPos ] == "KONIEC GRY" ) {
//                    Console.Clear();
//                    Console.WriteLine( Utils.Yellow + "DZIĘKUJE ZA GRE - DO ZOBACZENIA :3\n" + Utils.White );
//                    Environment.Exit(0);
//                }
//            }
//        }

    }
}
