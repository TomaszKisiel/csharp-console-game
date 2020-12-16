using System;

namespace Game {
    public interface ControlledDialog : Dialog {
        public void HandleKeyPress( char choice );
        public void Hints() {
            Utils.PrintHint( "[SPACE]", "Wybierz" );
            Utils.PrintHint( "[W]", "Góra" );
            Utils.PrintHint( "[S]", "Dół" );
            Console.WriteLine();
        }
    }
}