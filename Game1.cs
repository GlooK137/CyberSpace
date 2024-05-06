using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace monogame_1;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    
    // Определение разрешения GBA
    private readonly int _gbaWidth = 240;
    private readonly int _gbaHeight = 160;
    // Коэффициент увеличения
    private readonly int _scale = 4;  

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        // Установка желаемого размера окна
        _graphics.PreferredBackBufferWidth = _gbaWidth * _scale; // Умножаем ширину на 4
        _graphics.PreferredBackBufferHeight = _gbaHeight * _scale; // Умножаем высоту на 4
        _graphics.ApplyChanges();

        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    // Остальные методы...
    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
    }
    
    protected override void Draw(GameTime gameTime)
    {
      GraphicsDevice.Clear(Color.CornflowerBlue);

      _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);

      _spriteBatch.End();

      base.Draw(gameTime);
    }
}
