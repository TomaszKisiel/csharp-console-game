using System;
using System.Collections.Generic;

namespace Game {
    public class WakeUp : ControlledDialog {
        private const string WAKE_UP = "Wychodzę z łóżka";
        private const string SLEEP = "Śpię dalej";

        private static int sleep = -1;
        private static int hours = 12;
        private static int minutes = 24;

        private static List<string> options = null;
        private int cursorPos = 0;

        public WakeUp() {
            sleep++;

            if ( sleep % 10 == 0 ) {
                options = new List<string>() { WAKE_UP, SLEEP };
                minutes++;
                if ( minutes >= 60 ) {
                    hours++;
                    minutes = 0;
                }
            } else {
                options = new List<string>() { SLEEP };
            }
        }

        public void Draw() {
            Console.Write( Speakers.ELIOT );
            if ( sleep % 10 == 0 ) {
                Utils.PrintWrappedText( "Eghh.. ała.. mmm... moja głowa.. godzina? " + hours + ":" + minutes + "! Poduszka znowu na podłodze.. egh.. ała..", 48 );
            } else {
                string snore = "";
                for ( int i = 0; i < sleep % 10; i++ ) {
                    snore += "zzz... ";
                }
                Utils.PrintWrappedText( snore, 48 );
            }

            Utils.DrawMenu( options, cursorPos );
        }

        public void HandleKeyPress( char choice ) {
            if ( choice == ( char ) 32 ) {
                if ( options[ cursorPos ] == WAKE_UP ) {
                    GameController.GetInstance().SetDialog( new Speech( Speakers.ELIOT, "Muszę zabrać sprzęt i zdążyć na Coney Island zanim zaczną akcje beze mnie.." ) );
                    GameController.GetInstance().SetQuest( new Speech( Speakers.QUEST, "Znajdź Raspberry Pi w pokoju Eliota." ) );
                } else if ( options[ cursorPos ] == SLEEP ) {
                    GameController.GetInstance().SetDialog( new WakeUp() );
                }
            } else if ( choice == 'w' ) {
                cursorPos = ( cursorPos - 1 ) % options.Count;
                if ( cursorPos < 0 ) {
                    cursorPos = options.Count - 1;
                }
            } else if ( choice == 's' ) {
                cursorPos = ( cursorPos + 1 ) % options.Count;
            }
        }
    }
}