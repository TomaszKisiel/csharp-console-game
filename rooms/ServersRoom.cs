using System;
using System.Collections.Generic;

namespace RGame {
    [Serializable]
    class ServersRoom : Room {
        public override string RoomName { get => "Serwerownia Steel Mountain"; }

        public override Dictionary<Point, Interactable> Interactables {
            get => new Dictionary<Point, Interactable>() {

            };
        }

        public override string[] MapLayer {
            get => new string[] {

            };
        }

        public override string[] ColorsLayer {
            get => new string[] {

            };
        }

        public override string[] CollisionsLayer {
            get => new string[] {

            };
        }

    }
}