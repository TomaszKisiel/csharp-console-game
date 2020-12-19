using System;

namespace RGame {

    [Serializable]
    public class SDCardHolder : Interactable {

        public bool ContainsSDCard = true;

        public bool ActiveInRange { get => true; }

        public void Interact() {
            GameController.Instance().SetDialog( new SDCardHolderDialog( ContainsSDCard ) );
        }

    }
}