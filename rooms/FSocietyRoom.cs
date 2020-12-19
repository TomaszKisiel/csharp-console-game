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
                @"║/@-@\     [≣]                     ⍃⌼⍄      [⋤⋥_]   /@-@\║",
                @"║\-@-/             [⋤⋥_][⋤⋥_]                ⋟⋞     \-@-/║",
                @"║                        ⋟⋞                              ║",
                @"║    [██████]                                        [≣] ║",
                @"║    [██████]                 ⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙                 ║",
                @"║                          ⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙           [≣]║",
                @"║                         ⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙         [≣] ║",
                @"║                         ⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙          [≣]║",
                @"║        [⋤⋥_][⋤⋥_]⊌       ⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙           [≣]║",
                @"║       ⋟⋞     ⋟⋞             ⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙                 ║",
                @"║                                                        ║",
                @"║/@-@\                                              /@-@\║",
                @"║\-@-/      ]⌹⌺⌻⍔⌼⍍⌸⍓⍰⍠⍄[                           \-@-/║",
                @"╚════════════════════════════════UU══════════════════════╝",
            };
        }

        public override string[] ColorsLayer {
            get => new string[] {
                @"╔════════════════════════════════════════════════════════╗",
                @"║YBYBY     MMM                     YYY      YBBYY   YBYBY║",
                @"║YYBYY             YMMYYYBBYY                CC     YYBYY║",
                @"║                        CC                              ║",
                @"║    C██████C                                        YYY ║",
                @"║    C██████C                 RRRRRRRRRR                 ║",
                @"║                          RRRBBBBBBBBBBRRR           MMM║",
                @"║                         RBBBBBBCCCCBBBBBBR         BBB ║",
                @"║                         RBBBBBBCCCCBBBBBBR          BBB║",
                @"║        YBBYYYMMYYC       RRRBBBBBBBBBBRRR           YYY║",
                @"║       CC     CC             RRRRRRRRRR                 ║",
                @"║                                                        ║",
                @"║YBYBY                                              YBYBY║",
                @"║YYBYY      YC⌺⌻B⌼⍍R⍓G⍠⍄Y                           YYBYY║",
                @"╚════════════════════════════════MM══════════════════════╝",
            };
        }

        public override string[] CollisionsLayer {
            get => new string[] {
                @"##########################################################",
                @"######     ###                     ###      #####   ######",
                @"######             ##########                ⋟⋞     ######",
                @"#                        ⋟⋞                              #",
                @"#    [######]                                        ### #",
                @"#    [######]                 ⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙                 #",
                @"#                          ⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙           ####",
                @"#                         ⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙         ### #",
                @"#                         ⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙          ####",
                @"#        ###########       ⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙           ####",
                @"#       ⋟⋞     ⋟⋞             ⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙                 #",
                @"#                                                        #",
                @"######                                              ######",
                @"######      #############                           ######",
                @"#################################  #######################",
            };
        }

    }
}