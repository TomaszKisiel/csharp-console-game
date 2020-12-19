using System;
using System.Collections.Generic;

namespace RGame {
    [Serializable]
    class OpenSpaceRoom : Room {
        public override string RoomName { get => "Open Space Steel Mountain"; }

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