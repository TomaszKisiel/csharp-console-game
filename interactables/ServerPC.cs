using System;

namespace RGame {

    [Serializable]
    public class ServerPC : Interactable {

        public bool ActiveInRange { get => true; }
        public bool Hacked = false;

        public void Interact() {
            GameController.Instance().SetDialog( new ServerPCDialog( Hacked ) );
        }

    }
}
