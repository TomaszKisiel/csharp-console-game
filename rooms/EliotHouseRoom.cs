using System;
using System.Collections.Generic;

namespace RGame {
    [Serializable]
    class EliotHouseRoom : Room {
        public override string RoomName { get => "Pokój Eliota"; }

        public override Dictionary<Point, Interactable> Interactables {
            get => new Dictionary<Point, Interactable>() {
                { new Point( 43, 10 ), new Door( "housing_estate", new Point( 12, 6 ) ) },
                { new Point( 43, 11 ), new Door( "housing_estate", new Point( 13, 6 ) ) },
                { new Point( 13, 1 ), InteractablesRepository.Instance().Get("chest") },
                { new Point( 14, 1 ), InteractablesRepository.Instance().Get("chest") },
                { new Point( 15, 1 ), InteractablesRepository.Instance().Get("chest") },
                { new Point( 39, 13 ), InteractablesRepository.Instance().Get("sd_card_holder") },
                { new Point( 26, 1 ), InteractablesRepository.Instance().Get("eliot_pc") },
                { new Point( 27, 1 ), InteractablesRepository.Instance().Get("eliot_pc") },
                { new Point( 28, 1 ), InteractablesRepository.Instance().Get("eliot_pc") },
            };
        }

        public override string[] MapLayer {
            get => new string[] {
                @"╔═════----══════╦══════════════════════════╗",
                @"║            [≣]║        [⋤⋥_]         *   ║",
                @"|  ⁙⁙⁙⁙⁙⁙⁙      ║        ⋟⋞            ╬   ║",
                @"|  ⁙⁙⁙⁙⁙⁙⁙      ║                     o╬═  ║",
                @"|  ⁙⁙⁙⁙⁙⁙⁙                           ══╬o═ ║",
                @"║  ⁙⁙⁙⁙⁙⁙⁙             ⁙⁙⁙⁙⁙⁙⁙        ═╬═  ║",
                @"║               ║      ⁙⁙⁙⁙⁙⁙⁙       ═o╬══ ║",
                @"║|%██|          ║      ⁙⁙⁙⁙⁙⁙⁙         ║   ║",
                @"║|%██|      [☺o]║      ⁙⁙⁙⁙⁙⁙⁙             ║",
                @"╠═══════════════╝      ⁙⁙⁙⁙⁙⁙⁙             ║",
                @"║B                                         ]",
                @"║B   [█████]                               ]",
                @"║B   [█████]       /@--\                   ║",
                @"║B                 \-@-/           ]⊑⊑⊑⊑⊑⊑[║",
                @"╚══════════════════════════════════════════╝",
            };
        }

        public override string[] ColorsLayer {
            get => new string[] {
                @"      CCCC                                  ",
                @"             MMM         YMMMY         Y    ",
                @"C                                      C    ",
                @"C                                     MCC   ",
                @"C                                    CCCBC  ",
                @"                       BBBBBBB        CCC   ",
                @"                       BYYYYYB       CRCCC  ",
                @" YRBBY                 BYYYYYB         Y    ",
                @" YRBBY      BBBB       BYYYYYB              ",
                @"                       BBBBBBB              ",
                @" B                                         M",
                @" B                                         M",
                @" B                 YCBBY                    ",
                @" B                 YBCBY           WWWWMWWW ",
                @"                                            "
            };
        }

        public override string[] CollisionsLayer {
            get => new string[] {
                @"############################################",
                @"#            ####        #####         @   #",
                @"#               #        ##            @   #",
                @"#               #                     @@@  #",
                @"#                                    @@@@@ #",
                @"#                                     @@@  #",
                @"#               #                    @@@@@ #",
                @"##   #          #                      #   #",
                @"##   #      #####                          #",
                @"#################                          #",
                @"#                                           ",
                @"#     #####                                 ",
                @"#     #####        #####                   #",
                @"#                  #####           #########",
                @"############################################",
            };
        }

    }
}