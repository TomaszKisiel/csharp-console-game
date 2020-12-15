using System;

namespace Game {
    class MenuState : IGameState {
        private int cursorPos = 0;
        private string[] options = { "NOWA GRA", "WCZYTAJ GRE", "KONIEC GRY" };

        public override void Draw() {
            Headers.Menu();

            for ( int i = 0; i < options.Length; i++ ) {
                if ( cursorPos == i ) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("> ");
                    Console.ForegroundColor = ConsoleColor.White;
                } else {
                    Console.Write("  ");
                }

                Console.WriteLine( options[i] );
            }
            Console.WriteLine();
        }

        public override void Hints()
        {
            Utils.PrintHint( "[SPACE]", "Wybierz" );
            Utils.PrintHint( "[W]", "Góra" );
            Utils.PrintHint( "[S]", "Dół" );
            Console.WriteLine();
        }

        public override void HandleKeyPress( char choice ) {
            if ( choice == 'w' ) {
                cursorPos = ( cursorPos - 1 ) % 10;
                if ( cursorPos < 0 ) {
                    cursorPos = 9;
                }
            } else if ( choice == 's' ) {
                cursorPos = ( cursorPos + 1 ) % 10;
            } else if ( choice == (char) 32 ) {
                if ( options[ cursorPos ] == "NOWA GRA" ) {
                    GameController gc = GameController.GetInstance();
                    gc.SetRoom( new EliotsHouse() );
                    gc.SetPlayer( new Player( 3, 6 ) );
                    this.context.SetState( new PlayState() );
                } else if ( options[ cursorPos ] == "WCZYTAJ GRE" ) {
                    // WCZYTAJ
                } else if ( options[ cursorPos ] == "KONIEC GRY" ) {
                    Console.Clear();
                    Console.WriteLine( Utils.Yellow + "DZIĘKUJE ZA GRE - DO ZOBACZENIA :3\n" + Utils.White );
                    Environment.Exit(0);
                }
            }
        }

    }
}
