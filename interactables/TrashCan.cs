using System;

namespace RGame {

    [Serializable]
    public class TrashCan : Interactable {

        public bool ContainsPicklock = true;

        public bool ActiveInRange { get => true; }

        public void Interact() {
            GameController.Instance().SetDialog( new TrashCanDialog( ContainsPicklock ) );
        }

    }
}