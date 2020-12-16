using System;

namespace Game {
    class EquipmentState : IGameState {
        private string msg = "";
        private int cursorPos = 0;
        private Item[] items;

        public EquipmentState() {
            ItemsRepository itemRepo = ItemsRepository.GetInstance();

            items = new Item[] {
                itemRepo.GetItem( "raspberry_pi_without_sd_card" ),
                itemRepo.GetItem( "blank_sd_card" ),
                itemRepo.GetItem( "raspberry_pi_with_rootkit" ),
                itemRepo.GetItem( "picklock" ),
                itemRepo.GetItem( "fsociety" ),
            };
        }

        public override void Draw() {
            Headers.Equipment();

            for ( int i = 0; i < 10; i++ ) {
                if ( cursorPos == i ) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write( "> ");
                    Console.ForegroundColor = ConsoleColor.White;
                } else {
                    Console.Write( "  ");
                }

                if ( i < items.Length ) {
                    Console.Write( i + 1 );
                    Console.WriteLine( ".\t" + items[i].Name );
                } else {
                    Console.Write( i + 1 );
                    Console.WriteLine( ".\t[ pusty slot ]" );
                }

                if ( i == cursorPos && i < items.Length ) {
                    Console.WriteLine();
                    Utils.PrintWrappedText( Utils.Blue + "Opis: " + Utils.White + items[i].Description, 52, "\t" );
                    Console.WriteLine( Utils.Blue + "\tWartość: " + Utils.Yellow + "$" + items[i].Price + Utils.White );
                    Console.WriteLine();
                }
            }

            if ( msg != "" ) {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write( "Status: " );
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine( msg );
                msg = "";
            }

        }

        public override void Hints()
        {
            Console.WriteLine();
            Utils.PrintHint( "[ESC]", "Zamknij" );
            Utils.PrintHint( "[W]", "Góra" );
            Utils.PrintHint( "[S]", "Dół" );
//            ColorHints.Print( "[SPACE]", "Użyj" );
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
            } else if ( choice == ( char ) 27 ) {
                this.context.SetState( new PlayState() );
            }

            /* else if ( choice == ( char ) 32 ) {
                if ( cursorPos < items.Length ) {
                    msg = "Użyto " + items[ cursorPos ].Name;
                } else {
                    msg = "Brak przedmiotu w slocie #" + ( cursorPos + 1 ).ToString();
                }
                return true;
            } */
        }

    }
}
