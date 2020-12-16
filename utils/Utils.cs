using System;

namespace Game {
    class Utils {
        public static string Black = "\u001b[30m";
        public static string Red = "\u001b[31m";
        public static string Green = "\u001b[32m";
        public static string Yellow = "\u001b[33m";
        public static string Blue = "\u001b[34m";
        public static string Magenta = "\u001b[35m";
        public static string Cyan = "\u001b[36m";
        public static string White = "\u001b[37m";

        public static void PrintWrappedText( string text, int limit = 52, string prefix = "" ) {
            int wordWrap = 0;

            Console.Write( prefix );
            foreach ( char letter in text ) {
                Console.Write( letter );

                if ( wordWrap > limit && letter == ' ' ) {
                    Console.WriteLine();
                    Console.Write( prefix );
                    wordWrap = 0;
                }

                wordWrap++;
            }
            Console.WriteLine();

        }

        public static void PrintHint( string key, string desc ) {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write( key + " " );
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write( desc + "    " );
        }
    }
}
