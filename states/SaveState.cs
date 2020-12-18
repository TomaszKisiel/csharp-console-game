using System;
using System.Collections.Generic;
using System.IO;
//using System.Text;
//using System.Linq;

namespace RGame {
    class SaveState : GameState {
        private const string NEW_SAVE = Display.GREEN + "[ NOWY ZAPIS ]" + Display.WHITE;

        private Menu menu = null;
        private string saved = null;

        public SaveState() {
            menu = new Menu( GetMenu() );
        }

        public override void Draw() {
            Headers.Save();

            if ( saved != null ) {
                Console.WriteLine( "Zapisano pod nazwą: " + Display.BLUE + saved + Display.WHITE );
                Console.WriteLine();
            }

            menu.Draw();
        }

        public override void DrawHints() {
            Hints.Menu();
            Hints.Draw( "ESC", "Anuluj" );
        }

        public override bool HandleKeyPress( char choice ) {
            if ( menu.HandleKeyPress( choice) ) {
                return true;
            } else if ( choice == (char) 32 ) {
                if ( menu.GetCurrent() == NEW_SAVE ) {
                    string save = DateTime.Now.Ticks.ToString();
                    if ( GameController.Instance().Save( save ) ) {
                        saved = save;
                    };
                } else {
                    string save = menu.GetCurrent();
                    if ( GameController.Instance().Save( save ) ) {
                        saved = save;
                    };
                }

                menu = new Menu( GetMenu() );
                return true;
            } else if ( choice == (char) 27 ) {
                this.context.SetState( new PauseMenuState() );
                return true;
            }

            return false;
        }

        private List<string> GetMenu() {
            List<string> menu = new List<string>() { NEW_SAVE };

            string[] saves = Directory.GetDirectories( ".saves" );
            foreach ( string save in saves ) {
                menu.Add( Path.GetFileName( save ) );
            }

            return menu;
        }
    }
}
