using System;

namespace RGame {
   public abstract class GameState : Drawable, Controllable {
        protected GameContext context;

        public void SetContext( GameContext context ) {
            this.context = context;
        }

        public abstract void Draw();
        public abstract void DrawHints();
        public abstract bool HandleKeyPress( char choice );
    }
}
