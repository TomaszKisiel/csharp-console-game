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

        public static void OnConeyIslandTransition() {
            GameController.Instance().SetRoom( RoomsRepository.Instance().Get( "coney_island" ) );
            GameController.Instance().SetPlayer( new Point( 3, 9 ) );
            GameController.Instance().SetQuestMessage( "Podejdź do zespołu, który stoi przy aucie." );
        }

        public static void OnActionBegin() {
            GameController.Instance().SetRoom( RoomsRepository.Instance().Get( "parking" ) );
            GameController.Instance().SetPlayer( new Point( 7, 11 ) );
            GameController.Instance().SetQuestMessage( "Omów szczegóły planu z Mr. Robotem." );
        }

        public static void OnTryGetInStillMountain() {
            GameController.Instance().SetQuestMessage( "Znajdź przewodnika w Steel Mountain." );
        }

        public static void OnBillFailed() {
            GameController.Instance().SetQuestMessage( "Nie udało się przejść przez Billa. Porozmawiaj z Mr. Robotem." );
            ( ( MrRobotParking ) InteractablesRepository.Instance().Get("mr_robot_parking") ).BillFailed = true;
        }

        public static void OnBillDestroyed() {
            GameController.Instance().SetRoom( RoomsRepository.Instance().Get( "corridor_iii" ) );
            GameController.Instance().SetPlayer( new Point( 15, 6 ) );
            MainQuest.OnGetInSteelMountain();
        }

        public static void OnBackdoorPicklocked() {
            GameController.Instance().SetRoom( RoomsRepository.Instance().Get( "corridor_i" ) );
            GameController.Instance().SetPlayer( new Point( 0, 12 ) );
            MainQuest.OnGetInSteelMountain();
        }

        public static void OnGetInSteelMountain() {
            GameController.Instance().SetQuestMessage( "Znajdź termostat w łazience koło open space'ów i zamontuj Raspberry Pi." );
        }

        public static void OnTyrellLeft() {
            GameController.Instance().SetQuestMessage( "Dokończ podłączanie Raspberry do termostatu." );
        }

        public static void OnRaspberryPiMounted() {
            GameController.Instance().SetQuestMessage( "Nadaj uprawnienia użytkownikowi fsociety przez główny komputer w serwerowni." );
        }

    }
}
