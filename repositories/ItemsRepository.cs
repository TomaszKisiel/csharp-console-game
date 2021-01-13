using System;
using System.Collections.Generic;

namespace RGame {
    public class ItemsRepository {

        private static ItemsRepository instance = null;
        private Dictionary<string, Item> repo = new Dictionary<string, Item>();

        private ItemsRepository() {
            repo.Add( "raspberry_pi_blank", new Item( "Raspberry Pi", "Miniaturowy komputer wielkości karty kredytowej.. brakuje w nim jedynie karty z systemem operacyjnym.", 59 ) );
            repo.Add( "raspberry_pi_rootkit",  new Item( "Zainfekowane Raspberry Pi", "Raspberry Pi zainfekowane rootkit'em.", 81 ) );
            repo.Add( "sd_card", new Item( "Karta pamięci SD", "Pusta karta pamięci o pojemności 8GB. Prędkości odczytu do 80 MB/s. Magistrala UHS-I. Odporna na działanie czynników zewnętrznych.", 22 ) );
            repo.Add( "picklock", new Item( "Wytrych", "Pęk blaszek i pręcików o różnych formach z dołaczonym napinaczem L-kształtnym.", 12 ) );
            repo.Add( "fsociety", new Item( "Karteczka", "Stara wizytówka z lunaparku.. ktoś wydrapał z niej kilka liter, zostało tylko \"fsociety\".", 0 ) );
            repo.Add( "rubber_duck", new Item( "Kaczuszka", "Niezwykle skuteczne narzędzie hackerskie, którego może użyć nawet niedoświadczona osoba. Skuteczność w 60% przypadkach.", 12 ) );
            repo.Add( "magnetic_card", new Item( "Karta magnetyczna", "Karta Tyrella Wellicka, być może umożliwi dostanie się do zamkniętych pomieszczeń.", 3 ) );
        }

        public static ItemsRepository Instance() {
            if ( instance == null ) {
                instance = new ItemsRepository();
            }
            return instance;
        }

        public Item Get( string slug ) {
            Item item;
            if ( !repo.TryGetValue( slug, out item ) ) {
                throw new KeyNotFoundException();
            }

            return item;
        }
    }
}
