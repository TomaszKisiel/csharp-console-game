using System;

namespace RGame {
    [Serializable]
    class EliotHouseRoom : Room {
        public override string RoomName { get => "Pokój Eliota"; }

//        protected override Interactable[] Interactables() {
//            return new Interactable[] {};
//        }

        public override string[] MapLayer {
            get => new string[] {
                "=======================",
                "=                     =",
                "=                     =",
                "=                     =",
                "=                     =",
                "=                     =",
                "=                     =",
                "======================="
            };
        }

        public override string[] ColorsLayer {
            get => new string[] {
                "=======================",
                "=                     =",
                "=                     =",
                "=                     =",
                "=                     =",
                "=                     =",
                "=                     =",
                "======================="
            };
        }

        public override string[] CollisionsLayer {
            get => new string[] {
                "=======================",
                "=                     =",
                "=                     =",
                "=                     =",
                "=                     =",
                "=                     =",
                "=                     =",
                "======================="
            };
        }

    }
}