using System;
using System.Collections.Generic;

namespace Game {
    public class Equipment {
        private List<Item> items;

        public static int Size = 10;

        public Equipment() {
            items = new List<Item>();
        }

        public bool AddItem( Item item ) {
            if ( items.Count < 10  ) {
                items.Add( item );

                return true;
            }

            return false;
        }

        public bool ContainsItem( Item item ) {
            return items.Contains( item );
        }

        public bool RemoveItem( Item item ) {
            return items.Remove( item );
        }

        public List<Item> GetItems() {
            return new List<Item>( items );
        }
    }
}