using System;
using System.Collections.Generic;

namespace RGame {
    [Serializable]
    class FSocietyRoom : Room {
        public override string RoomName { get => "Kryjówka fsociety"; }

        public override Dictionary<Point, Interactable> Interactables {
            get => new Dictionary<Point, Interactable>() {
                { new Point( 33, 14 ), new Door( "coney_island", new Point( 45, 6 ) ) },
                { new Point( 34, 14 ), new Door( "coney_island", new Point( 46, 6 ) ) },
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