using System;
using System.Collections.Generic;

namespace RGame {
    [Serializable]
    class CorridorIIRoom : Room {
        public override string RoomName { get => "Korytarz Steel Mountain"; }

        public override Dictionary<Point, Interactable> Interactables {
            get => new Dictionary<Point, Interactable>() {
                { new Point( 22, 0 ), new Door( "corridor_i", new Point( 57, 7 ) ) },
                { new Point( 23, 0 ), new Door( "corridor_i", new Point( 57, 8 ) ) },
                { new Point( 0, 10 ), new Door( "corridor_iii", new Point( 57, 6 ) ) },
                { new Point( 0, 11 ), new Door( "corridor_iii", new Point( 57, 7 ) ) },
                { new Point( 45, 10 ), new Door( "corridor_iv", new Point( 0, 10 ) ) },
                { new Point( 45, 11 ), new Door( "corridor_iv", new Point( 0, 11 ) ) },
            };
        }

        public override string[] MapLayer {
            get => new string[] {    /* 1 */
                @"╔═════════════════════__═════════════════════╗",
                @"║                                            ║",
                @"║                                            ║",
                @"║                                            ║",
                @"║                                            ║",
                @"║                                            ║",
                @"║                                            ║",
                @"║                                            ║",
                @"║                                            ║",
                @"║                                            ║",
        /*3*/   @"[                                            ]", /*4*/
        /*3*/   @"[                                            ]", /*4*/
                @"║                                            ║",
                @"║                                            ║",
                @"╚════════════════════════════════════════════╝",
            };
        }

        public override string[] ColorsLayer {
            get => new string[] {
                @"╔════════════════════════════════════════════╗",
                @"║                                            ║",
                @"║                                            ║",
                @"║                                            ║",
                @"║                                            ║",
                @"║                                            ║",
                @"║                                            ║",
                @"║                                            ║",
                @"║                                            ║",
                @"║                                            ║",
                @"║                                            ║",
                @"║                                            ║",
                @"║                                            ║",
                @"║                                            ║",
                @"╚════════════════════════════════════════════╝",
            };
        }

        public override string[] CollisionsLayer {
            get => new string[] {
                @"╔════════════════════════════════════════════╗",
                @"║                                            ║",
                @"║                                            ║",
                @"║                                            ║",
                @"║                                            ║",
                @"║                                            ║",
                @"║                                            ║",
                @"║                                            ║",
                @"║                                            ║",
                @"║                                            ║",
                @"║                                            ║",
                @"║                                            ║",
                @"║                                            ║",
                @"║                                            ║",
                @"╚════════════════════════════════════════════╝",
            };
        }

    }
}