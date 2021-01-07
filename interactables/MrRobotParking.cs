using System;

namespace RGame {

    [Serializable]
    public class MrRobotParking : Interactable {

        public bool PlanExplained = false;
        public bool NewPlanExplained = false;
        public bool BillFailed = false;

        public bool ActiveInRange { get => true; }

        public void Interact() {
            if ( BillFailed == true ) {
                GameController.Instance().SetDialog( new MrRobotBillFailedDialog( NewPlanExplained ) );
            } else {
                GameController.Instance().SetDialog( new MrRobotParkingDialog( PlanExplained ) );
            }
        }

    }
}
