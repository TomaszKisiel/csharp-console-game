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
            repo.Add( "bus_stop", new BusStop() );
            repo.Add( "trash_can", new TrashCan() );
            repo.Add( "assistant", new Assistant() );
            repo.Add( "team_on_coney_island", new TeamOnConeyIsland() );
            repo.Add( "mr_robot_parking", new MrRobotParking() );
            repo.Add( "bill", new Bill() );
            repo.Add( "password_note", new PasswordNote() );
            repo.Add( "lobby_backdoor", new LobbyBackdoor() );
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
