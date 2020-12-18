using System;
using System.Collections.Generic;

namespace RGame {
    [Serializable]
    public class Equipment {
        private List<Item> items = new List<Item>();

        public const int SIZE = 10;

        public bool Add( Item item ) {
            if ( items.Count < SIZE  ) {
                items.Add( item );
                return true;
            }

            return false;
        }

        public bool Contains( Item item ) {
            return items.Contains( item );
        }

        public bool Remove( Item item ) {
            return items.Remove( item );
        }

        public List<Item> GetItems() {
            return new List<Item>( items );
        }
    }
}