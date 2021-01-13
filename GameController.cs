using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Collections.Generic;

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
        private Message equipmentMsg = null;
        private Message questMsg = null;
        private Dialog dialog = null;

        private GameController() {
            equipment = new Equipment();
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

        public void GameOver() {
            state = new GameContext( new MainMenuState() );
            player = null;
            room = null;
            equipment = new Equipment();
            equipmentMsg = null;
            questMsg = null;
            dialog = null;
        }

        public bool Save( string name ) {
            try {
                if ( name == null || name == "" ) {
                    throw new ArgumentNullException();
                }

                if ( Directory.Exists( @".saves/" + name ) ) {
                    Directory.Delete( @".saves/" + name );
                }
                Directory.CreateDirectory( @".saves/" + name );

                Stream stream = null;
                IFormatter formatter = new BinaryFormatter();

                stream = new FileStream( @".saves/" + name + "/state.save", FileMode.Create, FileAccess.Write );
                formatter.Serialize( stream, this );
                stream.Close();

                stream = new FileStream( @".saves/" + name + "/actions.save", FileMode.Create, FileAccess.Write );
                formatter.Serialize( stream, InteractablesRepository.Instance() );
                stream.Close();
            } catch {
                return false;
            }

            return true;
        }

        public bool Load( string name ) {
            try {
                if ( name == null || name == "" ) {
                    throw new ArgumentNullException();
                }

                if ( !Directory.Exists( @".saves/" + name ) ) {
                    throw new DirectoryNotFoundException();
                }

                IFormatter formatter = new BinaryFormatter();
                Stream stream = null;

                stream = new FileStream( @".saves/" + name + "/state.save", FileMode.Open, FileAccess.Read );
                instance = ( GameController ) formatter.Deserialize( stream );
                stream.Close();

                stream = new FileStream( @".saves/" + name + "/actions.save", FileMode.Open, FileAccess.Read );
                InteractablesRepository.InjectRepository( ( InteractablesRepository ) formatter.Deserialize( stream ) );
                stream.Close();
            } catch {
                return false;
            }

            return true;
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

        public void SetEquipmentMessage( string msg ) {
            this.equipmentMsg = new Message( Speakers.EQUIPMENT, msg );
        }

        public Message GetEquipmentMessage() {
            return this.equipmentMsg;
        }

        public void SetQuestMessage( string msg ) {
            this.questMsg = new Message( Speakers.QUEST, msg );
        }

        public Message GetQuestMessage() {
            return this.questMsg;
        }

        public void SetDialog( Dialog dialog ) {
            this.dialog = dialog;
        }

        public Dialog GetDialog() {
            return this.dialog;
        }

    }
}
