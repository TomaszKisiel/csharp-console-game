using System;

namespace Game {
    public class EliotsEmptyChestDialog : Dialog {
        public void Draw() {
//            Console.Write( Speaker );
            Utils.PrintWrappedText( "Wewnątrz skrzynki pomiędzy stertą elektronicznych rupieci nie znajdujesz nic ciekawego.", 48 );
        }
    }
}