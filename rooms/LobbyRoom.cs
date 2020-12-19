using System;
using System.Collections.Generic;

namespace RGame {
    [Serializable]
    class LobbyRoom : Room {
        public override string RoomName { get => "Lobby Steel Mountain"; }

        public override Dictionary<Point, Interactable> Interactables {
            get => new Dictionary<Point, Interactable>() {
                { new Point( 47, 0 ), new Door( "corridor_i", new Point( 0, 11 ) ) },
                { new Point( 48, 0 ), new Door( "corridor_i", new Point( 0, 12 ) ) },
                { new Point( 26, 14), new Door( "parking", new Point( 26, 6 ) ) },
                { new Point( 27, 14), new Door( "parking", new Point( 27, 6 ) ) },
            };
        }

        public override string[] MapLayer {
            get => new string[] {
                @"╔═══════════════════════════════════════════⋚══∏∏══⋚═════╗",
                @"║B   ⋟============⋞                         ⋚      ⋚     ║",
                @"║B                        ⁙⁙                ⋚⋚⋚==⋚⋚⋚     ║",
                @"║B     ⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙         ⁙⁙                   #         ║",
                @"║B     ⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙         ⁙⁙          ⋟⋞                 ║",
                @"║B     ⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙         ⁙⁙    ╔═══╗________________╔═══╣",
                @"║B                        ⁙⁙    ╠═══╝   #        #   ╚═══╣",
                @"╠══════════--════════╗          ║[⋤⋥_]              [⋤⋥_]║",
                @"║╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳║    ⁙⁙    ║ ⋟⋞                  #  ║",
                @"║╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳║    ⁙⁙    ║]⊑⊑⊑⊑⊑⊑⊑⊑[    ]⊑⊑⊑⊑⊑⊑⊑⊑[║",
                @"║╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳║    ⁙⁙    ║                        ║",
                @"║╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳║    ⁙⁙    ║]⊑⊑⊑⊑⊑⊑⊑⊑[    ]⊑⊑⊑⊑⊑⊑⊑⊑[║",
                @"║╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳║    ⁙⁙    ║   #                    ║",
                @"║╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳║          ║]⊑⊑⊑⊑⊑⊑⊑⊑[    ]⊑⊑⊑⊑⊑⊑⊑⊑[║",
                @"╚════════════════════╩════UU════╩════════════════════════╝",
            };
        }

        public override string[] ColorsLayer {
            get => new string[] {
                @"╔══════════════════════════════════════════════MM════════╗",
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
                @"╚═════════════════════════MM═════════════════════════════╝",
            };
        }

        public override string[] CollisionsLayer {
            get => new string[] {
                @"╔══════════════════════════════════════════════__════════╗",
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
                @"╚═════════════════════════__═════════════════════════════╝",
            };
        }

    }
}