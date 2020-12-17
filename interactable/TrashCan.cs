using System;

namespace Game {
    public class TrashCan : Interactable {

        public TrashCan( Point[] pos, bool air ) : base( pos, air ) {}

        public override void Interact() {
            GameController.GetInstance().SetDialog( new TrashCanDialog() );
        }

    }
}