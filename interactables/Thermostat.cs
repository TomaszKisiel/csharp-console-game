using System;

namespace RGame {

    [Serializable]
    public class Thermostat : Interactable {

        public bool ActiveInRange { get => true; }
        public bool Started = false;
        public bool Hacked = false;

        public void Interact() {
            if ( Started ) {
                GameController.Instance().SetDialog( new ThermostatFinishDialog( Hacked ) );
            } else {
                GameController.Instance().SetDialog( new ThermostatDialog() );
            }
        }

    }
}
