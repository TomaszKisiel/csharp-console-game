using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace RGame {
    [Serializable]
    class GameController {
        [NonSerialized]
        private static GameController instance = null;
        [NonSerialized]
        private GameContext state = null;

        private Point player = null;
        private Room room = null;
        private Equipment equipment = null;

        private GameController() {
            equipment = new Equipment();
            equipment.Add( ItemsRepository.Instance().Get("sd_card") );
            equipment.Add( ItemsRepository.Instance().Get("rubber_duck") );
            equipment.Add( ItemsRepository.Instance().Get("raspberry_pi_without_sd_card") );
            equipment.Add( ItemsRepository.Instance().Get("raspberry_pi_with_rootkit") );
            equipment.Add( ItemsRepository.Instance().Get("picklock") );
            equipment.Add( ItemsRepository.Instance().Get("fsociety") );

            state = new GameContext( new MainMenuState() );
        }

        public static GameController Instance() {
            if ( instance == null ) {
                instance = new GameController();
            }
            return instance;
        }

        public void Start() {
            char choice = ( char ) 0;
            while( true ) {
                Console.Clear();

                state.Draw();
                state.DrawHints();

                choice = Console.ReadKey().KeyChar;
                state.HandleKeyPress( choice );
            }
        }

        public void SetPlayer( Point pos ) {
            this.player = pos;
        }

        public Point GetPlayer() {
            return this.player;
        }

        public void SetRoom( Room room ) {
            this.room = room;
        }

        public Room GetRoom() {
            return this.room;
        }

        public Equipment GetEquipment() {
            return this.equipment;
        }
    }
}
