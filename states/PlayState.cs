using System;

namespace Game {
    class PlayState : IGameState {

        public override void Draw() {
            Headers.Branding();
            GameController.GetInstance().GetRoom().Draw(); // Demeter chyba cierpi katusze jak to widzi XD
            Console.WriteLine();
        }

        public override void Hints()
        {
            Utils.PrintHint( "[WSAD]", "Poruszanie" );
            Utils.PrintHint( "[SPACE]", "Interakcja" );
            Utils.PrintHint( "[Q]", "Zadania" );
            Utils.PrintHint( "[E]", "Ekwipunek" );
            Utils.PrintHint( "[ESC]", "Menu" );
            Console.WriteLine();
        }

        public override void HandleKeyPress( char choice ) {
            if ( choice == 'e' ) {
                this.context.SetState( new EquipmentState() );
            } else if ( choice == 'q' ) {
                this.context.SetState( new QuestsState() );
            } else if ( choice == ( char ) 32 ) {

            } else if ( choice == ( char ) 27 ) {
                this.context.SetState( new PauseMenuState() );
            } else if ( choice == 'w' ) {

            }  else if ( choice == 's' ) {

            } else if ( choice == 'a' ) {

            } else if ( choice == 'd' ) {

            }
        }

    }
}
