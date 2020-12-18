using System;

namespace RGame {
    public class Hints {

        public static void Menu() {
            Draw( "SPACJA", "Wybierz" );
            Draw( "W", "Góra" );
            Draw( "S", "Dół" );
        }

        public static void Draw( string key, string desc ) {
            Console.Write( Display.CYAN);
            Console.Write( "[" + key + "] " );
            Console.Write( Display.WHITE );
            Console.Write( desc + "    " );
        }

    }
}