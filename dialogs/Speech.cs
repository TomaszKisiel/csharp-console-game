using System;

namespace Game {
    public class Speech : Dialog {

        private string speaker = "";
        private string text = "";

        public Speech( string speaker, string text ) {
            this.speaker = speaker;
            this.text = text;
        }

        public void Draw() {
            Console.Write( Utils.Red + speaker + Utils.White );
            Utils.PrintWrappedText( text );
        }
    }
}