using System;

namespace RGame {

    [Serializable]
    public class Chest : Interactable {

        public bool ContainsRaspberry = true;
        public bool ContainsDuck = true;

        public bool ActiveInRange { get => true; }

        public void Interact() {
            GameController.Instance().SetDialog( new ChestDialog( ContainsRaspberry, ContainsDuck ) );
        }

    }
}