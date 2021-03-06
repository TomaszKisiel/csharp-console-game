using System;
using System.Collections.Generic;

namespace RGame {
    public class Menu : Drawable, Controllable {
        private List<string> options = null;
        private int cursorPos = 0;

        public Menu() {
            this.options = new List<string>();
        }

        public Menu( List<string> options ) {
            this.options = options;
        }

        public void Draw() {
            if ( options != null ) {
                for ( int i = 0; i < options.Count; i++ ) {
                    if ( cursorPos == i ) {
                        Console.Write( Display.RED + "> " + Display.WHITE );
                    } else {
                        Console.Write("  ");
                    }

                    Console.WriteLine( options[i] );
                }
            }
            Console.WriteLine();
        }

        public void Next() {
            cursorPos += 1;
            if ( cursorPos > options.Count - 1 ) {
                cursorPos = 0;
            }
        }

        public void Previous() {
            cursorPos -= 1;
            if ( cursorPos < 0 ) {
                cursorPos = options.Count - 1;
            }
        }

        public void AddOption( string opt ) {
            options.Add( opt );
        }

        public void RemoveOption( string opt ) {
            options.Remove( opt );
        }

        public void SetCursor( int pos ) {
            cursorPos = pos;
        }

        public string GetCurrent() {
            if ( cursorPos >= 0 && cursorPos < options.Count ) {
                return options[cursorPos];
            }

            return "";
        }

        public bool HandleKeyPress( char choice ) {
            if ( choice == 's' || choice == 'S' ) {
                Next();
                return true;
            } else if ( choice == 'w' || choice == 'W' ) {
                Previous();
                return true;
            }

            return false;
        }
    }
}