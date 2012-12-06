using System;
using System.Collections;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

using System.Diagnostics;

namespace TestGame
{
    class Poop : Sprite
    {
        ArrayList poopList = new ArrayList();
        MouseState oldState;
        bool _hidden = false;
        public bool hidden
        {
            get{ return _hidden;}
        }
        private Texture2D _sprite;
        public Texture2D sprite{
            get {return _sprite;}
            set {_sprite = value;}
        }

        public Poop(Vector2 pos) 
        {
            position = new Vector2((pos.X - (pos.X % 48)) + 5, (pos.Y - (pos.Y % 48)) + 13);
        }

        public override void Update(GameTime gameTime) {

            MouseState newState = Mouse.GetState();
            if ( !_hidden && newState.LeftButton == ButtonState.Released && oldState.LeftButton == ButtonState.Pressed && (((int)oldState.X / 48) % 16) == (((int)position.X / 48) % 16) && (((int)oldState.Y / 48) % 16) == (((int)position.Y / 48) % 16))
            {
                //Console.WriteLine((((int)position.X / 48) % 16) + " " + (((int)position.Y / 48) % 16));
                //Console.WriteLine();
                _hidden = true;
               // Console.WriteLine("Poop Pressed");
            }
            oldState = newState;
        }


        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (!hidden)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(sprite, position, null, Color.White, 0, Vector2.Zero, new Vector2(.2f, .2f), SpriteEffects.None, 0);
                //spriteBatch.Draw(sprite, position,sprite.Bounds, Color.White);
                spriteBatch.End();
            }
        }
    }
}
