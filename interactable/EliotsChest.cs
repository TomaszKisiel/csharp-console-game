using System;

namespace Game {
    public class EliotsChest : Interactable {

        public EliotsChest( Point[] pos, bool air ) : base( pos, air ) {}

        public override void Interact() {
            GameController.GetInstance().SetDialog( new EliotsChestDialog() );

//            Console.WriteLine( "Zdobyto: " + Utils.Yellow + "Raspberry Pi!" + Utils.White );
        }

    }
}