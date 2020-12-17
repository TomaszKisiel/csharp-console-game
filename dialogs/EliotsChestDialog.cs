using System;
using System.Collections.Generic;

namespace Game {
    public class EliotsChestDialog : ControlledDialog {
        private const string TAKE_PI = "Zabieram Raspberry Pi";
        private const string TAKE_DUCK = "Zabieram kaczuszkę";
        private const string LEAVE = "Odchodzę";

        private static bool containsRaspberryPi = true;
        private static bool containsDuck = true;

        private static List<string> options = new List<string>() { TAKE_PI, TAKE_DUCK, LEAVE };
        private int cursorPos = 0;

        public void Draw() {
            Console.Write( Speakers.CHEST );
            if ( containsRaspberryPi && containsDuck ) {
                Utils.PrintWrappedText( "Wewnątrz skrzynki pomiędzy stertą elektronicznych rupieci znajduje się Raspberry Pi oraz gumowa kaczuszka.. co robisz?", 48 );
            } else if ( containsRaspberryPi ) {
                Utils.PrintWrappedText( "Wewnątrz skrzynki pomiędzy stertą elektronicznych rupieci znajduje się Raspberry Pi.. co robisz?", 48 );
            } else if ( containsDuck ) {
                Utils.PrintWrappedText( "Wewnątrz skrzynki pomiędzy stertą elektronicznych rupieci znajduje się gumowa kaczuszka.. co robisz?", 48 );
            } else {
                Utils.PrintWrappedText( "Wewnątrz skrzynki pomiędzy stertą elektronicznych rupieci nie znajdujesz nic ciekawego.", 48 );
            }

            Utils.DrawMenu( options, cursorPos );
        }

        public void HandleKeyPress( char choice ) {
            if ( choice == ( char ) 32 ) {
                if ( options[ cursorPos ] == LEAVE ) {
                    GameController.GetInstance().SetDialog( null );
                } else if ( options[ cursorPos ] == TAKE_PI ) {
                    containsRaspberryPi = false;
                    options.RemoveAt( cursorPos );
                    GameController.GetInstance().GetEquipment().AddItem( ItemsRepository.GetInstance().GetItem( "raspberry_pi_without_sd_card" ) );
                    GameController.GetInstance().SetStatus( new Speech( Speakers.STATUS, "Zdobyto przedmiot " + Utils.Yellow + "Raspberry Pi" + Utils.White ) );
                    Quest.OnRaspberryPiFound();
                } else if ( options[ cursorPos ] == TAKE_DUCK ) {
                    containsDuck = false;
                    options.RemoveAt( cursorPos );
                    GameController.GetInstance().GetEquipment().AddItem( ItemsRepository.GetInstance().GetItem( "rubber_duck" ) );
                    GameController.GetInstance().SetStatus( new Speech( Speakers.STATUS, "Zdobyto przedmiot " + Utils.Yellow + "Kaczuszka" + Utils.White ) );
                    GameController.GetInstance().SetDialog( new Speech( Speakers.ELIOT, "Kaczuszka.. szukałem Cię ostatnio.. warto Cię zabrać i na tą akcje." ));
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