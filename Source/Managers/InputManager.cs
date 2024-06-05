using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace monogame_1 {
    public class InputManager {
        private Player _player;

        public InputManager(Player player) {
            _player = player;
        }

        public void Update(GameTime gameTime) {
            var keyboardState = Keyboard.GetState();

            if (!Game1.InBattleMode) {
                ProcessKeyboardInputForMovement(keyboardState);
            } else {
                ProcessKeyboardInputForBattle(keyboardState);
            }
        }

        private void ProcessKeyboardInputForMovement(KeyboardState keyboardState) {
            if (!_player.IsMoving) {
                if (keyboardState.IsKeyDown(Keys.W)) {
                    _player.MoveUp();
                } else if (keyboardState.IsKeyDown(Keys.S)) {
                    _player.MoveDown();
                } else if (keyboardState.IsKeyDown(Keys.A)) {
                    _player.MoveLeft();
                } else if (keyboardState.IsKeyDown(Keys.D)) {
                    _player.MoveRight();
                } else if (keyboardState.IsKeyDown(Keys.Space)) {
                    _player.EnterBattleMode();
                    Game1._messageDisplay.SetMessage("Это новое сообщение для игрока!");
                }
            }
        }

        private void ProcessKeyboardInputForBattle(KeyboardState keyboardState) {
            // Здесь можно обработать нажатие клавиш для действий в бою
            if (keyboardState.IsKeyDown(Keys.Enter)) {
                    _player.ExitBattleMode();
                }
        }
        enum Direction {
            Up,
            Down,
            Left,
            Right
        }
    }
}
