using System;

namespace Game {
    class Context : IGameState {
        private IGameState currentState = null;

        public Context( IGameState state ) {
            this.SetState( state );
        }

        public void SetState( IGameState state) {
            this.currentState = state;
            this.currentState.SetContext( this );
        }

        public override void Draw() {
            this.currentState.Draw();
        }

        public override void Hints() {
            this.currentState.Hints();
        }

        public override void HandleKeyPress( char choice ) {
            this.currentState.HandleKeyPress( choice );
        }
    }
}