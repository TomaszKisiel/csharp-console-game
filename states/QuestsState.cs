using System;

namespace Game {
    class QuestsState : IGameState {
        private int cursorPos = 0;
        private string[] quests = {
            "Sprzęt hackera",
            "Wiosenne porządki"
        };

        public override void Draw() {
            Headers.Quests();

            for ( int i = 0; i < 10; i++ ) {
                if ( cursorPos == i ) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write( "> ");
                    Console.ForegroundColor = ConsoleColor.White;
                } else {
                    Console.Write( "  ");
                }

                if ( i < quests.Length ) {
                    Console.Write( i + 1 );
                    Console.WriteLine( ".\t" + quests[i] );
                }
            }
        }

        public override void Hints()
        {
            Console.WriteLine();
            Utils.PrintHint( "[ESC]", "Zamknij" );
            Utils.PrintHint( "[SPACE]", "Rozwiń" );
            Utils.PrintHint( "[W]", "Góra" );
            Utils.PrintHint( "[S]", "Dół" );
            Console.WriteLine();
        }

        public override void HandleKeyPress( char choice ) {
            if ( choice == 'w' ) {
                cursorPos = ( cursorPos - 1 ) % quests.Length;
                if ( cursorPos < 0 ) {
                    cursorPos = quests.Length - 1;
                }
            } else if ( choice == 's' ) {
                cursorPos = ( cursorPos + 1 ) % quests.Length;
            } else if ( choice == ( char ) 27 ) {
                this.context.SetState( new PlayState() );
            }
        }

    }
}
