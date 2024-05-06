using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace monogame_1;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    // Square settings
    private Texture2D _squareTexture;
    private Vector2 _playerPosition;
    private Vector2 _playerScale;
    private const int SquareWidth = 16;
    private const int SquareHeight = 22;

    // GameBoy resolution and scaling
    private readonly int _gbaWidth = 240;
    private readonly int _gbaHeight = 160;
    private readonly int _scale = 4;  

    // Для плавного движения
    private bool _isMoving = false;
    private Vector2 _targetPosition;
    private float _moveSpeed = 2f; // Скорость движения

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.PreferredBackBufferWidth = _gbaWidth * _scale;
        _graphics.PreferredBackBufferHeight = _gbaHeight * _scale;
        _graphics.ApplyChanges();

        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _playerPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2 - SquareWidth / 2,
                                      _graphics.PreferredBackBufferHeight / 2 - SquareHeight / 2);
        _playerScale = new Vector2(_scale, _scale); // apply scale to player's square
        _targetPosition = _playerPosition;

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _squareTexture = new Texture2D(GraphicsDevice, SquareWidth, SquareHeight);
        Color[] colorData = new Color[SquareWidth * SquareHeight];
        for (int i = 0; i < colorData.Length; ++i) colorData[i] = Color.White;
        _squareTexture.SetData(colorData);
    }

    protected override void Update(GameTime gameTime)
    {
        KeyboardState state = Keyboard.GetState();

        if (!_isMoving)
        {
            if (state.IsKeyDown(Keys.W)) {
                _targetPosition.Y -= 16 * _scale; // Масштабирование размера клетки
                _isMoving = true;
            }
            else if (state.IsKeyDown(Keys.S)) {
                _targetPosition.Y += 16 * _scale;
                _isMoving = true;
            }
            else if (state.IsKeyDown(Keys.A)) {
                _targetPosition.X -= 16 * _scale;
                _isMoving = true;
            }
            else if (state.IsKeyDown(Keys.D)) {
                _targetPosition.X += 16 * _scale;
                _isMoving = true;
            }
        }

        // Плавное движение к цели
        if(_isMoving)
        {
            Vector2 moveDirection = _targetPosition - _playerPosition;
            if (moveDirection.Length() > _moveSpeed)
            {
                moveDirection.Normalize();
                _playerPosition += moveDirection * _moveSpeed;
            }
            else
            {
                _playerPosition = _targetPosition;
                _isMoving = false;
            }
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);

        // Here we draw the square using the scale
        _spriteBatch.Draw(_squareTexture, _playerPosition, null, Color.Red, 0, Vector2.Zero, _playerScale, SpriteEffects.None, 0);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
