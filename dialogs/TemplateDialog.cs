using System;
using System.Collections.Generic;

namespace RGame {
    public abstract class TemplateDialog : Dialog {
        private const string LEAVE = "Odchodzę";

        private Menu menu = new Menu();

        public TemplateDialog() {
            menu.AddOption( LEAVE );
        }

        public void Draw() {
            Console.WriteLine("..");
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