using System;

namespace Game {
    public abstract class Interactable {
        public Point[] Positions;
        public bool ActiveInRange;

        public Interactable( Point[] pos, bool activeInRange ) {
            Positions = pos;
            ActiveInRange = activeInRange;
        }

        public abstract void Interact();

        public bool InRange( Point p ) {
            foreach ( Point pos in Positions ) {
                if (
                    p.Equals( pos ) ||
                    p.Equals( new Point( pos.X - 1, pos.Y - 1 ) ) ||
                    p.Equals( new Point( pos.X,     pos.Y - 1 ) ) ||
                    p.Equals( new Point( pos.X + 1, pos.Y - 1 ) ) ||
                    p.Equals( new Point( pos.X + 1, pos.Y     ) ) ||
                    p.Equals( new Point( pos.X + 1, pos.Y + 1 ) ) ||
                    p.Equals( new Point( pos.X,     pos.Y + 1 ) ) ||
                    p.Equals( new Point( pos.X - 1, pos.Y + 1 ) ) ||
                    p.Equals( new Point( pos.X - 1, pos.Y     ) )
                ) {
                    return true;
                }
            }


            return false;
        }
    }
}