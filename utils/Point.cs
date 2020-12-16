using System;

namespace Game {
    public class Point {
        public int X;
        public int Y;

        public Point( int x, int y ) {
            X = x;
            Y = y;
        }

        public bool IsEquals( int x, int y ) {
            if ( x == this.X && y == this.Y ) {
                return true;
            }

            return false;
        }

        public override bool Equals(object obj) {
            if ( this.GetType().Equals( obj.GetType() ) ) {
                Point that = ( Point ) obj;

                if ( this.X == that.X && this.Y == that.Y ) {
                    return true;
                }
            }

            return false;
        }
    }
}