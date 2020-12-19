using System;

namespace RGame {

    [Serializable]
    public class EliotPC : Interactable {

        public bool ActiveInRange { get => true; }

        public void Interact() {
            GameController.Instance().SetDialog( new EliotPCDialog(
                GameController.Instance().GetEquipment().ContainsBySlug("raspberry_pi_blank") &&
                GameController.Instance().GetEquipment().ContainsBySlug("sd_card")
            ) );
        }

    }
}