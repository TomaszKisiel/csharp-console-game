using System;

namespace Game {
    public abstract class IRoom {
        protected abstract string[] MapLayer { get; }
        protected abstract string[] ColorsLayer { get; }
        protected abstract string[] CollisionsLayer { get; }
        protected abstract Door[] Doors { get; }
        protected Interactable[] interactables = null;
        protected string roomName;

        private Interactable interacted = null;

        public void Draw() {
            Point player = GameController.GetInstance().GetPlayer();

            for ( int y = 0; y < MapLayer.Length; y++ ) {
                for ( int x = 0; x < MapLayer[y].Length; x++ ) {
                    if ( ColorsLayer[y][x] == 'G' ) {
//                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write( Utils.Green );
                    } else if ( ColorsLayer[y][x].Equals( 'Y' ) ) {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    } else if ( ColorsLayer[y][x].Equals( 'B' ) ) {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    } else if ( ColorsLayer[y][x].Equals( 'C' ) ) {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    } else if ( ColorsLayer[y][x].Equals( 'M' ) ) {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    } else if ( ColorsLayer[y][x].Equals( 'R' ) ) {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    if ( CollisionsLayer[y][x] == '@' ) {
                        Console.Write( MapLayer[y][x] );
                    } else if ( player.IsEquals( x, y ) ) {
                        Console.Write( Utils.Green + "#" + Utils.White );
                    } else {
                        Console.Write( MapLayer[y][x] );
                    }

                    Console.Write( Utils.White );
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
            }

            Console.WriteLine( "Lokalizacja: " + Utils.Blue + roomName + Utils.White );

            if ( interacted != null ) {
//                Console.WriteLine();
                interacted.Interact();
                interacted = null;
            }
        }

        public bool CollisionCheck( Point player ) {
            if ( CollisionsLayer[ player.Y ][ player.X ] == '#' ) {
                return true;
            }

            return false;
        }

        public void DoorsCheck() {
            Point player = GameController.GetInstance().GetPlayer();

            for ( int i = 0; i < Doors.Length; i++ ) {
                Console.WriteLine( player.X + " " + player.Y + " | " + Doors[i].Position.X + " " + Doors[i].Position.Y );
                if ( player.Equals( Doors[i].Position ) ) {
                    GameController.GetInstance().SetRoom(
                        RoomsRepository.GetInstance().GetRoom( Doors[i].RoomSlug )
                    );
                    GameController.GetInstance().SetPlayer( Doors[i].TransitionTo );
                    break;
                }
            }
        }

        public void Interact() {
            if ( interactables != null ) {
                Point player = GameController.GetInstance().GetPlayer();

                for ( int i = 0; i < interactables.Length; i++ ) {
                    if ( interactables[i].InRange( player ) ) {
                        interacted = interactables[i];
                        break;
                    }
                }
            }
        }

        public int GetHeight() {
            return MapLayer.Length;
        }

        public int GetWidth() {
            return MapLayer[0].Length;
        }
    }
}
