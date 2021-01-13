using System;
using System.Collections.Generic;

namespace RGame {
    public class ThermostatFinishDialog : Dialog {
        private const string FINISH = "Dokańczam montowanie Raspberry";
        private const string NEXT = "[zakończ]";
        private const string LEAVE = "Odchodzę";

        private Menu menu = new Menu();

        private bool hacked = false;
        private int state = 0;

        public ThermostatFinishDialog( bool hacked ) {
            this.hacked = hacked;

            if ( hacked == false ) {
                menu.AddOption( FINISH );
            }
            menu.AddOption( LEAVE );
        }

        public void Draw() {
            if ( hacked ) {
                Console.Write(Speakers.THERMOSTAT);
                Console.WriteLine("Widzisz kiepsko przymocowany termostat z ukrytym pod panelem Raspberry Pi.. co robisz?");
            } else {
                if ( state == 0 ) {
                    Console.Write(Speakers.THERMOSTAT);
                    Console.WriteLine("Widzisz kiepsko przymocowany termostat.. co robisz?");
                } else if ( state == 1 ) {
                    Console.Write(Speakers.MR_ROBOT);
                    Console.WriteLine("*szelest w słuchawce* Jesteśmy.. weszliśmy do systemu i przejęliśmy część ich sieci. Żebyśmy mogli ich zniszczyć musimy dostać pełne uprawnienia.. idź do serwerowni i nadaj je przez główny komputer. Spróbujemy złamać zamek w drzwiach i zdobyć jakieś konto w systemie zanim tam dojdziesz.");
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
                } else if ( menu.GetCurrent() == FINISH ) {
                    state = 1;
                    menu = new Menu( new List<string>() { NEXT } );
                } else if ( menu.GetCurrent() == NEXT ) {
                    GameController.Instance().SetDialog( null );
                    ( (Thermostat) InteractablesRepository.Instance().Get("thermostat") ).Hacked = true;
                    MainQuest.OnRaspberryPiMounted();
                }

                return true;
            }

            return false;
        }
    }
}
