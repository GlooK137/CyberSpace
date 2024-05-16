// InputManager.cs
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace monogame_1
{
    public class InputManager
    {
        private Player _player;

        public InputManager(Player player)
        {
            _player = player;
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();

            // Только начать движение, если игрок не двигается в данный момент
            if (!_player.IsMoving)
            {
                if (state.IsKeyDown(Keys.W))
                {
                    _player.MoveUp();
                }
                else if (state.IsKeyDown(Keys.S))
                {
                    _player.MoveDown();
                }
                else if (state.IsKeyDown(Keys.A))
                {
                    _player.MoveLeft();
                }
                else if (state.IsKeyDown(Keys.D))
                {
                    _player.MoveRight();
                }
            }
        }
    }
}
