using System;
using System.Collections.Generic;

namespace RGame {
    public class MrRobotBillFailedDialog : Dialog {
        private const string PICKLOCK = "Mam wytrychy.. może uda mi się wejść..";
        private const string NO_PICKLOCK = "Bez wytrychów nic nie zdziałam..";
        private const string FAILED = "Nie udało się z Billem.. jakaś inna szansa?";
        private const string NEXT = "[dalej]";
        private const string LEAVE = "Odchodzę";
        private const string NOTHING = "Nic";

        private int state = 0;
        private bool planExplained;

        private Menu menu = new Menu();

        public MrRobotBillFailedDialog( bool planExplained ) {
            this.planExplained = planExplained;

            if ( planExplained == false ) {
                menu.AddOption( FAILED );
                menu.AddOption( NOTHING );
            } else {
                menu.AddOption( LEAVE );
            }
        }

        public void Draw() {
            if ( planExplained ) {
                Console.Write( Speakers.MR_ROBOT );
                Console.WriteLine( "Bierz się do roboty.. i tym razem postaraj się niczego nie spieprzyć.." );
            } else {
                if ( state == 0 ) {
                    Console.Write( Speakers.MR_ROBOT );
                    Console.WriteLine( "Co jest?" );
                } else if ( state == 1 ) {
                    Console.Write( Speakers.ROMERO );
                    Console.WriteLine( "Szlak! Co mogłeś spieprzyć w tak prostym zadaniu jak spławienie jakiegoś frajera?!" );
                } else if ( state == 2 ) {
                    Console.Write( Speakers.MOBLEY );
                    Console.WriteLine( "Według planów w lobby są stare drzwi bez zamka magnetycznego.. może uda Ci się przez nie włamać?" );
                } else if ( state == 3 ) {
                    Console.Write( Speakers.MR_ROBOT );
                    Console.WriteLine( "To nie stój jak widły w gnoju tylko bierz się do roboty!" );
                } else if ( state == 10 ) {
                    Console.Write( Speakers.MR_ROBOT );
                    Console.WriteLine( "No to koniec.. cała akcja sie posypała." );
                }
            }
            Console.WriteLine();

            menu.Draw();
        }

        public bool HandleKeyPress( char choice ) {
            if ( menu.HandleKeyPress( choice) ) {
                return true;
            } else if ( choice == ( char ) 32 ) {
                if ( menu.GetCurrent() == LEAVE || menu.GetCurrent() == NOTHING ) {
                    GameController.Instance().SetDialog( null );
                } else if ( menu.GetCurrent() == FAILED ) {
                    menu = new Menu( new List<string>() { NEXT } );
                    state++;
                } else if ( menu.GetCurrent() == NEXT ) {
                    if ( state == 1 ) {
                        if ( GameController.Instance().GetEquipment().ContainsBySlug( "picklock" ) ) {
                            menu = new Menu( new List<string>() { PICKLOCK } );
                        } else {
                            menu = new Menu( new List<string>() { NO_PICKLOCK } );
                        }
                    } else if ( state == 10 ) {
                        // game over
                        GameController.Instance().SetDialog( null );
                    }
                    state++;
                } else if ( menu.GetCurrent() == PICKLOCK ) {
                    ( ( MrRobotParking ) InteractablesRepository.Instance().Get("mr_robot_parking") ).NewPlanExplained = true;

                    menu = new Menu( new List<string>() { LEAVE } );
                    state++;
                }  else if ( menu.GetCurrent() == NO_PICKLOCK ) {
                    menu = new Menu( new List<string>() { NEXT } );
                    state = 10;
                }

                return true;
            }

            return false;
        }
    }
}
