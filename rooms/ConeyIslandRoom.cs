using System;
using System.Collections.Generic;

namespace RGame {
    [Serializable]
    class ConeyIslandRoom : Room {
        public override string RoomName { get => "Coney Island"; }

        public override Dictionary<Point, Interactable> Interactables {
            get => new Dictionary<Point, Interactable>() {
                { new Point( 45, 6 ), new Door( "fsociety", new Point( 33, 14 ) ) },
                { new Point( 46, 6 ), new Door( "fsociety", new Point( 34, 14 ) ) },
                { new Point( 32, 10 ), InteractablesRepository.Instance().Get("team_on_coney_island") },
                { new Point( 36, 11 ), InteractablesRepository.Instance().Get("team_on_coney_island") },
                { new Point( 33, 13 ), InteractablesRepository.Instance().Get("team_on_coney_island") },
                { new Point( 35, 13 ), InteractablesRepository.Instance().Get("team_on_coney_island") },
            };
        }

        // Podczas robienia tych mapek pierwszy raz doceniłem funkcje klawisza insert :3
        public override string[] MapLayer {
            get => new string[] {
                @"╔═══#══════╦═══════#═══════════════════════════════════════════════════════════════╗",
                @"║  #    `  ║  ~     #█  ~     `     ~    ~      `    ~       `  ⋚         ▟████████║",
                @"║ █#===+===[]===+===#     ~     ~    `  _____╽___ ~     `  ⋚-⋚-⋚   ⁙       █◡◡    ◚║",
                @"║ `#  ~   / ║\      #`  _____╽___   ~  ▟█████████▙    ⋚-⋚-⋚ ≽====≼         █▔▔▔▔▔▔▔║",
                @"║   #    /__║_\   `#█  ▟█████████▙    ▟███████████▙⋚-⋚                ⁙          ⁙ ║",
                @"║~  █###/   ║  \###   ▟███████████▙⋚-▟██▔▔███▔▔████▙ ≽====≼   ▟██████████████▙     ║",
                @"║ `    /#█####█#\  ` ▟██▔▔███▔▔████▙  ███████▁▁████       ⁙    █o` ⍕⍕      ⍙█  ⁙   ║",
                @"║⋚-⋚-⋚/\        /\⋚-⋚-███████▁▁████ ≽=====≼       ⁙           ⊌█▔▔▔▔▔▔▔▔▔▔▔▔█      ║",
                @"║   ▄   ⁙       ⁙ ●     ⊼               ⁙      ▄▄▄▄▄▄▄▄▄▄▄          ⁙    ⁙         ║",
                @"║⁙  │ ≽=====≼ ⊌   │   ⁙     ⁙                   ⋚       ⋚         _____╽________ ⁙ ║",
                @"║---┴------≍------┴----⎽⎽⁙    ● #  ⁙   _____    ⋚.......⋚  ⁙     ▟██████████████▙  ║",
                @"║                        ⎺⎺≍⎽ │     # /▜███▛\   ⋚≘≘≘⍐≘≘≘⋚       ▟████████████████▙ ║",
                @"║                            ⎺┴  ⁙    \o ~ o/                  ▟██████████████████▙║",
                @"║---------  ===  === .         \ # #   █-=-█  ⁙          ⁙  ⊌   ██████████████████ ║",
                @"╚═════════════════════╩════════════════════════════════════════════════════════════╝",
            };
        }

        public override string[] ColorsLayer {
            get => new string[] {
                @"╔═══W══════╦═══════W═══════════════════════════════════════════════════════════════╗",
                @"║  W    C  Y  C     WB  C     C     C    C      C    C       C  Y         BMBMBMBMB║",
                @"║ BWYYYRYYYBBYYYRYYYW     C     C    C  RRRRRYRRR C     C  YYYYY   W       YCC    R║",
                @"║ CW  C   R YR      WC  RRRRRYRRR   C  RRRRRRRRRRR    YYYYY YYYYYY         YYYYYYYY║",
                @"║   W    RRRYRR   CWB  RRRRRRRRRRR    RRRRRRRRRRRRRYYY                W          W ║",
                @"║C  BWWWR   Y  RWWW   RRRRRRRRRRRRRYYRCWWWWWWWWWWWCR YYYYYY   MCMCMCMCMCMCMCMC     ║",
                @"║ C    RWBWWWWBWR  C RCWWWWWWWWWWWCR  CBCBCBCMMBCBC       W    YRB BB      RY  W   ║",
                @"║YYYYYRR        RRYYYYCBCBCBC▁▁BCBC YYYYYYY       W           CYYYYYYYYYYYYYY      ║",
                @"║   M   W       W B     W               W      BRBRBRBRBRB          W    W         ║",
                @"║W  Y YYYYYYY C   Y   W     W                   Y       Y         CCCCCYCCCCCCCC W ║",
                @"║WWWYWWWWWW≍WWWWWWYWWWWWWW    B M  W   RRRRR    YWWWWWWWY  W     CCCCCCCCCCCCCCCC  ║",
                @"║                        WWWW Y     M RBBBBBR   YCMCWCMCY       CCCCCCCCCCCCCCCCCC ║",
                @"║                            WY  W    RY W YR                  CWRWRWRWRWRWRWRWRWRC║",
                @"║WWWWWWWWW  WWW  WWW W         W M M   BCCCB  W          W  C   RWRWRWRWRWRWRWRWRW ║",
                @"╚═════════════════════╩════════════════════════════════════════════════════════════╝",
            };
        }

        public override string[] CollisionsLayer {
            get => new string[] {
                @"####################################################################################",
                @"#################################################################         ##########",
                @"################################################################           #########",
                @"###########################################################                #       #",
                @"######################################################                             #",
                @"####################################################          ################     #",
                @"####################################  #######  ####            ##############      #",
                @"########        #############  ####                           ##            #      #",
                @"#   @             @     #                      ###########                         #",
                @"#   @         #   @                             #       #              @           #",
                @"#                             @ #               #       #        ################  #",
                @"#                             @     # @@@@@@@   #### ####       ################## #",
                @"#                                     @@@@@@@                  #####################",
                @"#                                # #   #####                #   ################## #",
                @"####################################################################################",
            };
        }

    }
}
