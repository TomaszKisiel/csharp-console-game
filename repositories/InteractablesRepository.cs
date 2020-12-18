using System;
using System.Collections.Generic;

namespace RGame {
    public class InteractablesRepository {

        private static InteractablesRepository instance = null;
        private Dictionary<string, Interactable> repo = new Dictionary<string, Interactable>();

        private InteractablesRepository() {
            repo.Add( "chest", new Chest() );
        }

        public static InteractablesRepository Instance() {
            if ( instance == null ) {
                instance = new InteractablesRepository();
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