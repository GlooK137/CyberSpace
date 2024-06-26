// Player.cs
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace monogame_1 {
  public class Player {
    private Texture2D _stateFrontTexture;
    private Texture2D _stateBackTexture;
    private Texture2D _stateLeftTexture;
    private Texture2D _stateRightTexture;

    private GameMap _gameMap;

    private Texture2D _playerCurrentTexture;
    public static Vector2 _playerPosition { get; set; }
    private Vector2 _playerScale;
    private Vector2 _targetPosition;
    private readonly int _scale;

    private Texture2D[] _animationFrontTextures; // Текстуры анимации вверх
    private Texture2D[] _animationBackTextures; // Текстуры анимации вниз
    private Texture2D[] _animationLeftTextures; // Текстуры анимации влево
    private Texture2D[] _animationRightTextures; // Текстуры анимации вправо

    private TimeSpan _timeSinceLastFrame;
    private int _currentAnimationFrame;

    private double _animationFrameTime = 0.1; // time per frame in seconds

    // Game settings
    private const int SquareWidth = 16;
    private const int SquareHeight = 22;
    private const float MoveSpeed = 2f; // Скорость движения

    // Проверка, осуществляется ли движение
    public bool IsMoving => _targetPosition != _playerPosition;

    public Player(int screenWidth, int screenHeight, int scale, GameMap gameMap) {
      _scale = scale;
      _gameMap = gameMap;
      _playerPosition = new Vector2(0, (Constants.Cell * 2 - SquareHeight - 8) * _scale);
      _playerScale = new Vector2(_scale, _scale);
      _targetPosition = _playerPosition;
    }

    public void LoadContent(ContentManager content, GraphicsDevice graphicsDevice) {
      _stateFrontTexture = content.Load < Texture2D > ("Textures/Player/Front/Front_State");
      _stateBackTexture = content.Load < Texture2D > ("Textures/Player/Back/Back_State");
      _stateLeftTexture = content.Load < Texture2D > ("Textures/Player/Left/Left_State");
      _stateRightTexture = content.Load < Texture2D > ("Textures/Player/Right/Right_State");

      _animationFrontTextures = new Texture2D[] {
        content.Load < Texture2D > ("Textures/Player/Front/Front_Animate_1"),
          content.Load < Texture2D > ("Textures/Player/Front/Front_Animate_2")
      };

      _animationBackTextures = new Texture2D[] {
        content.Load < Texture2D > ("Textures/Player/Back/Back_Animate_1"),
          content.Load < Texture2D > ("Textures/Player/Back/Back_Animate_2")
      };

      _animationLeftTextures = new Texture2D[] {
        content.Load < Texture2D > ("Textures/Player/Left/Left_Animate_1"),
          content.Load < Texture2D > ("Textures/Player/Left/Left_Animate_2")
      };

      _animationRightTextures = new Texture2D[] {
        content.Load < Texture2D > ("Textures/Player/Right/Right_Animate_1"),
          content.Load < Texture2D > ("Textures/Player/Right/Right_Animate_2")
      };

      _playerCurrentTexture = _stateFrontTexture;
    }

    public void Update(GameTime gameTime) {
      // Плавное движение к целевой позиции
      if (IsMoving) {
        UpdateAnimation(gameTime);
        SetAnimationTexture();
      } else {
        StateFrame();
      }
      SmoothMovement(gameTime);
    }

    public void EnterBattleMode() {
    Game1.InBattleMode = true;
    }

    // Выход из режима боя
    public void ExitBattleMode() {
      Game1.InBattleMode = false;
    }

    private void StateFrame(){
        // Когда игрок стоит на месте, возвращается к текстуре состояния
        _currentAnimationFrame = 0;
        if (_playerCurrentTexture == _stateBackTexture || _playerCurrentTexture == _animationBackTextures[0] || _playerCurrentTexture == _animationBackTextures[1]) {
          _playerCurrentTexture = _stateBackTexture;
        } else if (_playerCurrentTexture == _stateFrontTexture || _playerCurrentTexture == _animationFrontTextures[0] || _playerCurrentTexture == _animationFrontTextures[1]) {
          _playerCurrentTexture = _stateFrontTexture;
        } else if (_playerCurrentTexture == _stateLeftTexture || _playerCurrentTexture == _animationLeftTextures[0] || _playerCurrentTexture == _animationLeftTextures[1]) {
          _playerCurrentTexture = _stateLeftTexture;
        } else if (_playerCurrentTexture == _stateRightTexture || _playerCurrentTexture == _animationRightTextures[0] || _playerCurrentTexture == _animationRightTextures[1]) {
          _playerCurrentTexture = _stateRightTexture;
        }
    }

    private void UpdateAnimation(GameTime gameTime) {
      _timeSinceLastFrame += gameTime.ElapsedGameTime;

        if (_timeSinceLastFrame.TotalSeconds >= _animationFrameTime) {
          _timeSinceLastFrame = TimeSpan.Zero;
          _currentAnimationFrame++;

          if (_currentAnimationFrame >= _animationFrontTextures.Length)
            _currentAnimationFrame = 0;
        }
    }

    private void SetAnimationTexture() {
      // Определите направление и обновите текущую текстуру для анимации
        if (_targetPosition.Y < _playerPosition.Y) // Игрок двигается вверх
        {
          _playerCurrentTexture = _animationBackTextures[_currentAnimationFrame];
        } else if (_targetPosition.Y > _playerPosition.Y) // Игрок двигается вниз
        {
          _playerCurrentTexture = _animationFrontTextures[_currentAnimationFrame];
        } else if (_targetPosition.X > _playerPosition.X) // Игрок двигается вправо
        {
          _playerCurrentTexture = _animationRightTextures[_currentAnimationFrame];
        } else if (_targetPosition.X < _playerPosition.X) // Игрок двигается влево
        {
          _playerCurrentTexture = _animationLeftTextures[_currentAnimationFrame];
        }    
    }

    private void SmoothMovement(GameTime gameTime) {
      // Добавим реализацию плавного движения сюда
      Vector2 moveDirection = _targetPosition - _playerPosition;
      if (moveDirection.Length() > Constants.MoveSpeed) {
        moveDirection.Normalize();
        _playerPosition += moveDirection * Constants.MoveSpeed;
      } else {
        _playerPosition = _targetPosition;
      }
    }

    public void Draw(SpriteBatch spriteBatch) {
      spriteBatch.Draw(_playerCurrentTexture, _playerPosition, null, Color.White, 0, Vector2.Zero, _playerScale, SpriteEffects.None, 0);
    }

    // Движение в разных направлениях
    public void MoveUp() {
      _targetPosition.Y -= Constants.MoveDistance * _scale;
    }

    public void MoveDown() {
      _targetPosition.Y += Constants.MoveDistance * _scale;
    }

    public void MoveLeft() {
      if(_playerPosition.X - Constants.MoveDistance * _scale > 128)
        _targetPosition.X -= Constants.MoveDistance * _scale;
    }

    public void MoveRight() {
      _targetPosition.X += Constants.MoveDistance * _scale;
    }
  }
}
