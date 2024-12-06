using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pong
{
    public class Sprite2
    {
        private Texture2D _texture;
        public Vector2 Position;
        public Rectangle Bounds2 { get; private set; }


        public float speed = 2f;

        public Sprite2(Texture2D texture, Rectangle initialBounds)
        {
            _texture = texture;
            Bounds2 = initialBounds;
            Position = new Vector2(initialBounds.X, initialBounds.Y);
        }
        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up) && Position.Y > 0)
            {
                Position.Y -= speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down) && Position.Y < Globals.HEIGHT - Bounds2.Height)
            {
                Position.Y += speed;
            }
            Bounds2 = new Rectangle((int)Position.X, (int)Position.Y, Bounds2.Width, Bounds2.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Bounds2, Color.White);
        }
    }
}
