using System;

namespace Game {
    public class EliotsPc : Interactable {

        public EliotsPc( Point[] pos, bool air ) : base( pos, air ) {}

        public override void Interact() {
            GameController.GetInstance().SetDialog( new EliotsPcDialog() );
        }

    }
}