using System;
using System.Collections.Generic;

namespace RGame {
    public class WakeUpDialog : Dialog {
        private const string WAKE_UP = "Wychodzę z łóżka";
        private const string SLEEP = "Śpię dalej";

        private int sleep = -1;
        private static int hours = 12;
        private static int minutes = 24;

        private bool wakedUp = false;

        private Menu menu = new Menu();

        public WakeUpDialog( int sleep ) {
            this.sleep = sleep;

            if ( sleep % 10 == 0 ) {
                menu.AddOption( WAKE_UP );
                minutes++;
                if ( minutes >= 60 ) {
                    hours++;
                    minutes = 0;
                    if ( hours >= 24 ) {
                        hours = 0;
                    }
                }
            }
            menu.AddOption( SLEEP );
        }

        public void Draw() {
            Console.Write( Speakers.ELIOT );
            if ( wakedUp ) {
                Console.WriteLine( "Muszę zebrać sprzęt i zdążyć na Coney Island zanim zaczną akcje beze mnie.. egh.." );
            } else {
                if ( sleep % 10 == 0 ) {
                    Console.WriteLine( "Eghh.. ała.. mmm... moja głowa.. godzina? " + hours + ":" + minutes + "! Poduszka znowu na podłodze.. egh.. ała.." );
                } else {
                    string snore = "";
                    for ( int i = 0; i < sleep % 10; i++ ) {
                        if ( i % 3 == 0 ) snore += Display.YELLOW + "zzz... " + Display.WHITE;
                        else if ( i % 3 == 1 ) snore += Display.RED + "zzz... " + Display.WHITE;
                        else snore += Display.MAGENTA + "zzz... " + Display.WHITE;
                    }
                    Console.WriteLine( snore );
                }
            }
            Console.WriteLine();

            menu.Draw();
        }

        public bool HandleKeyPress( char choice ) {
            if ( menu.HandleKeyPress( choice) ) {
                return true;
            } else if ( choice == ( char ) 32 ) {
                if ( menu.GetCurrent() == WAKE_UP ) {
                    if ( wakedUp ) {
                        GameController.Instance().SetDialog( null );
                        MainQuest.OnWakeUp();
                    } else {
                        wakedUp = true;
                        menu = new Menu( new List<string>() { WAKE_UP } );
                    }
                } else if ( menu.GetCurrent() == SLEEP ) {
                    GameController.Instance().SetDialog( new WakeUpDialog( sleep + 1 ) );
                }

                return true;
            }

            return false;
        }
    }
}