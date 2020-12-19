using System;
using System.Collections.Generic;

namespace RGame {
    [Serializable]
    public class InteractablesRepository {

        [NonSerialized]
        private static InteractablesRepository instance = null;
        private Dictionary<string, Interactable> repo = new Dictionary<string, Interactable>();

        private InteractablesRepository() {
            repo.Add( "chest", new Chest() );
            repo.Add( "eliot_pc", new EliotPC() );
            repo.Add( "sd_card_holder", new SDCardHolder() );
        }

        public static InteractablesRepository Instance() {
            if ( instance == null ) {
                instance = new InteractablesRepository();
            }
            return instance;
        }

        public static void InjectRepository( InteractablesRepository injection ) {
            if ( injection != null ) {
                instance = injection;
            }
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