using System;

namespace RGame {
    [Serializable]
    public class Item {
        private int price;

        public string Name { get; }
        public string Description { get; }
        public int Price {
            get {
                return this.price;
            }
            set {
                if ( value >= 0 ) {
                    this.price = value;
                } else {
                    throw new ArgumentOutOfRangeException( "price" , "Price must be greater than or equal to zero." );
                }
            }
        }

        public Item( string name, string desc, int price ) {
            Name = name;
            Description = desc;
            Price = price;
        }
    }
}