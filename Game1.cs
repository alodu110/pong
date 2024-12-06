using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong;

namespace pong
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        
        

        private Sprite _sprite1;
        private Sprite2 _sprite2;
        private Sprite3 _sprite3;
        SpriteFont font;






        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here




            base.Initialize();
        }


     
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            var texture = Content.Load<Texture2D>("playerV2");
            var textureball = Content.Load<Texture2D>("ball2");
            font = Content.Load<SpriteFont>("Score");
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.spriteBatch = _spriteBatch;

            _sprite1 = new Sprite(texture, new Rectangle(10, 100, 10, 80))
            {
                speed = 20f
            };

            _sprite2 = new Sprite2(texture, new Rectangle(780, 100, 10, 80))
            {
                speed = 20f
            };

            _sprite3 = new Sprite3(texture);



            








        }

        protected override void Update(GameTime gameTime)
        {
            _sprite1.Update();
            _sprite2.Update();
            _sprite3.Update(gameTime, _sprite1, _sprite2);




            // TODO: Add your update logic here

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _sprite1.Draw(_spriteBatch);
            _sprite2.Draw(_spriteBatch);
            _sprite3.Draw(_spriteBatch);
            Globals.spriteBatch.DrawString(font, Globals.player1_score.ToString(), new Vector2(100, 50), Color.White);
            Globals.spriteBatch.DrawString(font, Globals.player2_score.ToString(), new Vector2(Globals.WIDTH - 112, 50), Color.White);



            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
