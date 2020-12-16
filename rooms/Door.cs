using System;

namespace Game {
    public class Door {
        public Point Position;
        public string RoomSlug;
        public Point TransitionTo;

        public Door( Point pos, string roomSlug, Point transition ) {
            Position = pos;
            RoomSlug = roomSlug;
            TransitionTo = transition;
        }
    }
}
