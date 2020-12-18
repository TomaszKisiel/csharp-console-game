using System;

namespace RGame {

    public class Display {
        public const string BLACK = "\u001b[30m";
        public const string RED = "\u001b[31m";
        public const string GREEN = "\u001b[32m";
        public const string YELLOW = "\u001b[33m";
        public const string BLUE = "\u001b[34m";
        public const string MAGENTA = "\u001b[35m";
        public const string CYAN = "\u001b[36m";
        public const string WHITE = "\u001b[37m";

        public static void WrappedText( string text, int limit = 52, string prefix = "" ) {
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

    }
}