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
    public class Sprite
    {
        private Texture2D _texture;
        public Vector2 Position;
        public Rectangle Bounds1 { get; private set; }

        public float speed = 2f;

        public Sprite(Texture2D texture, Rectangle initialBounds)
        {
            _texture = texture;
            Bounds1 = initialBounds;
            Position = new Vector2(initialBounds.X, initialBounds.Y);
        }
        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Z) && Position.Y > 0)
            {
                Position.Y -= speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S) && Position.Y < Globals.HEIGHT - Bounds1.Height)
            {
                Position.Y += speed;
            }
            Bounds1 = new Rectangle((int)Position.X, (int)Position.Y, Bounds1.Width, Bounds1.Height);
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
           spriteBatch.Draw(_texture, Bounds1, Color.White);
        }

        
    }
}
