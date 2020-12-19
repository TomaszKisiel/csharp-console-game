using System;
using System.Collections.Generic;

namespace RGame {
    [Serializable]
    class CorridorIIIRoom : Room {
        public override string RoomName { get => "Korytarz Steel Mountain"; }

        public override Dictionary<Point, Interactable> Interactables {
            get => new Dictionary<Point, Interactable>() {
                { new Point( 8, 14 ), new Door( "corridor_i", new Point( 0, 2 ) ) },
                { new Point( 9, 14 ), new Door( "corridor_i", new Point( 0, 3 ) ) },
                { new Point( 57, 6 ), new Door( "corridor_ii", new Point( 0, 10 ) ) },
                { new Point( 57, 7 ), new Door( "corridor_ii", new Point( 0, 11 ) ) },
            };
        }

        public override string[] MapLayer {
            get => new string[] {        /* sv */
                @"╔═════════════════════════__═════════════════════════════╗",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ]", //2
                @"║                                                        ]",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"╚═══════__═══════════════════════════════════__══════════╝",
            };         /* 1 */                              /* os */
        }

        public override string[] ColorsLayer {
            get => new string[] {
                @"╔═════════════════════════__═════════════════════════════╗",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ]",
                @"║                                                        ]",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"╚═══════__═══════════════════════════════════════════════╝",
            };
        }

        public override string[] CollisionsLayer {
            get => new string[] {
                @"╔═════════════════════════__═════════════════════════════╗",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ]",
                @"║                                                        ]",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"╚═══════__═══════════════════════════════════════════════╝",
            };
        }

    }
}