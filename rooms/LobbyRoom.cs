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
                { new Point( 40, 6 ), InteractablesRepository.Instance().Get("assistant") },
                { new Point( 49, 6 ), InteractablesRepository.Instance().Get("assistant") },
                { new Point( 47, 3 ), InteractablesRepository.Instance().Get("bill") },
                { new Point( 11, 7 ), InteractablesRepository.Instance().Get("lobby_backdoor") },
                { new Point( 12, 7 ), InteractablesRepository.Instance().Get("lobby_backdoor") },
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
                @"╠══════════UU════════╗          ║[⋤⋥_]              [⋤⋥_]║",
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
                @"╔═══════════════════════════════════════════Y══MM══Y═════╗",
                @"║B   BBBBBBBBBBBBBB                         Y      Y     ║",
                @"║B                        RR                YYYBBYYY     ║",
                @"║B     BBBBBBBBBB         RR                   M         ║",
                @"║B     BCCCCCCCCB         RR          BB                 ║",
                @"║B     BBBBBBBBBB         RR    ╔═══╗________________╔═══╣",
                @"║B                        RR    ╠═══╝   M        M   ╚═══╣",
                @"╠══════════MM════════╗          ║YMMYY              YMMYY║",
                @"║╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳║    RR    ║ BB                  M  ║",
                @"║╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳║    RR    ║Y⊑⊑M⊑⊑⊑B⊑Y    Y⊑R⊑⊑G⊑⊑⊑Y║",
                @"║╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳║    RR    ║                        ║",
                @"║╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳║    RR    ║Y⊑⊑⊑⊑⊑C⊑⊑Y    Y⊑⊑⊑⊑B⊑⊑⊑Y║",
                @"║╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳║    RR    ║   M                    ║",
                @"║╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳╳║          ║Y⊑B⊑⊑⊑C⊑⊑Y    Y⊑B⊑⊑⊑M⊑⊑Y║",
                @"╚════════════════════╩════MM════╩════════════════════════╝",
            };
        }

        public override string[] CollisionsLayer {
            get => new string[] {
                @"###############################################  #########",
                @"#B   ⋟============⋞                         #      #     #",
                @"#B                        ⁙⁙                ########     #",
                @"#B     ⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙         ⁙⁙                   #         #",
                @"#B     ⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙         ⁙⁙          ⋟⋞                 #",
                @"#B     ⁙⁙⁙⁙⁙⁙⁙⁙⁙⁙         ⁙⁙    #####________________#####",
                @"#B                        ⁙⁙    ##########################",
                @"###########  #########          ##########################",
                @"######################    ⁙⁙    ##########################",
                @"######################    ⁙⁙    ##########################",
                @"######################    ⁙⁙    ##########################",
                @"######################    ⁙⁙    ##########################",
                @"######################    ⁙⁙    ##########################",
                @"######################          ##########################",
                @"##########################  ##############################",
            };
        }

    }
}
