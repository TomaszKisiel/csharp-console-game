using System;

namespace Game {
    class EliotsHouse : IRoom {
        private Door[] doors = {
            new Door( new Point( 43, 10 ), "housing_estate", new Point( 12, 6 ) ),
            new Door( new Point( 43, 11 ), "housing_estate", new Point( 13, 6 ) ),
        };

//        private Interactable[]

        public EliotsHouse() {
            roomName = "Pokój Eliota";

            interactables = new Interactable[] {
                new EliotsChest( new Point[] {
                    new Point( 13, 1 ),
                    new Point( 14, 1 ),
                    new Point( 15, 1 )
                }, true )
            };
        }

        private string[] mapLayer = {
           "╔═════----══════╦══════════════════════════╗",
           "║            [≣]║        [⋤⋥_]         *   ║",
           "|  ⁙⁙⁙⁙⁙⁙⁙      ║        ⋟⋞            ╬   ║",
           "|  ⁙⁙⁙⁙⁙⁙⁙      ║                     o╬═  ║",
           "|  ⁙⁙⁙⁙⁙⁙⁙                           ══╬o═ ║",
           "║  ⁙⁙⁙⁙⁙⁙⁙             ⁙⁙⁙⁙⁙⁙⁙        ═╬═  ║",
           "║               ║      ⁙⁙⁙⁙⁙⁙⁙       ═o╬══ ║",
           "║|%██|          ║      ⁙⁙⁙⁙⁙⁙⁙         ║   ║",
           "║|%██|      [☺o]║      ⁙⁙⁙⁙⁙⁙⁙             ║",
           "╠═══════════════╝      ⁙⁙⁙⁙⁙⁙⁙             ║",
           "║B                                         ]",
           "║B   [█████]                               ]",
          @"║B   [█████]       /@--\                   ║",
          @"║B                 \-@-/           ]⊑⊑⊑⊑⊑⊑[║",
           "╚══════════════════════════════════════════╝",
        };

        private string[] colorsLayer  = {
            "      CCCC                                  ",
            "             MMM         YMMMY         Y    ",
            "C                                      C    ",
            "C                                     MCC   ",
            "C                                    CCCBC  ",
            "                       BBBBBBB        CCC   ",
            "                       BYYYYYB       CRCCC  ",
            " YRBBY                 BYYYYYB         Y    ",
            " YRBBY      BBBB       BYYYYYB              ",
            "                       BBBBBBB              ",
            " B                                         M",
            " B                                         M",
            " B                 YCBBY                    ",
            " B                 YBCBY           WWWWMWWW ",
            "                                            "
        };

        private string[] collisionsLayer = {
            "############################################",
            "#            ####        #####         @   #",
            "#               #        ##            @   #",
            "#               #                     @@@  #",
            "#                                    @@@@@ #",
            "#                                     @@@  #",
            "#               #                    @@@@@ #",
            "##   #          #                      #   #",
            "##   #      #####                          #",
            "#################                          #",
            "#                                           ",
            "#     #####                                 ",
            "#     #####        #####                   #",
            "#                  #####           #########",
            "############################################",
        };

        protected override string[] MapLayer {
            get {
                return mapLayer;
            }
        }

        protected override string[] ColorsLayer {
            get {
                return colorsLayer;
            }
        }

        protected override string[] CollisionsLayer {
            get {
                return collisionsLayer;
            }
        }

        protected override Door[] Doors {
            get {
                return doors;
            }
        }

    }
}
