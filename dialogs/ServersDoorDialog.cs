using System;
using System.Collections.Generic;

namespace RGame {
    public class ServersDoorDialog : Dialog {
        private const string CORRECT = "7962";
        private const string TRY_CARD = "Przykładam kartę Tyrella";
        private const string COME_IN = "Wchodzę do środka";
        private const string OPEN = "Naciskam \"kluczyk\" na klawiaturze";
        private const string LEAVE = "Odchodzę";
        private const string NEXT = "[dalej]";
        private const string FAILED = "[Niestety.. przegrałeś!]";

        private Menu menu = new Menu();

        private int state = 0;

        public ServersDoorDialog() {
            menu.AddOption( OPEN );
            menu.AddOption( LEAVE );
        }

        public void Draw() {
            Console.Write(Speakers.DOOR);
            if ( state == 0 ) {
                Console.WriteLine( "Na drzwiach jest nalepka \"SERWEROWNIA\". Drzwi są zabezpieczone przez kontroler elektroniczny, z klawiaturą.. co robisz?" );
            } else if ( state == 1 ) {
                int throttle = ( (ServersDoor) InteractablesRepository.Instance().Get( "servers_door" ) ).Throttle;
                Console.WriteLine( "Na wyświetlaczu zaczynają migać różne kody, być może któryś z nich otwiera drzwi. Jest też informacja: \"ZOSTAŁO: " + throttle.ToString() + " PRÓB\".. co robisz?" );
            } else if ( state == 2 ) {
                int throttle = ( (ServersDoor) InteractablesRepository.Instance().Get( "servers_door" ) ).Throttle;
                Console.WriteLine( "Na kontrolerze zaświeciła się czerwona dioda, a wyświetlacz pokazał: \"ZOSTAŁO: " + throttle.ToString() + " PRÓB\".. co robisz?" );
            } else if ( state == 3 ) {
                Console.WriteLine( "Na kontrolerze zaświeciła się zielona dioda, a drzwi otworzyły się.. co robisz?" );
            } else if ( state == 10 ) {
                Console.WriteLine( "Gdy przekroczyłeś trzecią próbę w całym budynku rozległ się głośny alarm. Natychmiast przybiegła ochrona i brutalnie przygwoździła Cię do ziemi." );
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
                } else if ( menu.GetCurrent() == OPEN ) {
                    state = 1;
                    CodesMenu();
                } else if ( menu.GetCurrent() == CORRECT || menu.GetCurrent() == TRY_CARD) {
                    state = 3;
                    menu = new Menu( new List<string>() { COME_IN, LEAVE } );

                    ServersDoor door = (ServersDoor) InteractablesRepository.Instance().Get( "servers_door" );
                    door.Open = true;
                } else if ( menu.GetCurrent() == COME_IN ) {
                    GameController.Instance().SetPlayer( new Point( 27, 14 ) );
                    GameController.Instance().SetRoom( RoomsRepository.Instance().Get( "servers" ) );
                    GameController.Instance().SetDialog( null );
                } else if ( menu.GetCurrent() == FAILED ) {
                    GameController.Instance().GameOver();
                } else {
                    ServersDoor door = (ServersDoor) InteractablesRepository.Instance().Get( "servers_door" );
                    door.Throttle -= 1;

                    if (door.Throttle > 0 ) {
                        state = 2;
                        CodesMenu();
                    } else {
                        menu = new Menu( new List<string>() { FAILED } );
                        state = 10;
                    }
                }

                return true;
            }

            return false;
        }

        private void CodesMenu() {
            List<string> password = new List<string>();
            if ( GameController.Instance().GetEquipment().ContainsBySlug( "magnetic_card" ) ) {
                password.Add( TRY_CARD );
            }

            Random r = new Random();
            int incorrectBefore = r.Next( 1, 10 );
            for ( int i = 0; i < incorrectBefore; i++ ) {
                int sequence = r.Next( 1000, 10000 );
                while( sequence.ToString() == CORRECT ) {
                    sequence = r.Next( 1000, 10000 );
                }
                password.Add( sequence.ToString() );
            }
            password.Add( CORRECT );
            for ( int i = incorrectBefore + 1; i < 10; i++ ) {
                int sequence = r.Next( 1000, 10000 );
                while( sequence.ToString() == CORRECT ) {
                    sequence = r.Next( 1000, 10000 );
                }
                password.Add( sequence.ToString() );
            }
            password.Add( LEAVE );

            menu = new Menu( password );
        }
    }
}
