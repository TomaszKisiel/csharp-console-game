using System;
using System.Collections.Generic;

namespace Game {
    public class SdCardHolderDialog : ControlledDialog {
        private const string TAKE_CARD = "Wyciągam czarny przedmiot";
        private const string LEAVE = "Odchodzę";

        private static bool containsCard = true;

        private static List<string> options = new List<string>() { TAKE_CARD, LEAVE };
        private int cursorPos = 0;

        public void Draw() {
            Console.Write( Speakers.BOOKSHELF );
            if ( containsCard ) {
                Utils.PrintWrappedText( "Zakurzona półka z kilkoma starymi zdjęciami, zza ramki jednego zdjęcia wystaje mały czarny przedmiot.. co robisz?", 48 );
            } else {
                Utils.PrintWrappedText( "Zakurzona półka z kilkoma starymi zdjęciami.. co robisz?", 48 );
            }

            Utils.DrawMenu( options, cursorPos );
        }

        public void HandleKeyPress( char choice ) {
            if ( choice == ( char ) 32 ) {
                if ( options[ cursorPos ] == LEAVE ) {
                    GameController.GetInstance().SetDialog( null );
                } else if ( options[ cursorPos ] == TAKE_CARD ) {
                    containsCard = false;
                    options.RemoveAt( cursorPos );

                    Item item = ItemsRepository.GetInstance().GetItem( "blank_sd_card" );
                    GameController.GetInstance().GetEquipment().AddItem( item );
                    GameController.GetInstance().SetStatus( new Speech( Speakers.STATUS, "Zdobyto przedmiot " + Utils.Yellow + item.Name + Utils.White ) );
                    Quest.OnSdCardFound();
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