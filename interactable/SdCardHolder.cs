using System;

namespace Game {
    public class SdCardHolder : Interactable {

        public SdCardHolder( Point[] pos, bool air ) : base( pos, air ) {}

        public override void Interact() {
            GameController.GetInstance().SetDialog( new SdCardHolderDialog() );
        }

    }
}