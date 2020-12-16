using System;
using System.Collections.Generic;

namespace Game {
    public class RoomsRepository {

        private static RoomsRepository instance = null;
        private Dictionary<string, IRoom> rooms = new Dictionary<string, IRoom>();

        private RoomsRepository() {
            rooms.Add( "eliots_house", new EliotsHouse() );
            rooms.Add( "housing_estate", new HousingEstate() );
        }

        public static RoomsRepository GetInstance() {
            if ( instance == null ) {
                instance = new RoomsRepository();
            }
            return instance;
        }

        public IRoom GetRoom( string slug ) {
            IRoom room;
            rooms.TryGetValue( slug, out room );
            return room;
        }
    }
}
