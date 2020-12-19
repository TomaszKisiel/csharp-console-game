using System;

namespace RGame {

    [Serializable]
    public class Door : Interactable {

        private Room destination;
        private Point position;

        public Door( string slug, Point pos ) {
            destination = RoomsRepository.Instance().Get( slug );
            position = pos;
        }

        public bool ActiveInRange { get => false; }

        public void Interact() {
            GameController.Instance().SetPlayer( position );
            GameController.Instance().SetRoom( destination );
        }

    }
}