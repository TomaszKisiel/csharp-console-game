using System;

namespace Game {
   class GameController {
        private static GameController instance = null;
        private Context state = null;
        private Point player = null;
        private IRoom room = null;
//        private Equipment eq = null;
//        private QuestsLog quests = null;

        private GameController() {
//            eq = new Equipment();
//            quests = new QuestsLog();

            state = new Context( new MenuState() );
        }

        public static GameController GetInstance() {
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
                state.Hints();

                choice = Console.ReadKey().KeyChar;

                state.HandleKeyPress( choice );
            }
        }

        public void SetPlayer( Point player ) {
            this.player = player;
        }

        public Point GetPlayer() {
            return this.player;
        }

        public void SetRoom( IRoom room ) {
            this.room = room;
        }

        public IRoom GetRoom() {
            return this.room;
        }
    }
}
