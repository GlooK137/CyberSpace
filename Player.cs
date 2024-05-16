// Player.cs
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace monogame_1
{
    public class Player
    {
        private Texture2D _stateFrontTexture;
        private Texture2D _stateBackTexture;
        private Texture2D _stateLeftTexture;
        private Texture2D _playerCurrentTexture;
        private Vector2 _playerPosition;
        private Vector2 _playerScale;
        private Vector2 _targetPosition;
        private readonly int _scale;

        // Game settings
        private const int SquareWidth = 16;
        private const int SquareHeight = 22;
        private const float MoveSpeed = 2f; // Скорость движения
        
        // Проверка, осуществляется ли движение
        public bool IsMoving => _targetPosition != _playerPosition;

        public Player(int screenWidth, int screenHeight, int scale)
        {
            _scale = scale;
            _playerPosition = new Vector2(0, (Constants.Cell * 2 - SquareHeight) * _scale);
            _playerScale = new Vector2(_scale, _scale);
            _targetPosition = _playerPosition;
        }

        public void LoadContent(ContentManager content, GraphicsDevice graphicsDevice)
        {
            // Симуляция загрузки текстуры. В реальном проекте загрузите текстуру из Content.
            _stateFrontTexture = content.Load<Texture2D>("Textures/Player/Front/Front_State");
            _stateBackTexture = content.Load<Texture2D>("Textures/Player/Back/Back_State");
            _stateLeftTexture = content.Load<Texture2D>("Textures/Player/Left/Left_State");

            _playerCurrentTexture = _stateFrontTexture;
        }

        public void Update(GameTime gameTime)
        {
            // Плавное движение к целевой позиции
            if (IsMoving)
            {
                Vector2 moveDirection = _targetPosition - _playerPosition;
                if (moveDirection.Length() > MoveSpeed)
                {
                    moveDirection.Normalize();
                    _playerPosition += moveDirection * MoveSpeed;
                }
                else
                {
                    _playerPosition = _targetPosition;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_playerCurrentTexture, _playerPosition, null, Color.White, 0, Vector2.Zero, _playerScale, SpriteEffects.None, 0);
        }

        // Движение в разных направлениях
        public void MoveUp()
        {
            _targetPosition.Y -= Constants.MoveDistance * _scale;
            _playerCurrentTexture = _stateBackTexture;
        }

        public void MoveDown()
        {
            _targetPosition.Y += Constants.MoveDistance * _scale;
            _playerCurrentTexture = _stateFrontTexture;
        }

        public void MoveLeft()
        {
            _targetPosition.X -= Constants.MoveDistance * _scale;
            _playerCurrentTexture = _stateLeftTexture;
        }

        public void MoveRight()
        {
            _targetPosition.X += Constants.MoveDistance * _scale;
        }
    }
}
