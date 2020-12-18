using System;
using System.IO;
//using System.Linq;
//using System.Runtime.Serialization;
//using System.Runtime.Serialization.Formatters.Binary;
//using System.Text;
//using System.Threading.Tasks;

namespace RGame {
    public class Program {
        public static void Main( string[] args ) {
            // Finally… spaghetti oriented programming has been extracted :3
            GameController.Instance().Start();
        }
    }
}


//            InteractableRepository interactables = InteractableRepository.Instance();
//            Chest chest = ( Chest ) interactables.Get("chest");
//
//            chest.Interact();
//
//            // SAVE
//            Directory.CreateDirectory(@".saves/test");
//            Stream stream = new FileStream( @".saves/test/chest.save", FileMode.Create, FileAccess.Write );
//
//            IFormatter formatter = new BinaryFormatter();
//            formatter.Serialize( stream, chest );
//
//            stream.Close();
//            // END
//
//            chest.ContainsRaspberry = false;
//            chest.Interact();
//
//            // LOAD
//            stream = new FileStream( @".saves/test/chest.save", FileMode.Open, FileAccess.Read );
//            chest = ( Chest ) formatter.Deserialize( stream );
//            // END
//
//            chest.Interact();