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

        public Point player = null;
        public Room room = null;
        public Equipment equipment = null;

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
    }
}
