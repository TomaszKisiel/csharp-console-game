using System;
using System.Collections.Generic;

namespace RGame {
    public class RoomsRepository {

        private static RoomsRepository instance = null;
        private Dictionary<string, Room> repo = new Dictionary<string, Room>();

        private RoomsRepository() {
            repo.Add( "eliot_house", new EliotHouseRoom() );
            repo.Add( "housing_estate", new HousingEstateRoom() );
            repo.Add( "coney_island", new ConeyIslandRoom() );
            repo.Add( "fsociety", new FSocietyRoom() );
            repo.Add( "corridor_i", new CorridorIRoom() );
            repo.Add( "corridor_ii", new CorridorIIRoom() );
            repo.Add( "corridor_iii", new CorridorIIIRoom() );
            repo.Add( "corridor_iv", new CorridorIVRoom() );
            repo.Add( "parking", new ParkingRoom() );
            repo.Add( "lobby", new LobbyRoom() );
            repo.Add( "open_space", new OpenSpaceRoom() );
            repo.Add( "servers", new ServersRoom() );
            repo.Add( "toilets", new ToiletsRoom() );
        }

        public static RoomsRepository Instance() {
            if ( instance == null ) {
                instance = new RoomsRepository();
            }
            return instance;
        }

        public Room Get( string slug ) {
            Room room;
            if ( !repo.TryGetValue( slug, out room ) ) {
                throw new KeyNotFoundException();
            }

            return room;
        }
    }
}