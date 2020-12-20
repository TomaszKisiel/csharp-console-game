using System;
using System.Collections.Generic;

namespace RGame {
    public class TrashCanDialog : Dialog {
        private const string TAKE_PICKLOCK = "Zabieram wytrych";
        private const string LEAVE = "Odchodzę";

        private bool containsPicklock;
        private bool picklockTaken = false;

        private Menu menu = new Menu();

        public TrashCanDialog( bool containsPicklock ) {
            this.containsPicklock = containsPicklock;

            if ( containsPicklock ) {
                menu.AddOption( TAKE_PICKLOCK );
            }
            menu.AddOption( LEAVE );
        }

        public void Draw() {
             if ( picklockTaken ) {
                Console.Write( Speakers.ELIOT );
                Console.WriteLine( "Ktoś zostawił wytrych w popielniczce? Trochę podejrzane.. mimo wszystko, mogą się jeszcze dziś przydać." );
            } else {
                Console.Write( Speakers.TRASH_CAN );
                if ( containsPicklock ) {
                    Console.WriteLine( "Zielonkawy śmietnik uliczny, prawie pusty. Ale co to? W popielniczce leży zestaw wytrychów.. co robisz?" );
                } else {
                    Console.WriteLine( "Zielonkawy śmietnik uliczny, prawie pusty... co robisz?" );
                }
            }
            Console.WriteLine();

            menu.Draw();
        }

        public bool HandleKeyPress( char choice ) {
            if ( menu.HandleKeyPress( choice) ) {
                return true;
            } else if ( choice == ( char ) 32 ) {
                if ( menu.GetCurrent() == LEAVE ) {
                    GameController.Instance().SetDialog( null );
                } else if ( menu.GetCurrent() == TAKE_PICKLOCK && containsPicklock ) {
                    menu.RemoveOption( TAKE_PICKLOCK );

                    bool taken = GameController.Instance().GetEquipment().AddBySlug( "picklock" );
                    if ( taken == true ) {
                        ( (TrashCan) InteractablesRepository.Instance().Get("trash_can")).ContainsPicklock = false;
                        containsPicklock = false;
                        picklockTaken = true;
                    }
                }

                return true;
            }

            return false;
        }
    }
}