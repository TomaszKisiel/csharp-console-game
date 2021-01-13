using System;

namespace RGame {

    [Serializable]
    public class ServersDoor : Interactable {

        public bool ActiveInRange { get => true; }
        public int Throttle = 3;
        public bool Open = false;

        public void Interact() {
            if ( Open == true ) {
                GameController.Instance().SetPlayer( new Point( 27, 14 ) );
                GameController.Instance().SetRoom( RoomsRepository.Instance().Get( "servers" ) );
            } else {
                GameController.Instance().SetDialog( new ServersDoorDialog() );
            }
        }

    }
}
