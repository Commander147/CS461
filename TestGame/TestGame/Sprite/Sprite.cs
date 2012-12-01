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
    public class Sprite
    {
        public Vector2 position;
        private GraphicsDevice graphicsDevice;
        private ContentManager contentManager;
        private SpriteBatch spriteBatch;
        private Texture2D image;
        private KeyboardState oldState;
        private int curFrame = 0;
        private int direction = 0;
        private float timer = 0f;
        private bool walking = false;
        private bool keepmoving = false;
        private int[,] movedata;
        private State status = new State();

        enum State
        {
            Waiting,
            MoveRight,
            MoveLeft,
            MoveUp,
            MoveDown
        }

        public Sprite(int x,int y, int type , ContentManager cm, GraphicsDevice gd,int [,] movedata){
            this.movedata = movedata;
            position = new Vector2(x, y);
            contentManager = cm;
            graphicsDevice = gd;
            Initilize();
            LoadContent();
            status = State.Waiting;
        }

        public void Initilize(){
            spriteBatch = new SpriteBatch(graphicsDevice);
        }

        public void LoadContent(){
            image = contentManager.Load<Texture2D>(@"Sprites/player");
        }
        public void Draw(GameTime gametime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(image, position, new Rectangle(curFrame * 32 / 2, direction * 40 / 2, 16, 39 / 2), Color.White, 0, Vector2.Zero, new Vector2(3f, 2.461538461538461538f), SpriteEffects.None, 0);
            spriteBatch.End();
        }

        public void Update(GameTime gametime)
        {
            //Console.WriteLine(position.X / (16 * 3));
            //Console.WriteLine(movedata[(int)(position.Y/48 % 16), (int)(position.X/48 % 16)]);
            var newState = Keyboard.GetState();
            timer += (float)gametime.ElapsedGameTime.TotalMilliseconds;
            //Console.WriteLine(status);
            switch (status)
            {
                //(movedata[(int)(((position.Y + 48) / 48) % 16), (int)((position.X / 48) % 16)] == 0)
                
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
    }
             
}
