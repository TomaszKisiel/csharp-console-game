using System;
using System.Collections.Generic;

namespace RGame {
    [Serializable]
    class CorridorIRoom : Room {
        public override string RoomName { get => "Korytarz Steel Mountain"; }

        public override Dictionary<Point, Interactable> Interactables {
            get => new Dictionary<Point, Interactable>() {
                { new Point( 0, 11 ), new Door( "lobby", new Point( 47, 0 ) ) },
                { new Point( 0, 12 ), new Door( "lobby", new Point( 48, 0 ) ) },
                { new Point( 57, 7 ), new Door( "corridor_ii", new Point( 22, 0 ) ) },
                { new Point( 57, 8 ), new Door( "corridor_ii", new Point( 23, 0 ) ) },
                { new Point( 0, 2 ), new Door( "corridor_iii", new Point( 8, 14 ) ) },
                { new Point( 0, 3 ), new Door( "corridor_iii", new Point( 9, 14 ) ) },
            };
        }

        public override string[] MapLayer {
            get => new string[] {
                @"╔════════════════════════════════════════════════════════╗",
                @"║                                                        ║",
        /*3*/   @"[                                                        ║",
        /*3*/   @"[                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ]", /*2*/
                @"║                                                        ]", /*2*/
                @"║                                                        ║",
                @"║                                                        ║",
                @"[                                                        ║",
        /*wr*/  @"[                                                        ║",
                @"║                                                        ║",
                @"╚════════════════════════════════════════════════════════╝",
            };
        }

        public override string[] ColorsLayer {
            get => new string[] {
                @"╔════════════════════════════════════════════════════════╗",
                @"║                                                        ║",
        /*3*/   @"[                                                        ║",
        /*3*/   @"[                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ]", /*2*/
                @"║                                                        ]", /*2*/
                @"║                                                        ║",
                @"║                                                        ║",
                @"[                                                        ║",
        /*wr*/  @"[                                                        ║",
                @"║                                                        ║",
                @"╚════════════════════════════════════════════════════════╝",
            };
        }

        public override string[] CollisionsLayer {
            get => new string[] {
                @"╔════════════════════════════════════════════════════════╗",
                @"║                                                        ║",
        /*3*/   @"[                                                        ║",
        /*3*/   @"[                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ║",
                @"║                                                        ]", /*2*/
                @"║                                                        ]", /*2*/
                @"║                                                        ║",
                @"║                                                        ║",
                @"[                                                        ║",
        /*wr*/  @"[                                                        ║",
                @"║                                                        ║",
                @"╚════════════════════════════════════════════════════════╝",
            };
        }

    }
}