using System;

namespace RGame {

    [Serializable]
    public class LobbyBackdoor : Interactable {

        public bool ActiveInRange { get => false; }

        public void Interact() {
            GameController.Instance().SetDialog( new LobbyBackdoorDialog() );
        }

    }
}
