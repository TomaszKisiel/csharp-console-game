using System;
using System.Collections.Generic;

namespace RGame {
    [Serializable]
    public class Equipment {
        private List<Item> items = new List<Item>();

        public const int SIZE = 10;

        public bool AddBySlug( string slug ) {
            return Add( ItemsRepository.Instance().Get( slug ) );
        }

        public bool Add( Item item ) {
            if ( items.Count < SIZE  ) {
                items.Add( item );
                GameController.Instance().SetEquipmentMessage( "Zdobyto przedmiot " + Display.YELLOW + item.Name + Display.WHITE );

                return true;
            }
            GameController.Instance().SetEquipmentMessage( "Brak miejsca w ekwipunku!" );

            return false;
        }

        public bool ContainsBySlug( string slug ) {
            return Contains( ItemsRepository.Instance().Get( slug ) );
        }

        public bool Contains( Item item ) {
            return items.Contains( item );
        }

        public bool RemoveBySlug(  string slug ) {
            return Remove( ItemsRepository.Instance().Get( slug ) );
        }

        public bool Remove( Item item ) {
            return items.Remove( item );
        }

        public List<Item> GetItems() {
            return new List<Item>( items );
        }
    }
}