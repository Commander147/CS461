using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace TestGame
{
    public abstract class Sprite
    {
        public Vector2 position;
        protected GraphicsDevice graphicsDevice;
        protected ContentManager contentManager;
        protected SpriteBatch spriteBatch;
        protected Texture2D image;
        protected KeyboardState oldState;
        protected int curFrame = 0;
        protected int direction = 0;
        protected float timer = 0f;
        protected bool walking = false;
        protected bool keepmoving = false;
        protected int[,] movedata;
        protected State status = new State();
        protected Vector2 destination = new Vector2();
        protected bool automove = false;
        protected Point playerFrameSize;
        protected Vector2 velocity;
        protected int collisionOffset;
        protected int type;
        protected SceneManager sceneManager;

        public void move(Vector2 dest)
        {
            dest.X = dest.X % 16 * 48;
            dest.Y = dest.Y % 16 * 48;
            Console.WriteLine(dest);
            destination = dest;
            automove = true;
        }

        protected enum State
        {
            Waiting,
            MoveRight,
            MoveLeft,
            MoveUp,
            MoveDown
        }

        public Sprite() { }

        public Sprite(int x,int y, int type , ContentManager cm, GraphicsDevice gd,int [,] movedata){
            this.movedata = movedata;
            position = new Vector2(x, y);
            contentManager = cm;
            graphicsDevice = gd;
            status = State.Waiting;
        }

        public Sprite(Texture2D image, Point playerFrameSize, Vector2 position, Vector2 velocity,
            int collisionOffset, int type, int[,] movedata, SceneManager sm)
        {
            this.image = image;
            this.playerFrameSize = playerFrameSize;
            this.position = position;
            this.velocity = velocity;
            this.collisionOffset = collisionOffset;
            this.type = type;
            this.movedata = movedata;
            sceneManager = sm;
            status = State.Waiting;
        }

        public virtual void Draw(GameTime gametime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(image, position, new Rectangle(curFrame * 32 / 2, direction * 40 / 2, 16, 39 / 2), Color.White, 0, Vector2.Zero, new Vector2(3f, 2.461538461538461538f), SpriteEffects.None, 0);
            spriteBatch.End();
        }

        public virtual void Update(GameTime gametime)
        {
            var newState = Keyboard.GetState();
            timer += (float)gametime.ElapsedGameTime.TotalMilliseconds;
            switch (status)
            {                
                case State.Waiting:
                    {
                        if (newState.IsKeyDown(Keys.Right))
                        {
                            status = State.MoveRight;
                        }
                        else if (newState.IsKeyDown(Keys.Left))
                        {
                            status = State.MoveLeft;
                        }
                        else if (newState.IsKeyDown(Keys.Up))
                        {
                            status = State.MoveUp;
                        }
                        else if (newState.IsKeyDown(Keys.Down))
                        {
                            status = State.MoveDown;
                        }
                        else if (automove)
                        {
                            if (position.X < destination.X)
                            {
                                status = State.MoveRight;
                            }
                            else if (position.X == destination.X){
                            }
                            else
                            {
                                status = State.MoveLeft;
                            }

                            if (position.Y < destination.Y)
                            {
                                status = State.MoveDown;
                            }
                            else if (position.Y == destination.Y)
                            {
                            }
                            else
                            {
                                status = State.MoveUp;
                            }

                            if (position.X == destination.X && position.Y == destination.Y)
                            {
                                automove = false;
                            }

                        }
                        break;
                    }

                case State.MoveRight:
                    {
                        if (walking)
                        {
                            if (movedata[(int)(((position.Y) / 48) % 16), (int)(((position.X + 48) / 48) % 16)] == 0 && keepmoving)
                            {
                                position.X += 4;
                                keepmoving = true;
                                if (timer > 100f)
                                {
                                    curFrame++;
                                    timer = 0f;
                                }
                                if (curFrame == 4)
                                {
                                    curFrame = 0;
                                }
                                if ((int)position.X % 48 == 0)
                                {
                                    keepmoving = false;
                                    walking = false;
                                    status = State.Waiting;
                                }
                            }
                            else
                            {
                                keepmoving = false;
                                walking = false;
                                status = State.Waiting;
                            }
                        }
                        else
                        {
                            curFrame = 0;
                            direction = 2;
                            walking = true;
                            keepmoving = true;
                        }
                        break;
                    }
                case State.MoveDown:
                    {
                        if (walking)
                        {
                            if (movedata[(int)(((position.Y + 48) / 48) % 16), (int)((position.X / 48) % 16)] == 0 && keepmoving)
                            {
                                position.Y += 4;
                                keepmoving = true;
                                if (timer > 100f)
                                {
                                    curFrame++;
                                    timer = 0f;
                                }
                                if (curFrame == 4)
                                {
                                    curFrame = 0;
                                }
                                if ((int)position.Y % 48 == 0)
                                {
                                    keepmoving = false;
                                    walking = false;
                                    status = State.Waiting;
                                }
                            }
                            else{
                                keepmoving = false;
                                walking = false;
                                status = State.Waiting;
                            }
                        }
                        else
                        {
                            curFrame = 0;
                            direction = 0;
                            walking = true;
                            keepmoving = true;
                        }
                        break;
                    }
                case State.MoveUp:
                    {
                        if (walking)
                        {
                            if (movedata[(int)(((position.Y-1) / 48) % 16), (int)((position.X / 48) % 16)] == 0 && keepmoving)
                            {
                                position.Y -= 4;
                                keepmoving = true;
                                if (timer > 100f)
                                {
                                    curFrame++;
                                    timer = 0f;
                                }
                                if (curFrame == 4)
                                {
                                    curFrame = 0;
                                }
                                if ((int)position.Y % 48 == 0)
                                {
                                    keepmoving = false;
                                    walking = false;
                                    status = State.Waiting;
                                }
                            }
                            else
                            {
                                curFrame = 0;
                                keepmoving = false;
                                walking = false;
                                status = State.Waiting;
                            }
                        }
                        else
                        {
                            curFrame = 0;
                            direction = 3;
                            walking = true;
                            keepmoving = true;
                        }
                        break;
                    }
                case State.MoveLeft:
                    {
                        if (walking)
                        {
                            if (movedata[(int)(((position.Y) / 48) % 16), (int)(((position.X-1 ) / 48) % 16)] == 0 && keepmoving)
                            {
                                position.X -= 4;
                                keepmoving = true;
                                if (timer > 100f)
                                {
                                    curFrame++;
                                    timer = 0f;
                                }
                                if (curFrame == 4)
                                {
                                    curFrame = 0;
                                }
                                if ((int)position.X % 48 == 0)
                                {
                                    keepmoving = false;
                                    walking = false;
                                    status = State.Waiting;
                                }
                            }
                            else
                            {
                                keepmoving = false;
                                walking = false;
                                status = State.Waiting;
                            }
                        }
                        else
                        {
                            curFrame = 0;
                            direction = 1;
                            walking = true;
                            keepmoving = true;
                        }
                        break;
                    }
            }
            oldState = newState;
        }

        public Rectangle collisionRect
        {
            get
            {
                return new Rectangle(
                    (int)position.X + collisionOffset,
                    (int)position.Y + collisionOffset,
                    playerFrameSize.X - (collisionOffset * 2),
                    playerFrameSize.Y - (collisionOffset * 2));
            }
        }
    }
             
}
