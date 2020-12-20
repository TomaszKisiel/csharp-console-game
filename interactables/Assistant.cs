using System;

namespace RGame {

    [Serializable]
    public class Assistant : Interactable {

        public bool ActiveInRange { get => true; }

        public void Interact() {
            GameController.Instance().SetDialog( new AssistantDialog() );
        }

    }
}