using System;
using System.Collections.Generic;

namespace RGame {
    public class BusStopDialog : Dialog {
        private const string CONEY_ISLAND = "Wsiadam do autobusu";
        private const string LEAVE = "Odchodzę";

        private Menu menu = new Menu();

        public BusStopDialog() {
            if ( GameController.Instance().GetEquipment().ContainsBySlug("raspberry_pi_rootkit") ) {
                menu.AddOption( CONEY_ISLAND );
            }
            menu.AddOption( LEAVE );
        }

        public void Draw() {
            Console.Write( Speakers.BUS_STOP );
            if ( GameController.Instance().GetEquipment().ContainsBySlug("raspberry_pi_rootkit") ) {
                Console.WriteLine("Podchodząc do znaku zauważasz, że autobus na Coney Island właśnie podjeżdża.. co robisz?");
            } else {
                Console.WriteLine("Między niezliczonymi plakatami znajduję się zawiła informacja z rozkładem jazdy.. Coney Island za 20min.. co robisz?");
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
                } else if ( menu.GetCurrent() == CONEY_ISLAND ) {
                    GameController.Instance().SetDialog( null );
                    MainQuest.OnConeyIslandTransition();
                }

                return true;
            }

            return false;
        }
    }
}