using System;

namespace RGame {
    public class Point {
        private int x;
        private int y;

        public Point( int x, int y ) {
            this.x = x;
            this.y = y;
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