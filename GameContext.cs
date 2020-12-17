using System;

namespace RGame {
    public class GameContext : GameState {
        private GameState state = null;

        public GameContext( GameState state ) {
            this.SetState( state );
        }

        public void SetState( GameState state) {
            this.state = state;
            this.state.SetContext( this );
        }

        public override void Draw() {
            this.state.Draw();
        }

        public override void DrawHints() {
            this.state.DrawHints();
        }

        public override bool HandleKeyPress( char choice ) {
            return this.state.HandleKeyPress( choice );
        }
    }
}