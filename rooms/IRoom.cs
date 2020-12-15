using System;

namespace Game {
    abstract class IRoom {
        protected abstract string[] MapLayer { get; }
        protected abstract string[] ColorsLayer { get; }
        protected abstract string[] CollisionsLayer { get; }

        public void Draw() {
            for ( int y = 0; y < MapLayer.Length; y++ ) {
                for ( int x = 0; x < MapLayer[y].Length; x++ ) {
                    if ( ColorsLayer[y][x] == 'G' ) {
                        Console.ForegroundColor = ConsoleColor.Green;
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
                    } else {
                        Console.Write( MapLayer[y][x] );
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
            }
        }
    }
}