using System;

namespace RGame {

    [Serializable]
    public class Bill : Interactable {

        public bool CheatAttemptPossible = true;

        public bool ActiveInRange { get => true; }

        public void Interact() {
            GameController.Instance().SetDialog( new BillDialog( CheatAttemptPossible ) );
        }

    }
}
