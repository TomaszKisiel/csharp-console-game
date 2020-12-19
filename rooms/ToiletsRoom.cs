using System;
using System.Collections.Generic;

namespace RGame {
    [Serializable]
    class ToiletsRoom : Room {
        public override string RoomName { get => "Toaleta Steel Mountain"; }

        public override Dictionary<Point, Interactable> Interactables {
            get => new Dictionary<Point, Interactable>() {
                { new Point( 0, 7 ), new Door( "corridor_iv", new Point( 57, 6 ) ) },
                { new Point( 0, 8 ), new Door( "corridor_iv", new Point( 57, 7 ) ) },
            };
        }

        public override string[] MapLayer {
            get => new string[] {
                @"╔══════╦══════╦══════╦══════╦══════╗",
                @"║  ⋐⋑  ║  ⋐⋑  ║  ⋐⋑  ║  ⋐⋑  ║  ⋐⋑  ║",
                @"║      ║      ║      ║      ║      ║",
                @"║⊻    ⊻║⊻    ⊻║⊻    ⊻║⊻    ⊻║⊻    ⊻║",
                @"╠══  ══╩══  ══╩══  ══╩══  ══╩══  ══╣",
                @"║                                  ║",
                @"║                                  ║",
                @"[                                  ║",
                @"[                                  ⍯",
                @"║   ⊏o⊐  ⊏o⊐  ⊏o⊐  ⊏o⊐  ⊏o⊐  ⍋     ║",
                @"╚══════════════════════════════════╝",
            };
        }

        public override string[] ColorsLayer {
            get => new string[] {
                @"╔══════╦══════╦══════╦══════╦══════╗",
                @"║  BB  ║  BB  ║  BB  ║  BB  ║  BB  ║",
                @"║      ║      ║      ║      ║      ║",
                @"║Y    Y║Y    Y║Y    Y║Y    Y║Y    Y║",
                @"╠══  ══╩══  ══╩══  ══╩══  ══╩══  ══╣",
                @"║                                  ║",
                @"║                                  ║",
                @"M                                  ║",
                @"M                                  M",
                @"║   YBY  YBY  YBY  YBY  YBY  C     ║",
                @"╚══════════════════════════════════╝",
            };
        }

        public override string[] CollisionsLayer {
            get => new string[] {
                @"####################################",
                @"#  ##  #  ##  #  ##  #  ##  #  ##  #",
                @"#      #      #      #      #      #",
                @"##    ###    ###    ###    ###    ##",
                @"###  #####  #####  #####  #####  ###",
                @"#                                  #",
                @"#                                  #",
                @"                                   #",
                @"                                   #",
                @"#   ###  ###  ###  ###  ###  #     #",
                @"####################################",
            };
        }

    }
}