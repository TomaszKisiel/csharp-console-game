using System;
using System.Collections.Generic;

namespace Game {
    public class ItemRepository {

        private static ItemRepository instance = null;
        private Dictionary<string, Item> items = new Dictionary<string, Item>();

        private ItemRepository() {
            items.Add( "raspberry_pi_without_sd_card", new Item( "Raspberry Pi", "Miniaturowy komputer wielkości karty kredytowej.. brakuje w nim jedynie karty z systemem operacyjnym.", 59 ) );
            items.Add( "blank_sd_card", new Item( "Karta pamięci SD", "Pusta karta pamięci o pojemności 8GB. Prędkości odczytu do 80 MB/s. Magistrala UHS-I. Odporna na działanie czynników zewnętrznych.", 22 ) );
            items.Add( "raspberry_pi_with_rootkit",  new Item( "Raspberry Pi", "Raspberry Pi zainfekowane rootkit'em.", 81 ) );
            items.Add( "picklock", new Item( "Wytrych", "Pęk blaszek i pręcików o różnych formach z dołaczonym napinaczem L-kształtnym.", 12 ) );
        }

        public static ItemRepository GetInstance() {
            if ( instance == null ) {
                instance = new ItemRepository();
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
