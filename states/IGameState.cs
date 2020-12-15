using System;

namespace Game {
   abstract class IGameState {
        protected Context context;

        public void SetContext( Context context ) {
            this.context = context;
        }

        public abstract void Draw();
        public abstract void Hints();
        public abstract void HandleKeyPress( char choice );
    }
}
