using System;
using System.Collections.Generic;

namespace RGame {
    public class ThermostatDialog : Dialog {
        private const string PUT_PI = "Montuje Raspberry Pi";
        private const string PULL_OUT_PANEL = "Wyciągam panel";
        private const string TEAR_OUT_PANEL = "Wyrywam panel";
        private const string PUT_PANEL_BACK = "Wkładam panel z powrotem";
        private const string HIDE_PANEL = "Zasłaniam panel plecami";
        private const string LEAVE = "Odchodzę";

        private Menu menu = new Menu();

        private int state = 0;

        public ThermostatDialog() {
            menu.AddOption( PULL_OUT_PANEL );
            menu.AddOption( TEAR_OUT_PANEL );
            menu.AddOption( LEAVE );
        }

        public void Draw() {
            Console.Write( Speakers.THERMOSTAT );
            if ( state == 0 ) {
                Console.WriteLine("Widzisz termostat z kiepsko przymocowanym panelem wyświetlacza.. co robisz?");
            } else if ( state == 1 ) {
                Console.WriteLine("Ze ściany wystają wiązki kabli, na których zwisa bezwładnie panel.. co robisz?");
            } else if ( state == 2 ) {
                Console.WriteLine("Splatasz w palcach kolejne kable z odpowiednimi pinami Raspberry.. *dźwięk otwieranych drzwi* ktoś wchodzi do łazienki.. co robisz?");
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
                } else if ( menu.GetCurrent() == PULL_OUT_PANEL || menu.GetCurrent() == TEAR_OUT_PANEL ) {
                    state = 1;
                    menu = new Menu( new List<string>() { PUT_PI, LEAVE } );
                } else if ( menu.GetCurrent() == PUT_PI ) {
                    state = 2;
                    menu = new Menu( new List<string>() { HIDE_PANEL, PUT_PANEL_BACK } );
                    GameController.Instance().GetEquipment().RemoveBySlug("raspberry_pi_rootkit");
                    ( (Thermostat) InteractablesRepository.Instance().Get("thermostat") ).Started = true;
                } else if ( menu.GetCurrent() == PUT_PANEL_BACK ) {
                    GameController.Instance().SetDialog( new TyrellDialog( true ) );
                } else if ( menu.GetCurrent() == HIDE_PANEL ) {
                    GameController.Instance().SetDialog( new TyrellDialog( false ) );
                }

                return true;
            }

            return false;
        }
    }
}
