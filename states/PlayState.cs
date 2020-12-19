using System;

namespace RGame {
    class PlayState : GameState {

        public override void Draw() {
            Headers.Branding();

            Dialog dialog = GameController.Instance().GetDialog();
            if ( dialog != null ) {
                GameController.Instance().GetEquipmentMessage()?.Draw();
                dialog.Draw();
            } else {
                GameController.Instance().GetRoom().Draw();
                GameController.Instance().GetQuestMessage()?.Draw();

                GameController.Instance().GetEquipmentMessage()?.CleanTick();
                GameController.Instance().GetEquipmentMessage()?.Draw();
            }
        }

        public override void DrawHints()
        {
            Dialog dialog = GameController.Instance().GetDialog();
            if ( dialog != null ) {
                Hints.Menu();
            } else {
                Hints.Draw( "WSAD", "Poruszanie" );
                Hints.Draw( "SPACJA", "Interakcja" );
                Hints.Draw( "E", "Ekwipunek" );
                Hints.Draw( "ESC", "Menu" );
            }

            Console.WriteLine();
        }

        public override bool HandleKeyPress( char choice ) {
            Dialog dialog = GameController.Instance().GetDialog();

            if ( dialog != null ) {
                return dialog.HandleKeyPress( choice );
            } else if ( choice == 'e' || choice == 'E' ) {
                this.context.SetState( new EquipmentState() );
                return true;
            } else if ( choice == ( char ) 32 ) {
                GameController.Instance().GetRoom().Interact();
                return true;
            } else if ( choice == ( char ) 27 ) {
                this.context.SetState( new PauseMenuState() );
                return true;
            } else if (
                choice == 'w' || choice == 'W' ||
                choice == 's' || choice == 'S' ||
                choice == 'a' || choice == 'A' ||
                choice == 'd' || choice == 'D'
            ) {
                Point player = GameController.Instance().GetPlayer();

                if ( player != null ) {
                    if ( choice == 'w' || choice == 'W' ) {
                        MovePlayer( new Point( player.GetX(), player.GetY() - 1 ) );
                    } else if ( choice == 's' || choice == 'S' ) {
                        MovePlayer( new Point( player.GetX(), player.GetY() + 1 ) );
                    } else if ( choice == 'a' || choice == 'A' ) {
                        MovePlayer( new Point( player.GetX() - 1, player.GetY() ) );
                    } else if ( choice == 'd' || choice == 'D' ) {
                        MovePlayer( new Point( player.GetX() + 1, player.GetY() ) );
                    }
                }

                return true;
            }

            return false;
        }

        private void MovePlayer( Point pos ) {
            Room room = GameController.Instance().GetRoom();

            if (
                pos.GetX() > -1 && pos.GetX() < room.GetWidth() &&
                pos.GetY() > -1 && pos.GetY() < room.GetHeight()
            ) {
                if ( room.CollisionCheck( pos ) == false ) {
                    GameController.Instance().SetPlayer( pos );
                }
            }
        }

    }
}
