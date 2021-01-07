using System;

namespace RGame {

    [Serializable]
    public class PasswordNote : Interactable {

        public bool ActiveInRange { get => true; }

        public void Interact() {
            GameController.Instance().SetDialog( new PasswordNoteDialog() );
        }

    }
}
