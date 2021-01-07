using System;

namespace RGame {

    [Serializable]
    public class TeamOnConeyIsland : Interactable {

        public bool ActiveInRange { get => true; }

        public void Interact() {
            GameController.Instance().SetDialog( new TeamOnConeyIslandDialog() );
        }

    }
}
