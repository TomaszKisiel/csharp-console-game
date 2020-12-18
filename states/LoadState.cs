using System;
using System.Collections.Generic;
using System.IO;
//using System.Text;
//using System.Linq;

namespace RGame {
    class LoadState : GameState {
        private Menu menu = null;
        private GameState backTo = null;

        public LoadState( GameState state ) {
            menu = new Menu( GetMenu() );
            backTo = state;
        }

        public override void Draw() {
            Headers.Load();
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
                string save = menu.GetCurrent();
                if ( save != null ) {
                    GameController.Instance().Load( save );
                    this.context.SetState( new PlayState() );
                }

                return true;
            } else if ( choice == (char) 27 ) {
                this.context.SetState( backTo );
                return true;
            }

            return false;
        }

        private List<string> GetMenu() {
            List<string> menu = new List<string>();

            string[] saves = Directory.GetDirectories( ".saves" );
            foreach ( string save in saves ) {
                menu.Add( Path.GetFileName( save ) );
            }

            return menu;
        }
    }
}
