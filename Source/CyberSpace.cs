using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace monogame_1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private Texture2D _backgrountTexture;
        private SpriteBatch _spriteBatch;

        private GameMap _gameMap;
        
        // Тут будем создавать экземпляры классов Player и InputManager
        private Player _player;
        private InputManager _inputManager;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = Constants.GbaWidth * Constants.Scale;
            _graphics.PreferredBackBufferHeight = Constants.GbaHeight * Constants.Scale;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // Конфигурация и инициализация игровых элементов
            _gameMap = new GameMap();
            _gameMap.Objects[0,0] = new GameObject(true);
            _player = new Player(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight, Constants.Scale, _gameMap);
            _inputManager = new InputManager(_player);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _backgrountTexture = Content.Load<Texture2D>("Textures/Backgrounds/test_bg");
            
            // Инициализация ресурсов игрока
            _player.LoadContent(Content, GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            _inputManager.Update(gameTime);
            _player.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);
            _spriteBatch.Draw(_backgrountTexture, new Vector2(0,0), Color.White);
            
            _player.Draw(_spriteBatch);
            
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
