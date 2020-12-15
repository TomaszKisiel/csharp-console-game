using System;

namespace Game {
    class Door {
        public int X;
        public int Y;
        public IRoom Room;

        public Door( int x, int y, IRoom room ) {
            X = x;
            Y = y;
            Room = room;
        }
    }
}
