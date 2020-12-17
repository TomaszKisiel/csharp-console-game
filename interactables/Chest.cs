using System;

namespace RGame {

    [Serializable]
    public class Chest : Interactable {

        public bool ContainsRaspberry = true;
        public bool ContainsDuck = true;

        public void Interact() {
            if ( ContainsRaspberry && ContainsRaspberry ) {
                Console.WriteLine( "Skrzynka z kaczuszką i raspberry pi." );
            } else if ( ContainsRaspberry ) {
                Console.WriteLine( "Skrzynka z raspberry pi." );
            } else if ( ContainsDuck ) {
                Console.WriteLine( "Skrzynka z kaczuszką." );
            } else {
                Console.WriteLine( "Pusta skrzynka." );
            }
        }

    }
}