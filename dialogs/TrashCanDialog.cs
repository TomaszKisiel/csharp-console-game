using System;
using System.Collections.Generic;

namespace Game {
    public class TrashCanDialog : ControlledDialog {
        private const string TAKE_PICKLOCK = "Zabieram wytrych";
        private const string LEAVE = "Odchodzę";

        private static bool containsPicklock = true;

        private static List<string> options = new List<string>() { TAKE_PICKLOCK, LEAVE };
        private int cursorPos = 0;

        public void Draw() {
            Console.Write( Speakers.TRASH_CAN );
            if ( containsPicklock ) {
                Utils.PrintWrappedText( "Zielonkawy śmietnik uliczny, prawie pusty. Ale co to? W popielniczce leży zestaw wytrychów.. co robisz?", 48 );
            } else {
                Utils.PrintWrappedText( "Zielonkawy śmietnik uliczny, prawie pusty... co robisz?", 48 );
            }
            Utils.DrawMenu( options, cursorPos );
        }

        public void HandleKeyPress( char choice ) {
            if ( choice == ( char ) 32 ) {
                if ( options[ cursorPos ] == LEAVE ) {
                    GameController.GetInstance().SetDialog( null );
                } else if ( options[ cursorPos ] == TAKE_PICKLOCK ) {
                    containsPicklock = false;
                    options.RemoveAt( cursorPos );

                    Item item = ItemsRepository.GetInstance().GetItem( "picklock" );
                    GameController.GetInstance().GetEquipment().AddItem( item );
                    GameController.GetInstance().SetStatus( new Speech( Speakers.STATUS, "Zdobyto przedmiot " + Utils.Yellow + item.Name + Utils.White ) );
                    GameController.GetInstance().SetDialog( new Speech( Speakers.ELIOT, "Ktoś zostawił wytrych w popielniczce? Trochę podejrzane.. mimo wszystko, mogą się jeszcze dziś przydać." ) );
                }
            } else if ( choice == 'w' ) {
                cursorPos = ( cursorPos - 1 ) % options.Count;
                if ( cursorPos < 0 ) {
                    cursorPos = options.Count - 1;
                }
            } else if ( choice == 's' ) {
                cursorPos = ( cursorPos + 1 ) % options.Count;
            }
        }
    }
}