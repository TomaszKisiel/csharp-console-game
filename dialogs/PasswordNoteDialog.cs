using System;
using System.Collections.Generic;

namespace RGame {
    public class PasswordNoteDialog : Dialog {
        private const string LEAVE = "Odchodzę";

        private Menu menu = new Menu();

        public PasswordNoteDialog() {
            menu.AddOption( LEAVE );
        }

        public void Draw() {
            Console.Write( Speakers.PASSWORD_NOTE );
            Console.WriteLine( "Na jednym z biurek ktoś zostawił kartkę z notatką, między liniami bazgrołów dostrzegasz ciąg liczb 7800.. co robisz?" );
            Console.WriteLine();

            menu.Draw();
        }

        public bool HandleKeyPress( char choice ) {
            if ( menu.HandleKeyPress( choice) ) {
                return true;
            } else if ( choice == ( char ) 32 ) {
                if ( menu.GetCurrent() == LEAVE ) {
                    GameController.Instance().SetDialog( null );
                }

                return true;
            }

            return false;
        }
    }
}
