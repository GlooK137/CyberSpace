using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace monogame_1
{
    public class MessageDisplay
    {
        private Texture2D _messageTexture;
        private string _messageText;
        private SpriteFont _font;
        private bool _isVisible;

        public bool IsVisible
        {
            get => _isVisible;
            set => _isVisible = value;
        }

        public MessageDisplay(SpriteFont font)
        {
            _font = font;
            _isVisible = true;
        }

        public void LoadContent(ContentManager content)
        {
            _messageTexture = content.Load<Texture2D>("Textures/UI/Message/Message");
            _messageText = "Здорово! Какое чудесное утро, хочу спать! Или опять играть до ночи!";
        }

        public void Update(GameTime gameTime)
        {
            if (_isVisible && Keyboard.GetState().GetPressedKeyCount() > 0)
            {
                _isVisible = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
        {
            if (_isVisible)
            {
                spriteBatch.Draw(_messageTexture, 
                    new Vector2(0, graphics.GraphicsDevice.Viewport.Height - 48 * Constants.Scale), 
                    null, Color.White, 0, Vector2.Zero, Constants.Scale, SpriteEffects.None, 0);
                
                spriteBatch.DrawString(_font, _messageText, 
                    new Vector2(38 * Constants.Scale, graphics.GraphicsDevice.Viewport.Height - 44 * Constants.Scale), 
                    Color.White);
            }
        }
    }
}
