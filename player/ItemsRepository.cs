using System;
using System.Collections.Generic;

namespace Game {
    public class ItemsRepository {

        private static ItemsRepository instance = null;
        private Dictionary<string, Item> items = new Dictionary<string, Item>();

        private ItemsRepository() {
            items.Add( "raspberry_pi_without_sd_card", new Item( "Raspberry Pi", "Miniaturowy komputer wielkości karty kredytowej.. brakuje w nim jedynie karty z systemem operacyjnym.", 59 ) );
            items.Add( "blank_sd_card", new Item( "Karta pamięci SD", "Pusta karta pamięci o pojemności 8GB. Prędkości odczytu do 80 MB/s. Magistrala UHS-I. Odporna na działanie czynników zewnętrznych.", 22 ) );
            items.Add( "raspberry_pi_with_rootkit",  new Item( "Raspberry Pi", "Raspberry Pi zainfekowane rootkit'em.", 81 ) );
            items.Add( "picklock", new Item( "Wytrych", "Pęk blaszek i pręcików o różnych formach z dołaczonym napinaczem L-kształtnym.", 12 ) );
            items.Add( "fsociety", new Item( "Karteczka", "Stara wizytówka z lunaparku.. ktoś wydrapał z niej kilka liter, zostało tylko \"fsociety\".", 0 ) );
        }

        public static ItemsRepository GetInstance() {
            if ( instance == null ) {
                instance = new ItemsRepository();
            }
            return instance;
        }

        public Item GetItem( string slug ) {
            Item item;
            items.TryGetValue( slug, out item );
            return item;
        }
    }
}
