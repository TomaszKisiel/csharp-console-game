using System;

namespace Game {
    public class Status : Dialog {

        private string text = "";

        public Status( string text ) {
            this.text = text;
        }

        public void Draw() {
            Console.Write( Utils.Red + "Status: " + Utils.White );
            Utils.PrintWrappedText( text );
        }
    }
}