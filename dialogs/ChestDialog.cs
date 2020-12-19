using System;
using System.Collections.Generic;

namespace RGame {
    public class ChestDialog : Dialog {
        private const string TAKE_PI = "Zabieram Raspberry Pi";
        private const string TAKE_DUCK = "Zabieram kaczuszkę";
        private const string LEAVE = "Odchodzę";

        private bool containsRaspberry = true;
        private bool containsDuck = true;
        private bool raspberryTaken = false;

        private Menu menu = new Menu();

        public ChestDialog( bool containsRaspberry, bool containsDuck ) {
            this.containsRaspberry = containsRaspberry;
            this.containsDuck = containsDuck;

            if ( containsRaspberry ) {
                menu.AddOption( TAKE_PI );
            }
            if ( containsDuck ) {
                menu.AddOption( TAKE_DUCK );
            }
            menu.AddOption( LEAVE );

        }

        public void Draw() {
            if ( raspberryTaken ) {
                bool sdCardInEquipment = GameController.Instance().GetEquipment().ContainsBySlug( "sd_card" );

                Console.Write( Speakers.ELIOT );
                if ( sdCardInEquipment ) {
                    Console.WriteLine( "Jest karta i raspberry.. teraz tylko do komputera i wgrać program." );
                } else {
                    Console.WriteLine( "Jest raspberry, ale bez systemu na niewiele się przyda. Muszę znaleźć jakąś kartę pamięci i wgrać program." );
                }
            } else {
                Console.Write( Speakers.CHEST );
                if ( containsRaspberry && containsDuck ) {
                    Console.WriteLine( "Wewnątrz skrzynki pomiędzy stertą elektronicznych rupieci znajduje się Raspberry Pi oraz gumowa kaczuszka.. co robisz?" );
                } else if ( containsRaspberry ) {
                    Console.WriteLine( "Wewnątrz skrzynki pomiędzy stertą elektronicznych rupieci znajduje się Raspberry Pi.. co robisz?" );
                } else if ( containsDuck ) {
                    Console.WriteLine( "Wewnątrz skrzynki pomiędzy stertą elektronicznych rupieci znajduje się gumowa kaczuszka.. co robisz?" );
                } else {
                    Console.WriteLine( "Wewnątrz skrzynki pomiędzy stertą elektronicznych rupieci nie znajdujesz nic ciekawego.. co robisz?" );
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
                } else if ( menu.GetCurrent() == TAKE_PI && containsRaspberry ) {
                    menu.RemoveOption( TAKE_PI );

                    bool taken = GameController.Instance().GetEquipment().Add( ItemsRepository.Instance().Get( "raspberry_pi_blank" ) );
                    if ( taken == true ) {
                        ( (Chest) InteractablesRepository.Instance().Get("chest")).ContainsRaspberry = false;
                        containsRaspberry = false;
                        raspberryTaken = true;

                        menu = new Menu( new List<string>() { LEAVE } );

                        MainQuest.OnRaspberryFound();
                    }
                } else if ( menu.GetCurrent() == TAKE_DUCK && containsDuck ) {
                    containsDuck = false;
                    menu.RemoveOption( TAKE_DUCK );

                    bool taken = GameController.Instance().GetEquipment().Add( ItemsRepository.Instance().Get( "rubber_duck" ) );
                    if ( taken == true ) {
                        ( (Chest) InteractablesRepository.Instance().Get("chest")).ContainsDuck = false;
                    }
                }

                return true;
            }

            return false;
        }
    }
}