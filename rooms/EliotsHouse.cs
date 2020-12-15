using System;

namespace Game {
    class EliotsHouse : IRoom {
        private string[] mapLayer = {
           "╔═════----══════╦══════════════════════════╗",
           "║               ║       #[@__]          [=]║",
           "|               ║                          ║",
           "|               ║                          ║",
           "|                                          ║",
           "║                                          ║",
           "║               ║          *               ║",
           "║|%██|          ║          ╬               ║",
           "║|%██|          ║         o╬═              ║",
           "╠═══════════════╝        ══╬o═             ║",
           "║B                        ═╬═              ]",
           "║B                       ═o╬══             ]",
           "║B                         ║               ║",
           "║B                                         ║",
           "╚══════════════════════════════════════════╝",
        };

        private string[] colorsLayer  = {
            "      CCCC                                  ",
            "                        MMMMMM          MMM ",
            "C                                           ",
            "C                                           ",
            "C                                           ",
            "                                            ",
            "                           Y                ",
            " YRBBY                     C                ",
            " YRBBY                    MCC               ",
            "                         CCCBC              ",
            " B                        CCC              M",
            " B                       CRCCC             M",
            " B                         Y                ",
            " B                                          ",
            "                                            "
        };

        private string[] collisionsLayer = {
            "############################################",
            "#               #       ######          ####",
            "#               #                          #",
            "#               #                          #",
            "#                                          #",
            "#                                          #",
            "#               #          @               #",
            "##   #          #          @               #",
            "##   #          #         @@@              #",
            "#################        @@@@@             #",
            "#                         @@@               ",
            "#                        @@@@@              ",
            "#                          #               #",
            "#                                          #",
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

    }
}
