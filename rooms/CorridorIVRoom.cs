using System;
using System.Collections.Generic;

namespace RGame {
    [Serializable]
    class CorridorIVRoom : Room {
        public override string RoomName { get => "Korytarz Steel Mountain"; }

        public override Dictionary<Point, Interactable> Interactables {
            get => new Dictionary<Point, Interactable>() {
                { new Point( 0, 10 ), new Door( "corridor_ii", new Point( 45, 10 ) ) },
                { new Point( 0, 11 ), new Door( "corridor_ii", new Point( 45, 11 ) ) },
            };
        }

        public override string[] MapLayer {
            get => new string[] {
                @"╔════════════════════════════════════════════════════════╗",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"[                                                        ║",
                @"[                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"╚════════════════════════════════════════════════════════╝",
            };
        }

        public override string[] ColorsLayer {
            get => new string[] {
                @"╔════════════════════════════════════════════════════════╗",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"╚════════════════════════════════════════════════════════╝",
            };
        }

        public override string[] CollisionsLayer {
            get => new string[] {
                @"╔════════════════════════════════════════════════════════╗",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"╚════════════════════════════════════════════════════════╝",
            };
        }

    }
}