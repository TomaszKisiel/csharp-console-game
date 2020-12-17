using System;
using System.Collections.Generic;

namespace Game {
    public class TemplateDialog : ControlledDialog {
        private const string LEAVE = "Odchodzę";

        private static List<string> options = new List<string>() { LEAVE };
        private int cursorPos = 0;

        public void Draw() {
            Console.Write( Speakers.BUS_STOP );
            Utils.PrintWrappedText( "..", 48 );
            Utils.DrawMenu( options, cursorPos );
        }

        public void HandleKeyPress( char choice ) {
            if ( choice == ( char ) 32 ) {
                if ( options[ cursorPos ] == LEAVE ) {
                    GameController.GetInstance().SetDialog( null );
                } /* else if ( options[ cursorPos ] == WATCH_YT ) {

                } */
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