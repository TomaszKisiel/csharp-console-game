using System;
using System.Collections.Generic;

namespace RGame {
    public class TeamOnConeyIslandDialog : Dialog {
        private const string READY = "Tak";
        private const string LEAVE = "Jeszcze nie";
        private const string NEXT = "[dalej]";

        private Menu menu = new Menu();
        private int state = 0;

        public TeamOnConeyIslandDialog() {
            menu.AddOption( READY );
            menu.AddOption( LEAVE );
        }

        public void Draw() {

            if ( state == 0 ) {
                Console.Write( Speakers.ROMERO );
                Console.WriteLine( "No proszę.. król hackerów we własnej osobie postanowił się zjawić.. jesteś spóźniony od 30 minut.. znowu! Gotowy?" );
            } else if ( state == 1 ) {
                Console.Write( Speakers.ELIOT );
                Console.WriteLine( "Emm.." );
            } else if ( state == 2 ) {
                Console.Write( Speakers.DARLENE );
                Console.WriteLine( "Daj spokój, wiesz, żę musiał się przygotować.." );
            } else if ( state == 3 ) {
                Console.Write( Speakers.ROMERO );
                Console.WriteLine( "Tak samo jak każdy!" );
            } else if ( state == 4 ) {
                Console.Write( Speakers.MR_ROBOT );
                Console.WriteLine( "Odpuść! Wiesz, że nie mamy czasu na kłótnie. Ja, Ty, Mobley i Eliot jedziemy pod Steel Mountain, Darlene i Trenton operują zdalnie z bazy.." );
            } else if ( state == 5 ) {
                Console.Write( Speakers.DARLENE );
                Console.WriteLine( "Suuuper..." );
            } else if ( state == 6 ) {
                Console.Write( Speakers.MR_ROBOT );
                Console.WriteLine( "???" );
            } else if ( state == 7 ) {
                Console.Write( Speakers.DARLENE );
                Console.WriteLine( "Po prostu się pieprz wiesz.. *ciągnie Trenton za rękę i odchodzi* chodź!" );
            } else if ( state == 8 ) {
                Console.Write( Speakers.MR_ROBOT );
                Console.WriteLine( "Ehhh.. wsiadać do auta.. po drodze omówimy szczegóły.." );
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
                } else if ( menu.GetCurrent() == NEXT ) {
                    if ( state >= 8 ) {
                         MainQuest.OnActionBegin();
                         GameController.Instance().SetDialog( null );
                    } else {
                        state++;
                    }
                } else if ( menu.GetCurrent() == READY ) {
                    menu = new Menu( new List<string>() { NEXT } );
                    state++;
                }

                return true;
            }

            return false;
        }
    }
}
