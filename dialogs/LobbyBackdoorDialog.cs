using System;
using System.Collections.Generic;

namespace RGame {
    public class LobbyBackdoorDialog : Dialog {
        private const string GET_IN = "Wchodzę";
        private const string OPEN = "Otwieram drzwi wytrychem";
        private const string OPEN_AGAIN = "Próbuje jeszcze raz";
        private const string LEAVE = "Odchodzę";

        private int SuccessOpen = 0;
        private Menu menu = new Menu();

        public LobbyBackdoorDialog() {

            if ( GameController.Instance().GetEquipment().ContainsBySlug("picklock") ) {
                menu.AddOption( OPEN );
            }

            menu.AddOption( LEAVE );
        }

        public void Draw() {
            Console.Write( Speakers.BACKDOOR );
            if ( SuccessOpen > 0 ) {
                Console.WriteLine( "Udało Ci się otworzyć drzwi.. co robisz?" );
            } else if ( SuccessOpen < 0 ) {
                Console.WriteLine( "Wytrych wyskoczył z zamka i nie udało Ci się otworzyć drzwi.. co robisz?" );
            } else {
                Console.WriteLine( "Widzisz zamknięte drzwi w których jest zwykły zamek, a nie magnetyczny.. co robisz?" );
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
                } else if ( menu.GetCurrent() == OPEN || menu.GetCurrent() == OPEN_AGAIN ) {
                    if ( ( new Random() ).Next( 0, 10 ) == 0 ) {
                        menu = new Menu( new List<string>() { GET_IN, LEAVE } );
                        SuccessOpen = 1;
                    } else {
                        menu = new Menu( new List<string>() { OPEN_AGAIN, LEAVE } );
                        SuccessOpen = -1;
                    }
                } else if ( menu.GetCurrent() == GET_IN ) {
                    GameController.Instance().SetDialog( null );
                    MainQuest.OnBackdoorPicklocked();
                }

                return true;
            }

            return false;
        }
    }
}
