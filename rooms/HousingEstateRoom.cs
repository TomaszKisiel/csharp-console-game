using System;
using System.Collections.Generic;

namespace RGame {
    [Serializable]
    class HousingEstateRoom : Room {
        public override string RoomName { get => "Osiedle"; }

        public override Dictionary<Point, Interactable> Interactables {
            get => new Dictionary<Point, Interactable>() {
                { new Point( 12, 6 ), new Door( "eliot_house", new Point( 43, 10 ) ) },
                { new Point( 13, 6 ), new Door( "eliot_house", new Point( 43, 11 ) ) },
                { new Point( 57, 7 ), InteractablesRepository.Instance().Get("bus_stop") },
                { new Point( 57, 8 ), InteractablesRepository.Instance().Get("bus_stop") },
                { new Point( 57, 9 ), InteractablesRepository.Instance().Get("bus_stop") },
                { new Point( 67, 8 ), InteractablesRepository.Instance().Get("trash_can") },
            };
        }

        public override string[] MapLayer {
            get => new string[] {
                @"╔═══════════════════════════════════════════════════════════════════════╗",
                @"║███▁████▁██████▁████▁███‿███▁████▁████▁██████▁████▁███ ███▁████▁██████▁║",
                @"║████████████████████████ █████████████████████████████‿████████████████║",
                @"║███▁████▁██████▁████▁███ ███▁████▁████▁██████▁████▁███ ███▁████▁██████▁║",
                @"║████████████████████████‿█████████████████████████████ ████████████████║",
                @"║███▁████▁██  ██▁████▁███ ███▁████▁████▁██  ██▁████▁███ ███▁████▁██  ██▁║",
                @"║███████████▁▁███████████⁑████████████████▁▁███████████⁑███████████▁▁███║",
                @"║   ⁙    ●  ⁙   ⁙      ⁙     ⁙   ●  ⁙        ⁙      ●    ▄   ⁙       ⁙ ●║",
                @"║ ⁙   ⁙  │⁙        ⁙      ⁙      │        ⁙    ⁙    │ ⁙  │ ≽=====≼ ⊌   │║",
                @"║---≍----┴------------------≍----┴----------≍-------┴----┴------≍------┴║",
                @"║             =======                                                   ║",
                @"║             =======                                                   ║",
                @"║===  ===  == ======= ==  ===  ===  ===  -------------------------  === ║",
                @"╚═══════════════════════════════════════════════════════════════════════╝",
            };
        }

        public override string[] ColorsLayer {
            get => new string[] {
                @"╔═══════════════════════════════════════════════════════════════════════╗",
                @"║R██B████B█R██R█B████B██RCC██B████B████B██CC██B████B██C R██B████B██RR██B║",
                @"║R█████████R██R█████████R █████████████████████████████C████████████████║",
                @"║R██B████B█R██R█B████B██R C██B████B████B██CC██B████B██C R██B████B██RR██B║",
                @"║R█████████R██R█████████RC█████████████████████████████  ███████████████║",
                @"║R██B████B█R  R█B████B██R C██B████B████B██  ██B████B██C R██B████B██  ██B║",
                @"║RRRRRRRRRRRMMRRRRRRRRRRRYCCCCCCCCCCCCCCCC  CCCCCCCCCCCYRRRRRRRRRRR  RRR║",
                @"║        B                       B                  B    M             B║",
                @"║        Y                       Y                  Y    M YYYYYYY M   Y║",
                @"║        Y                       Y                  Y    M             Y║",
                @"║                                                                       ║",
                @"║                                                                       ║",
                @"║                                                                       ║",
                @"╚═══════════════════════════════════════════════════════════════════════╝",
            };
        }

        public override string[] CollisionsLayer {
            get => new string[] {
                @"#########################################################################",
                @"#########################################################################",
                @"#########################################################################",
                @"#########################################################################",
                @"#########################################################################",
                @"#########################################################################",
                @"############  ############################  #######################  ####",
                @"#        @                       @                  @    @             @#",
                @"#        @                       @                  @    @         #   @#",
                @"#                                                                       #",
                @"#                                                                       #",
                @"#                                                                       #",
                @"#                                                                       #",
                @"#########################################################################",
            };
        }

    }
}