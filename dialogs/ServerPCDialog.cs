using System;
using System.Collections.Generic;

namespace RGame {
    public class ServerPCDialog : Dialog {
        private const string GRANT = "Nadaję odpowiednie uprawnienia użytkownikowi \"fsociety\"";
        private const string NEXT = "[Gratulacje.. wygrałeś grę!]";
        private const string LEAVE = "Odchodzę";

        private Menu menu = new Menu();

        private bool hacked = false;
        private bool win = false;

        public ServerPCDialog( bool hacked ) {
            this.hacked = hacked;

            if ( hacked == false ) {
                menu.AddOption( GRANT );
            }
            menu.AddOption( LEAVE );
        }

        public void Draw() {

            if ( win ) {
                 Console.Write( Speakers.MR_ROBOT );
                 Console.WriteLine( "Mamy to! Skrypt kasujący dane ruszył.. zablokowaliśmy im całą sieć. Udało się, a teraz zwiewaj stamtąd i spadamy." );
            } else if ( hacked ) {
                Console.Write( Speakers.STEEL_MOUNTAIN_PC );
                Console.WriteLine( "Na komputerze uruchomiło się już odpowiednie oprogramowanie kasujące dane z serwerów.. co robisz?" );
            } else {
                Console.Write( Speakers.STEEL_MOUNTAIN_PC );
                Console.WriteLine( "Widzisz komputer z zalogowanym kontem \"root\" i wyłączonym firewallem .. co robisz?" );
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
                } else if ( menu.GetCurrent() == GRANT ) {
                    ( ( ServerPC ) InteractablesRepository.Instance().Get("server_pc") ).Hacked = true;
                    win = true;
                    menu = new Menu( new List<string>() { NEXT } );
                } else if ( menu.GetCurrent() == NEXT ) {
                    GameController.Instance().GameOver();
                }

                return true;
            }

            return false;
        }
    }
}
