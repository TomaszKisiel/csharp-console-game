using System;

namespace Game {
    class ConeyIsland : IRoom {
        private Door[] doors = {

        };

        public ConeyIsland() {
            roomName = "Coney Island";

            interactables = new Interactable[] {

            };
        }

        // Podczas rysowania tych mapek pierwszy raz doceniłem klawisz Insert XD
        private string[] mapLayer = {
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

        private string[] colorsLayer  = {
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

        private string[] collisionsLayer = {
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
