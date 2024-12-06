using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace pong
{
    public class Sprite3
    {
        private Texture2D _texture;
        public Vector2 Position;
        private Vector2 direction = new Vector2(1, 1);
        int moveSpeed = 200;

        private Rectangle rect;

        public Sprite3(Texture2D texture)
        {
            _texture = texture;
            Position = new Vector2(Globals.WIDTH / 2 - 20, Globals.HEIGHT / 2 - 20); 
        }

        public void Update(GameTime gameTime, Sprite player1, Sprite2 player2)
        {
            
            float deltaSpeed = moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

           
            Position.X += direction.X * deltaSpeed;
            Position.Y += direction.Y * deltaSpeed;

            
            rect = new Rectangle((int)Position.X, (int)Position.Y, 10, 10);

            
            if (player1.Bounds1.Right > rect.Left && rect.Top > player1.Bounds1.Top && rect.Bottom < player1.Bounds1.Bottom)
            {
                direction.X = 1;
            }

            if (player2.Bounds2.Left < rect.Right && rect.Top > player2.Bounds2.Top && rect.Bottom < player2.Bounds2.Bottom)
            {
                direction.X = -1;
            }

            
            if (rect.Y < 0 || rect.Y > Globals.HEIGHT - rect.Height)
            {
                direction.Y *= -1;
            }


            if (rect.X < 0)
            {
                Globals.player2_score += 1;
                resetGame();
            }


            if (rect.X > Globals.WIDTH - rect.Width)
            {
                Globals.player1_score += 1;
                resetGame();
            }

        }

        public void resetGame()
        {
            Position = new Vector2(Globals.WIDTH / 2 - 20, Globals.HEIGHT / 2 - 20);

            
            Random random = new Random();
            float randomX = (float)(random.NextDouble() * 2 - 1); 
            float randomY = (float)(random.NextDouble() * 2 - 1); 

            
            if (Math.Abs(randomX) < 0.5f)
                randomX = randomX < 0 ? -0.5f : 0.5f;
            if (Math.Abs(randomY) < 0.5f)
                randomY = randomY < 0 ? -0.5f : 0.5f;

            direction = new Vector2(randomX, randomY);
            direction.Normalize();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, rect, Color.White);
        }
    }
}
