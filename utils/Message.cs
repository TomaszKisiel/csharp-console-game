using System;

namespace RGame {
    [Serializable]
    public class Message : Drawable {
        private string speaker;
        private string message;
        private int clean = 0;

        public Message( string speaker, string msg ) {
            this.speaker = speaker;
            this.message = msg;
        }

        public void CleanTick() {
            clean++;
            if ( clean > 20 ) {
                clean = 0;

                speaker = null;
                message = null;
            }
        }

        public void Draw() {
            if ( message != null && speaker != null ) {
                Console.Write( speaker );
                Console.Write( message );
                Console.WriteLine("\n");
            }
        }
    }
}