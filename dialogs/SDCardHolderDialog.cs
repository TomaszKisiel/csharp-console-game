using System;
using System.Collections.Generic;

namespace RGame {
    public class SDCardHolderDialog : Dialog {
        private const string TAKE_CARD = "Wyciągam czarny przedmiot";
        private const string LEAVE = "Odchodzę";

        private bool containsSDCard;
        private bool sdCardTaken = false;

        private Menu menu = new Menu();

        public SDCardHolderDialog( bool containsSDCard ) {
            this.containsSDCard = containsSDCard;

            if ( containsSDCard ) {
                menu.AddOption( TAKE_CARD );
            }
            menu.AddOption( LEAVE );
        }

        public void Draw() {
            if ( sdCardTaken ) {
                bool raspberryInEquipment = GameController.Instance().GetEquipment().ContainsBySlug( "raspberry_pi_blank" );

                Console.Write( Speakers.ELIOT );
                if ( raspberryInEquipment ) {
                    Console.WriteLine( "Jest karta i raspberry.. teraz tylko do komputera i wgrać program." );
                } else {
                    Console.WriteLine( "Pusta karta SD.. może się przydać gdyby nie było jej w Pi. " );
                }
            } else {
                Console.Write( Speakers.BOOKSHELF );
                if ( containsSDCard ) {
                    Console.WriteLine( "Zakurzona półka z kilkoma starymi zdjęciami, zza ramki jednego zdjęcia wystaje mały czarny przedmiot.. co robisz?" );
                } else {
                    Console.WriteLine( "Zakurzona półka z kilkoma starymi zdjęciami.. co robisz?" );
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
                } else if ( menu.GetCurrent() == TAKE_CARD && containsSDCard ) {
                    menu.RemoveOption( TAKE_CARD );

                    bool taken = GameController.Instance().GetEquipment().AddBySlug( "sd_card" );
                    if ( taken == true ) {
                        ( (SDCardHolder) InteractablesRepository.Instance().Get("sd_card_holder")).ContainsSDCard = false;
                        containsSDCard = false;
                        sdCardTaken = true;
                        MainQuest.OnSDCardFound();
                    }
                }

                return true;
            }

            return false;
        }
    }
}