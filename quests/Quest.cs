using System;

namespace Game {
    class Quest {
//        private static

        public static bool ReadyToConeyIsland = false;

        public static void OnRaspberryPiFound() {
            Equipment eq = GameController.GetInstance().GetEquipment();

            if ( eq.ContainsItem( ItemsRepository.GetInstance().GetItem("blank_sd_card") ) ) {
                GameController.GetInstance().SetDialog( new Speech( Speakers.ELIOT, "Jest karta i Raspberry.. teraz tylko wgrać program." ));
                GameController.GetInstance().SetQuest( new Speech( Speakers.QUEST, "Podejdź do komputera i wgraj rootkit'a na Raspberry" ) );
            } else {
                GameController.GetInstance().SetDialog( new Speech( Speakers.ELIOT, "Jest Pi.. bez systemu na niewiele się przyda. Muszę znaleźć jakąś kartę pamięci." ));
                GameController.GetInstance().SetQuest( new Speech( Speakers.QUEST, "Znajdź czystą kartę SD, aby wgrać swojego rootkit'a na Raspberry." ) );
            }
        }

        public static void OnSdCardFound() {
            Equipment eq = GameController.GetInstance().GetEquipment();

            if ( eq.ContainsItem( ItemsRepository.GetInstance().GetItem("raspberry_pi_without_sd_card") ) ) {
                GameController.GetInstance().SetDialog( new Speech( Speakers.ELIOT, "Jest karta i Raspberry.. teraz tylko wgrać program." ));
                GameController.GetInstance().SetQuest( new Speech( Speakers.QUEST, "Podejdź do komputera i wgraj rootkit'a na Raspberry" ) );
            } else {
                GameController.GetInstance().SetDialog( new Speech( Speakers.ELIOT, "Pusta karta SD.. może się przydać gdyby nie było jej w Pi." ));
            }
        }

        public static void OnRootkitInstalledFound() {
            Equipment eq = GameController.GetInstance().GetEquipment();

            if ( eq.ContainsItem( ItemsRepository.GetInstance().GetItem("raspberry_pi_with_rootkit") ) ) {
                ReadyToConeyIsland = true;
                GameController.GetInstance().SetDialog( new Speech( Speakers.ELIOT, "Dobra.. raspberry gotowe.. teraz tylko dostać się na Coney Island. Za chwile będzie autobus." ));
                GameController.GetInstance().SetQuest( new Speech( Speakers.QUEST, "Wyjdź na przystanek i złap autobus na Coney Island. Pamiętaj, żeby zamknąć drzwi :3" ) );
            }
        }
    }
}