using System;

namespace Game {
    public class BusStop : Interactable {

        public BusStop( Point[] pos, bool air ) : base( pos, air ) {}

        public override void Interact() {
            GameController.GetInstance().SetDialog( new BusStopDialog() );
        }

    }
}