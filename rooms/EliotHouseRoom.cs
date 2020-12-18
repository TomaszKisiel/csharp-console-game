using System;

namespace RGame {
    class EliotHouseRoom : Room {
        protected override string RoomName { get => "Pokój Eliota"; }

//        protected override Interactable[] Interactables() {
//            return new Interactable[] {};
//        }

        protected override string[] MapLayer {
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

        protected override string[] ColorsLayer {
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

        protected override string[] CollisionsLayer {
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