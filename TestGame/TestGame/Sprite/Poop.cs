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
        private Texture2D _sprite;
        public Texture2D sprite{
            get {return _sprite;}
            set {_sprite = value;}
        }

        public Poop(Vector2 pos) 
        {
            position = pos;
        }

        public override void Update(GameTime gameTime) { 
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(sprite, position, Color.White);
            spriteBatch.End();
        }
    }
}
