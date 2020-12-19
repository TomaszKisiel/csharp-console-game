using System;
using System.Collections.Generic;

namespace RGame {
    public class EliotPCDialog : Dialog {
        private const string INSTALL_ROOTKIT = "Instaluje rootkit'a na raspberry";
        private const string PLAY_CP77 = "Gram w Cyberpunk'a 2077";
        private const string WATCH_YT = "Oglądam youtuba'a";
        private const string LEAVE = "Odchodzę";
        private const string SKIP_ROMERO = "[DALEJ]";

        private bool raspberryInEquipment;
        private bool romeroCall = false;
        private bool funnyCats = false;
        private bool skipRomero = false;
        private bool rootkitInstalled = false;

        private Menu menu = new Menu();

        public EliotPCDialog( bool raspberryInEquipment ) {
            this.raspberryInEquipment = raspberryInEquipment;

            if ( raspberryInEquipment ) {
                menu.AddOption( INSTALL_ROOTKIT );
            }
            menu.AddOption( PLAY_CP77 );
            menu.AddOption( WATCH_YT );
            menu.AddOption( LEAVE );
        }

        public void Draw() {
            if ( rootkitInstalled ) {
                Console.Write( Speakers.ELIOT );
                Console.WriteLine( "Dobra.. raspberry gotowe.. teraz tylko zdążyć na Coney Island. Za chwile będzie autobus." );
            } else if ( funnyCats ) {
                Console.Write( Speakers.ELIOT );
                Console.WriteLine( "Oooo.. jakiś stream u dr Franka.. Among Us.. mmm.. pooglądałby, ale niestety muszę się spieszyć.. może będzie zapis. " );
            } else if ( romeroCall ) {
                if ( skipRomero ) {
                    Console.Write( Speakers.ELIOT );
                    Console.WriteLine( "Już prawie jestem.. eghem.. musiałem jeszcze coś przygotować.." );
                } else {
                    Console.Write( Speakers.ROMERO );
                    Console.WriteLine( "*dwie godziny później* *telefon dzwoni* Szlak by Cię trafił!! Gdzie jesteś.. od godziny czekamy w wanie.. pamiętasz o naszej akcji?!" );
                }
            } else {
                Console.Write( Speakers.ELIOT_PC );
                Console.WriteLine( "Całkiem niezły sprzęt dla hackera, tylko wygląda jakby już kilka razy uderzył w ścianę.. co robisz?" );
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
                } else if ( choice == ( char ) 32 ) {
                    if ( menu.GetCurrent() == LEAVE ) {
                        GameController.Instance().SetDialog( null );
                    } else if ( menu.GetCurrent() == INSTALL_ROOTKIT && raspberryInEquipment ) {
                        menu.RemoveOption( INSTALL_ROOTKIT );

                        bool installed = GameController.Instance().GetEquipment().AddBySlug( "raspberry_pi_rootkit" );
                        if ( installed == true ) {
                            GameController.Instance().GetEquipment().RemoveBySlug( "raspberry_pi_blank" );
                            GameController.Instance().GetEquipment().RemoveBySlug( "sd_card" );
                            raspberryInEquipment = false;
                            rootkitInstalled = true;
                            menu = new Menu( new List<string>() { LEAVE } );
                            MainQuest.OnRootkitInstalled();
                        }
                    } else if ( menu.GetCurrent() == PLAY_CP77 ) {
                        romeroCall = true;
                        menu = new Menu(
                            new List<string>() { SKIP_ROMERO }
                        );
                    } else if ( menu.GetCurrent() == WATCH_YT ) {
                        funnyCats = true;
                        menu = new Menu(
                            new List<string>() { LEAVE }
                        );
                    } else if ( menu.GetCurrent() == SKIP_ROMERO ) {
                        skipRomero = true;
                        menu = new Menu(
                            new List<string>() { LEAVE }
                        );
                    }

                    return true;
                }
            }

            return false;
        }
    }
}