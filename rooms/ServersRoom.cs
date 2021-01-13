using System;
using System.Collections.Generic;

namespace RGame {
    [Serializable]
    class ServersRoom : Room {
        public override string RoomName { get => "Serwerownia Steel Mountain"; }

        public override Dictionary<Point, Interactable> Interactables {
            get => new Dictionary<Point, Interactable>() {
                { new Point( 27, 14 ), new Door( "corridor_iii", new Point( 26, 0 ) ) },
                { new Point( 28, 14 ), new Door( "corridor_iii", new Point( 27, 0 ) ) },
                { new Point( 27, 3 ), InteractablesRepository.Instance().Get("server_pc") }
            };
        }

        public override string[] MapLayer {
            get => new string[] {
                @"╔═════════════════════════════════════════════════════╗",
                @"║/-@-\ /-@-\ /@--\ /--@\ [===] /--@\ /@--\ /---\ /@-@\║",
                @"║\@--/ \--@/ \---/ \@--/ [=⍯=] \-@-/ \--@/ \-@-/ \-@-/║",
                @"║                                                     ║",
                @"║                                                     ║",
                @"║                                                     ║",
                @"║   ]⌹⌺⌻⍔⌼⍍⌸⍓⍰⍠⍄[    ]⌹⌺⌻⍔⌼⍍⌸⍓⍰⍠⍄[    ]⌹⌺⌻⍔⌼⍍⌸⍓⍰⍠⍄[   ║",
                @"║                                                     ║",
                @"║                                                     ║",
                @"║   ]⌹⌺⌻⍔⌼⍍⌸⍓⍰⍠⍄[    ]⌹⌺⌻⍔⌼⍍⌸⍓⍰⍠⍄[    ]⌹⌺⌻⍔⌼⍍⌸⍓⍰⍠⍄[   ║",
                @"║                                                     ║",
                @"║                                                     ║",
                @"║   ]⌹⌺⌻⍔⌼⍍⌸⍓⍰⍠⍄[    ]⌹⌺⌻⍔⌼⍍⌸⍓⍰⍠⍄[    ]⌹⌺⌻⍔⌼⍍⌸⍓⍰⍠⍄[   ║",
                @"║                                                     ║",
                @"╚══════════════════════════UU═════════════════════════╝",
            };
        }

        public override string[] ColorsLayer {
            get => new string[] {
                @"╔═════════════════════════════════════════════════════╗",
                @"║YYBYY YYBYY YBYYY YYYBY YBBBY YYYBY YBYYY YYYYY YBYBY║",
                @"║YBYYY YYYBY YYYYY YBYYY YBMBY YYBYY YYYBY YYBYY YYBYY║",
                @"║                                                     ║",
                @"║                                                     ║",
                @"║                                                     ║",
                @"║   Y⌹⌺R⍔⌼G⌸CB⍠⍄Y    Y⌹M⌻⍔R⍍CB⍰G⍄Y    Y⌹YB⍔⌼C⌸⍓M⍠⍄Y   ║",
                @"║                                                     ║",
                @"║                                                     ║",
                @"║   Y⌹G⌻⍔M⍍B⍓C⍠⍄Y    YC⌺⌻B⌼⍍R⍓G⍠⍄Y    YR⌺R⍔G⍍⌸⍓BR⍄Y   ║",
                @"║                                                     ║",
                @"║                                                     ║",
                @"║   Y⌹⌺G⍔R⍍⌸⍓C⍠⍄Y    Y⌹B⌻⍔Y⍍⌸MG⍠⍄Y    Y⌹⌺G⍔⌼R⌸GB⍠⍄Y   ║",
                @"║                                                     ║",
                @"╚══════════════════════════MM═════════════════════════╝",
            };
        }

        public override string[] CollisionsLayer {
            get => new string[] {
                @"#######################################################",
                @"###### ##### ##### ##### ##### ##### ##### ##### ######",
                @"###### ##### ##### ##### ##### ##### ##### ##### ######",
                @"#                                                     #",
                @"#                                                     #",
                @"#                                                     #",
                @"#   #############    #############    #############   #",
                @"#                                                     #",
                @"#                                                     #",
                @"#   #############    #############    #############   #",
                @"#                                                     #",
                @"#                                                     #",
                @"#   #############    #############    #############   #",
                @"#                                                     #",
                @"###########################  ##########################",
            };
        }

    }
}
