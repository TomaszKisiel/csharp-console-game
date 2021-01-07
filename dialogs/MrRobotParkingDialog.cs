using System;
using System.Collections.Generic;

namespace RGame {
    public class MrRobotParkingDialog : Dialog {
        private const string UNDERSTAND = "Wszystko jasne.";
        private const string MISUNDERSTAND = "Potrzebuje usłyszeć to jeszcze raz.. powoli..";
        private const string NEXT = "[dalej]";
        private const string LEAVE = "Ok.. już idę.";

        private bool planExplained;
        private int state = 0;

        private Menu menu = new Menu();

        public MrRobotParkingDialog( bool planExplained ) {
            this.planExplained = planExplained;

            if ( planExplained == false ) {
                menu.AddOption( NEXT );
            } else {
                menu.AddOption( LEAVE );
            }
        }

        public void Draw() {
            if ( planExplained ) {
                Console.Write( Speakers.MR_ROBOT );
                Console.WriteLine( "Bierz się do roboty.. Twój przewodnik powinien być już w holu.." );
            } else {
                if ( state == 0 ) {
                    Console.Write( Speakers.MR_ROBOT );
                    Console.WriteLine( "Weź słuchawkę, gdy wejdziesz do środka będziemy z Tobą w kontakcie, dopóki nie stracimy zasięgu na poziomie drugim.." );
                } else if ( state == 1 ) {
                    Console.Write( Speakers.MOBLEY );
                    Console.WriteLine( "W czasie akcji nazywasz się Sam Sepiol, jesteś multimiliarderem i chciałeś sprawdzić Steel Mountain przed skorzystaniem z ich usługi.. zapamiętaj. Masz umówione spotkanie na to nazwisko." );
                } else if ( state == 2 ) {
                    Console.Write( Speakers.MOBLEY );
                    Console.WriteLine( "Twój przewodnik to Bill Harper, może oprowadzić Cię po pierwszym poziomie, ale nic więcej. Żeby dostać się na poziom drugi będziesz musiał go zgubić." );
                } else if ( state == 3 ) {
                    Console.Write( Speakers.ROMERO );
                    Console.WriteLine( "Najwygodniejszy termostat do podłączenia raspberry jest w łazience. Według mapy od głównego holu powinieneś iść korytarzem w prawo, przejść do rozwidlenia i skręcić w lewo. Toaleta powinna być przed wejściem do open space." );
                } else if ( state == 4 ) {
                    Console.Write( Speakers.ROMERO );
                    Console.WriteLine( "Według planu nie ma tam żadnej kamery więc powinieneś przejść nie zauważony. Po podłączeniu raspberry będziemy mogli Ci otworzyć drzwi do serwerowni gdzie otworzysz jeden z portów dla naszego trojana. Pamiętaj żeby ubić firewall'a." );
                } else if ( state == 5 ) {
                    Console.Write( Speakers.MR_ROBOT );
                    Console.WriteLine( "Wszystko jasne, czy coś powtórzyć?" );
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
                } else if ( menu.GetCurrent() == NEXT ) {
                    if ( state++ >= 4 ) {
                        menu = new Menu( new List<string>() { UNDERSTAND, MISUNDERSTAND } );
                    }
                } else if ( menu.GetCurrent() == UNDERSTAND ) {
                    ( (MrRobotParking) InteractablesRepository.Instance().Get("mr_robot_parking")).PlanExplained = true;

                    GameController.Instance().SetDialog( null );
                    MainQuest.OnTryGetInStillMountain();
                }  else if ( menu.GetCurrent() == MISUNDERSTAND ) {
                    state = 1;
                    menu = new Menu( new List<string>() { NEXT } );
                }

                return true;
            }

            return false;
        }
    }
}
