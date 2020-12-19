using System;

namespace RGame {
    [Serializable]
    public class Point {
        private int x;
        private int y;

        public int X { get; }
        public int Y { get; }

        public Point( int x, int y ) {
            this.x = x;
            this.y = y;
        }

        public bool IsNeighbour( Point that ) {
            if (
                ( this.x == that.GetX() - 1 && this.y == that.GetY() + 1 ) ||
                ( this.x == that.GetX()     && this.y == that.GetY() + 1 ) ||
                ( this.x == that.GetX() + 1 && this.y == that.GetY() + 1 ) ||
                ( this.x == that.GetX() + 1 && this.y == that.GetY() ) ||
                ( this.x == that.GetX() + 1 && this.y == that.GetY() - 1 ) ||
                ( this.x == that.GetX()     && this.y == that.GetY() - 1) ||
                ( this.x == that.GetX() - 1 && this.y == that.GetY() - 1) ||
                ( this.x == that.GetX() - 1 && this.y == that.GetY() )
            ) {
                return true;
            }

            return false;
        }

        public override bool Equals( Object obj ) {
            if ( this.GetType().Equals( obj.GetType() ) ) {
                Point that = ( Point ) obj;

                if ( this.x == that.GetX() && this.y == that.GetY() ) {
                    return true;
                }
            }

            return false;
        }

        public override int GetHashCode() {
            return x * y;
        }

        public int GetX() {
            return x;
        }

        public int GetY() {
            return y;
        }
    }
}