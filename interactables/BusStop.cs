using System;

namespace RGame {

    [Serializable]
    public class BusStop : Interactable {

        public bool ActiveInRange { get => true; }

        public void Interact() {
            GameController.Instance().SetDialog( new BusStopDialog() );
        }

    }
}