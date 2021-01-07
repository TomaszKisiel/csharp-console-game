using System;
using System.Collections.Generic;

namespace RGame {
    [Serializable]
    class OpenSpaceRoom : Room {
        public override string RoomName { get => "Open Space Steel Mountain"; }

        public override Dictionary<Point, Interactable> Interactables {
            get => new Dictionary<Point, Interactable>() {
                { new Point( 0, 10 ), new Door( "corridor_iii", new Point( 45, 14 )  ) },
                { new Point( 0, 11 ), new Door( "corridor_iii", new Point( 46, 14 )  ) },
                { new Point( 37, 4 ), new Door( "corridor_iv", new Point( 21, 2 )  ) },
                { new Point( 37, 5 ), new Door( "corridor_iv", new Point( 21, 3 )  ) },
                { new Point( 22, 11 ), InteractablesRepository.Instance().Get( "password_note" )  },
            };
        }

        public override string[] MapLayer {
            get => new string[] {
                @"╔════════════════════════════════════╗",
                @"║   [█████]    [██████]    [█████]   ║",
                @"║   [█████]    [██████]    [█████]   ║",
                @"║   *                                ║",
                @"║   ╬       ⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙     ]",
                @"║  o╬═      ⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙     ]",
                @"║ ══╬o═     ⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙     ║",
                @"║  o╬═                               ║",
                @"║ ══╬o═       [⋤⋥_][⋤⋥_]   [⋤⋥_][⋤⋥_]║",
                @"║   ║         ⋟⋞            ⋟⋞   ⋟⋞  ║",
                @"[                                    ║",
                @"[             [⋤⋥_][⋤⋥⍰]   [⋤⋥_][⋤⋥_]║",
                @"║                   ⋟⋞     ⋟⋞     ⋟⋞ ║",
                @"║                                    ║",
                @"║[⋤⋥_][⋤⋥_]   [⋤⋥_][⋤⋥_]   [⋤⋥_][⋤⋥_]║",
                @"║⋟⋞           ⋟⋞    ⋟⋞     ⋟⋞        ║",
                @"╚════════════════════════════════════╝",
            };
        }

        public override string[] ColorsLayer {
            get => new string[] {
                @"╔════════════════════════════════════╗",
                @"║   Y█████Y    Y██████Y    Y█████Y   ║",
                @"║   Y█████Y    Y██████Y    Y█████Y   ║",
                @"║   R                                ║",
                @"║   C       BRBRBRBRBRBRBRBRBRBR     M",
                @"║  GCC      RBRBRBRBRBRBRBRBRBRB     M",
                @"║ CCCMC     BRBRBRBRBRBRBRBRBRBR     ║",
                @"║  BCC                               ║",
                @"║ CCCRC       YBBYYYMMYY   YMMYYYBBYY║",
                @"║   Y         BB            BB   BB  ║",
                @"M                                    ║",
                @"M             YMMYYYBBWY   YBBYYYBBYY║",
                @"║                   BB     BB     BB ║",
                @"║                                    ║",
                @"║YBBYYYMMYY   YBBYYYBBYY   YBBYYYMMYY║",
                @"║BB           BB    BB     BB        ║",
                @"╚════════════════════════════════════╝",
            };
        }

        public override string[] CollisionsLayer {
            get => new string[] {
                @"######################################",
                @"#    #####      ######      #####    #",
                @"#    #####      ######      #####    #",
                @"#   @                                #",
                @"#   @       ⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙      ",
                @"#  @@@      ⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙      ",
                @"# @@@@@     ⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙     #",
                @"#  @@@                               #",
                @"# @@@@@       ##########   ###########",
                @"#   #                                #",
                @"                                     #",
                @"              ##########   ###########",
                @"#                                    #",
                @"#                                    #",
                @"###########   ##########   ###########",
                @"#                                    #",
                @"######################################",
            };
        }

    }
}
