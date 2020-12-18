using System;

namespace RGame {
    [Serializable]
    public abstract class Room : Drawable {
        public abstract string RoomName { get; }
        public abstract string[] MapLayer { get; }
        public abstract string[] ColorsLayer { get; }
        public abstract string[] CollisionsLayer { get; }
//        protected abstract Interactable[] Interactables();

        public void Draw() {
            Point player = GameController.Instance().GetPlayer();

            for ( int y = 0; y < MapLayer.Length; y++ ) {
                for ( int x = 0; x < MapLayer[y].Length; x++ ) {
                    if (
                        CollisionsLayer[y][x] != '@' &&
                        player != null &&
                        player.Equals( new Point( x, y ) )
                    ) {
                        Console.Write( Display.GREEN + "#" + Display.WHITE );
                    } else {
                        if ( ColorsLayer[y][x] == 'G' ) {
                            Console.Write( Display.GREEN );
                        } else if ( ColorsLayer[y][x].Equals( 'Y' ) ) {
                            Console.Write( Display.YELLOW );
                        } else if ( ColorsLayer[y][x].Equals( 'B' ) ) {
                            Console.Write( Display.BLUE );
                        } else if ( ColorsLayer[y][x].Equals( 'C' ) ) {
                            Console.Write( Display.CYAN );
                        } else if ( ColorsLayer[y][x].Equals( 'M' ) ) {
                            Console.Write( Display.MAGENTA );
                        } else if ( ColorsLayer[y][x].Equals( 'R' ) ) {
                            Console.Write( Display.RED );
                        }

                        Console.Write( MapLayer[y][x] );
                        Console.Write( Display.WHITE );
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine( "Lokalizacja: " + Display.BLUE + RoomName + Display.WHITE );
            Console.WriteLine();
        }

        public bool CollisionCheck( Point player ) {
            return CollisionsLayer[ player.GetY() ][ player.GetX() ] == '#';
        }

        public int GetHeight() {
            return MapLayer.Length;
        }

        public int GetWidth() {
            return MapLayer[0].Length;
        }
    }
}
