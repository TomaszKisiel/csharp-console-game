using System;
using System.Collections.Generic;

namespace RGame {
    class EquipmentState : GameState {

        private int cursorPos = 0;

        public override void Draw() {
            Headers.Equipment();

            List<Item> items = GameController.Instance().GetEquipment().GetItems();
            for ( int i = 0; i < Equipment.SIZE; i++ ) {
                if ( cursorPos == i ) {
                    Console.Write( Display.RED + "> " + Display.WHITE );
                } else {
                    Console.Write( "  " );
                }

                if ( i < items.Count ) {
                    Console.Write( i + 1 );
                    Console.WriteLine( ".\t" + items[i].Name );
                } else {
                    Console.Write( i + 1 );
                    Console.WriteLine( ".\t[ pusty slot ]" );
                }
            }
            Console.WriteLine();

            Item item = null;
            if ( cursorPos >= 0 && cursorPos < items.Count ) {
                item = items[ cursorPos ];
            }

            if ( item != null ) {
                Display.WrappedText( Display.BLUE + "Opis: " + Display.WHITE + item.Description, 64 );
                Console.WriteLine( Display.BLUE + "Wartość: " + Display.YELLOW + "$" + item.Price + Display.WHITE );
                Console.WriteLine();
            }
        }

        public override void DrawHints()
        {
            Hints.Draw( "W", "Góra" );
            Hints.Draw( "S", "Dół" );
            Hints.Draw( "ESC", "Zamknij" );
            Console.WriteLine();
        }

        public override bool HandleKeyPress( char choice ) {
            if ( choice == 'w' ) {
                cursorPos = ( cursorPos - 1 ) % Equipment.SIZE;
                if ( cursorPos < 0 ) {
                    cursorPos = Equipment.SIZE - 1;
                }
                return true;
            } else if ( choice == 's' ) {
                cursorPos = ( cursorPos + 1 ) % Equipment.SIZE;
                return true;
            } else if ( choice == ( char ) 27 ) {
                this.context.SetState( new PlayState() );
                return true;
            }

            return false;
        }

    }
}
