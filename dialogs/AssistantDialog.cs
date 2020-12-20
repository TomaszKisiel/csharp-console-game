using System;
using System.Collections.Generic;

namespace RGame {
    public class AssistantDialog : Dialog {
        private const string TOUR = "Chciałem zwiedzić waszą placówkę";
        private const string OK = "W porządku, porozmawiam z nim";
        private const string LEAVE = "W niczym";

        private bool tourAnswer = false;

        private Menu menu = new Menu();

        public AssistantDialog() {
            menu.AddOption( TOUR );
            menu.AddOption( LEAVE );
        }

        public void Draw() {
            Console.Write( Speakers.ASSISTANT );
            if ( tourAnswer ) {
                Console.WriteLine("W tym celu należy wcześniej zarezerwować termin. Jeżeli był Pan umówiony proszę porozmawiać z Billem.. stoi tam przy wejściu na poziom pierwszy..");
            } else {
                Console.WriteLine("Witamy w Steel Mountain. W czym mogę Panu pomóc?");
            }
            Console.WriteLine();

            menu.Draw();
        }

        public bool HandleKeyPress( char choice ) {
            if ( menu.HandleKeyPress( choice) ) {
                return true;
            } else if ( choice == ( char ) 32 ) {
                if ( menu.GetCurrent() == LEAVE || menu.GetCurrent() == OK ) {
                    GameController.Instance().SetDialog( null );
                } else if ( menu.GetCurrent() == TOUR ) {
                    tourAnswer = true;
                    menu = new Menu( new List<string>() { OK } );
                }

                return true;
            }

            return false;
        }
    }
}