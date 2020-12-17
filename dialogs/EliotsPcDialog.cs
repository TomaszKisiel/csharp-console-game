using System;
using System.Collections.Generic;

namespace Game {
    public class EliotsPcDialog : ControlledDialog {
        private const string INSTALL_ROOTKIT = "Instaluje rootkit'a na raspberry";
        private const string PLAY_CP77 = "Gram w Cyberpunk'a 2077";
        private const string WATCH_YT = "Oglądam youtuba'a";
        private const string LEAVE = "Odchodzę";

        private static List<string> options = new List<string>() { PLAY_CP77, WATCH_YT, LEAVE };
        private int cursorPos = 0;

        public EliotsPcDialog() {
            if (
                GameController.GetInstance().GetEquipment().ContainsItem(
                    ItemsRepository.GetInstance().GetItem( "raspberry_pi_without_sd_card" )
                ) &&
                GameController.GetInstance().GetEquipment().ContainsItem(
                    ItemsRepository.GetInstance().GetItem( "blank_sd_card" )
                ) &&
                !options.Contains( INSTALL_ROOTKIT )
            ) {
                options.Insert( 0, INSTALL_ROOTKIT );
            }
        }

        public void Draw() {
            Console.Write( Speakers.ELIOTS_PC );
            Utils.PrintWrappedText( "Całkiem niezły sprzęt dla hackera, tylko wygląda jakby już kilka razy uderzył w ścianę.. co robisz?", 48 );
            Utils.DrawMenu( options, cursorPos );
        }

        public void HandleKeyPress( char choice ) {
            if ( choice == ( char ) 32 ) {
                if ( options[ cursorPos ] == LEAVE ) {
                    GameController.GetInstance().SetDialog( null );
                } else if ( options[ cursorPos ] == INSTALL_ROOTKIT ) {
                    options.RemoveAt( cursorPos );

                    Item card = ItemsRepository.GetInstance().GetItem( "blank_sd_card" );
                    Item raspberry = ItemsRepository.GetInstance().GetItem( "raspberry_pi_without_sd_card" );
                    GameController.GetInstance().GetEquipment().RemoveItem( card );
                    GameController.GetInstance().GetEquipment().RemoveItem( raspberry );

                    Item infectedPi = ItemsRepository.GetInstance().GetItem( "raspberry_pi_with_rootkit" );
                    GameController.GetInstance().GetEquipment().AddItem( infectedPi );

                    GameController.GetInstance().SetStatus( new Speech( Speakers.STATUS, "Zdobyto przedmiot " + Utils.Yellow + infectedPi.Name + Utils.White ) );
                    Quest.OnRootkitInstalledFound();
                } else if ( options[ cursorPos ] == PLAY_CP77 ) {
                    GameController.GetInstance().SetDialog( new Speech( Speakers.ROMERO, "*dwie godziny późnie* *telefon dzwoni* Puta Twoja mać.. gdzie jesteś.. od godziny czekamy w wanie.. pamiętasz o naszej akcji?! ") );
                } else if ( options[ cursorPos ] == WATCH_YT ) {
                    GameController.GetInstance().SetDialog( new Speech( Speakers.ELIOT, "*ogląda śmieszne kotki* Hua hua hua.. dobra.. trzeba się zbierać..") );
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