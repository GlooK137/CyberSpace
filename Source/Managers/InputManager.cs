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

            // Обработка ввода с клавиатуры
            ProcessKeyboardInput(keyboardState);
        }

        private void ProcessKeyboardInput(KeyboardState keyboardState) {
            // Проверяем, не двигается ли в данный момент игрок
            if (!_player.IsMoving) {
                if (keyboardState.IsKeyDown(Keys.W)) {
                    MovePlayer(Direction.Up);
                } else if (keyboardState.IsKeyDown(Keys.S)) {
                    MovePlayer(Direction.Down);
                } else if (keyboardState.IsKeyDown(Keys.A)) {
                    MovePlayer(Direction.Left);
                } else if (keyboardState.IsKeyDown(Keys.D)) {
                    MovePlayer(Direction.Right);
                }
            }
        }

        private void MovePlayer(Direction direction) {
            // Передвигаем игрока в зависимости от направления
            switch (direction) {
                case Direction.Up:
                    _player.MoveUp();
                    break;
                case Direction.Down:
                    _player.MoveDown();
                    break;
                case Direction.Left:
                    _player.MoveLeft();
                    break;
                case Direction.Right:
                    _player.MoveRight();
                    break;
            }
        }

        // Вспомогательное перечисление для направлений движения
        enum Direction {
            Up,
            Down,
            Left,
            Right
        }
    }
}
