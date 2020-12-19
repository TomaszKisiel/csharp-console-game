using System;

namespace RGame {
    // [Serializable]
    public class MainQuest {
        public static void OnWakeUp() {
            GameController.Instance().SetQuestMessage( "Znajdź Raspberry Pi w pokoju Eliota." );
        }

        public static void OnRaspberryFound() {
            bool sdCardInEquipment = GameController.Instance().GetEquipment().ContainsBySlug("sd_card");
            if ( sdCardInEquipment ) {
                GameController.Instance().SetQuestMessage( "Podejdź do komputera i wgraj rootkit'a na Raspberry" );
            } else {
                GameController.Instance().SetQuestMessage( "Znajdź czystą kartę SD, aby wgrać swojego rootkit'a na raspberry." );
            }
        }

        public static void OnSDCardFound() {
            bool raspberryInEquipment = GameController.Instance().GetEquipment().ContainsBySlug( "raspberry_pi_blank" );
            if ( raspberryInEquipment ) {
                GameController.Instance().SetQuestMessage( "Podejdź do komputera i wgraj rootkit'a na raspberry" );
            }
        }

        public static void OnRootkitInstalled() {
            GameController.Instance().SetQuestMessage( "Wyjdź na przystanek i złap autobus na Coney Island. Pamiętaj, żeby zamknąć drzwi :3" );
        }

//        "Podejdź do zespołu, który stoi przy aucie."

    }
}