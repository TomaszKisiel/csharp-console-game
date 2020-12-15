using System;

namespace Game {
    public class Item {
        private int price;

        public string Name;
        public string Description;
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
            this.Name = name;
            this.Description = desc;
            this.Price = price;
        }
    }
}
