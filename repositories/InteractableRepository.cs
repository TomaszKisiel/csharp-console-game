using System;
using System.Collections.Generic;

namespace RGame {
    public class InteractableRepository {

        private static InteractableRepository instance = null;
        private Dictionary<string, Interactable> repo = new Dictionary<string, Interactable>();

        private InteractableRepository() {
            repo.Add( "chest", new Chest() );
        }

        public static InteractableRepository Instance() {
            if ( instance == null ) {
                instance = new InteractableRepository();
            }
            return instance;
        }

        public Interactable Get( string slug ) {
            Interactable interactable;
            repo.TryGetValue( slug, out interactable );
//            if ( !repo.TryGetValue( slug, out interactable ) ) {
//                throw new KeyNotFoundException();
//            }

            return interactable;
        }
    }
}