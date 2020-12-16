using System;

namespace Game {
    class PlayState : IGameState {

        public override void Draw() {
            Headers.Branding();
            GameController.GetInstance().GetRoom().Draw(); // Demeter chyba cierpi katusze jak to widzi XD

            Dialog status = GameController.GetInstance().GetStatus();
            if ( status != null ) {
                Console.WriteLine();
                status.Draw();
            }

            Dialog dialog = GameController.GetInstance().GetDialog();
            if ( dialog != null ) {
                Console.WriteLine();
                dialog.Draw();
            }
            Console.WriteLine();
        }

        public override void Hints()
        {
            Dialog dialog = GameController.GetInstance().GetDialog();
            if ( dialog is ControlledDialog ) {
                ( dialog as ControlledDialog ).Hints();
            } else {
                Utils.PrintHint( "[WSAD]", "Poruszanie" );
                Utils.PrintHint( "[SPACE]", "Interakcja" );
                Utils.PrintHint( "[Q]", "Zadania" );
                Utils.PrintHint( "[E]", "Ekwipunek" );
                Utils.PrintHint( "[ESC]", "Menu" );
                Console.WriteLine();
            }
        }

        public override void HandleKeyPress( char choice ) {
            Point player = GameController.GetInstance().GetPlayer();
            IRoom room = GameController.GetInstance().GetRoom();
            Dialog dialog = GameController.GetInstance().GetDialog();

            if ( dialog is ControlledDialog ) {
//                ControlledDialog cd = ( ControlledDialog ) dialog;
//                cd.HandleKeyPress( choice );
                ( dialog as ControlledDialog ).HandleKeyPress( choice );
            } else {
                if ( choice == 'e' ) {
                    this.context.SetState( new EquipmentState() );
                } else if ( choice == 'q' ) {
                    this.context.SetState( new QuestsState() );
                } else if ( choice == ( char ) 32 ) {
                    room.Interact();
                    room.DoorsCheck();
                } else if ( choice == ( char ) 27 ) {
                    this.context.SetState( new PauseMenuState() );
                } else if ( choice == 'w' ) {
                    Point nextPlayer = new Point( player.X, player.Y - 1 );
                    if ( nextPlayer.Y > 0 && nextPlayer.Y < room.GetHeight() ) {
                        if ( room.CollisionCheck( nextPlayer ) == false ) {
                            GameController.GetInstance().SetPlayer( nextPlayer );
                        }
                    }
                }  else if ( choice == 's' ) {
                    Point nextPlayer = new Point( player.X, player.Y + 1 );
                    if ( nextPlayer.Y > 0 && nextPlayer.Y < room.GetHeight() ) {
                        if ( room.CollisionCheck( nextPlayer ) == false ) {
                            GameController.GetInstance().SetPlayer( nextPlayer );
                        }
                    }
                } else if ( choice == 'a' ) {
                    Point nextPlayer = new Point( player.X - 1, player.Y );
                    if ( nextPlayer.X > 0 && nextPlayer.X < room.GetWidth() ) {
                        if ( room.CollisionCheck( nextPlayer ) == false ) {
                            GameController.GetInstance().SetPlayer( nextPlayer );
                        }
                    }
                } else if ( choice == 'd' ) {
                    Point nextPlayer = new Point( player.X + 1, player.Y );
                    if ( nextPlayer.X > 0 && nextPlayer.X < room.GetWidth() ) {
                        if ( room.CollisionCheck( nextPlayer ) == false ) {
                            GameController.GetInstance().SetPlayer( nextPlayer );
                        }
                    }
                }
            }

        }

    }
}
