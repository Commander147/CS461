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
    class ComputerAI : Sprite
    {
        private Queue<Vector2> waypoints = new Queue<Vector2>();
        private Vector2 destination = new Vector2();
        private float speed = 2.0f;
        SceneManager sceneManager;

        public ComputerAI(Texture2D image, Point playerFrameSize, Vector2 position, Vector2 velocity,
            int collisionOffset, int type, int[,] movedata, SceneManager sm, List<Vector2> wp)
        {
            this.image = image;
            this.playerFrameSize = playerFrameSize;
            this.position = position;
            this.velocity = velocity;
            this.collisionOffset = collisionOffset;
            this.type = type;
            this.movedata = movedata;
            sceneManager = sm;
            PassWaypoint(wp);
            waypoints.Dequeue();
            this.destination = waypoints.Peek();
            Console.WriteLine(destination);
            status = State.Waiting;
        }

        public void PassWaypoint(List<Vector2> waypoint) 
        {
            foreach (Vector2 point in waypoint)
            {
                waypoints.Enqueue(new Vector2(point.X, point.Y));
            }
        }

        public float DistanceToDestination
        {
            get { return Vector2.Distance(destination, waypoints.Peek()); }
        }

        public void SetWaypoints(Queue<Vector2> waypoints)
        {
            foreach (Vector2 waypoint in waypoints)
                this.waypoints.Enqueue(waypoint);

            this.destination = this.waypoints.Dequeue();
        }

        public override void Update(GameTime gameTime)
        {
            //Console.WriteLine(status);
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            switch (status)
            {

                case State.Waiting:
                    {
                        if (position.X == destination.X && position.Y != destination.Y)
                        {
                            if (destination.Y > position.Y)
                            {
                                direction = 0; //down
                                status = State.MoveDown;
                                //Console.WriteLine("What is here!");
                                //position = destination;
                                walking = true;
                                keepmoving = true;
                            }
                            else
                            {
                                direction = 3; //up
                                status = State.MoveUp;
                                //position = destination;
                                walking = true;
                                keepmoving = true;
                            }
                        }
                        else if (position.Y == destination.Y && position.X != destination.X)
                        {
                            if (destination.X > position.X)
                            {
                                direction = 2; //right
                                status = State.MoveRight;
                                //position = destination;
                                walking = true;
                                keepmoving = true;
                            }
                            else
                            {
                                direction = 1; //left
                                status = State.MoveLeft;
                                //position = destination;
                                walking = true;
                                keepmoving = true;
                            }
                        }
                        else if (position.X == destination.X && position.Y == destination.Y)
                        {
                            if (waypoints.Count > 0)
                            {
                                destination = waypoints.Dequeue();
                            }
                            status = State.Waiting;
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
                            if (movedata[(int)(((position.Y - 1) / 48) % 16), (int)((position.X / 48) % 16)] == 0 && keepmoving)
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
                            if (movedata[(int)(((position.Y) / 48) % 16), (int)(((position.X - 1) / 48) % 16)] == 0 && keepmoving)
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

                //case State.MoveRight:
                //    {
                //        if (walking)
                //        {
                //            if (keepmoving)
                //            {
                //                position.X += 4;
                //                if (timer > 100f)
                //                {
                //                    curFrame++;
                //                    timer = 0f;
                //                }
                //                if (curFrame == 4)
                //                {
                //                    curFrame = 0;
                //                }

                //                //keepmoving = false;
                //                //walking = false;
                //                status = State.Waiting;

                //            }
                //        }
                //        break;
                //    }
                //case State.MoveDown:
                //    {
                //        if (walking)
                //        {
                //            if (keepmoving)
                //            {
                //                position.Y += 4;
                //                if (timer > 100f)
                //                {
                //                    curFrame++;
                //                    timer = 0f;
                //                }
                //                if (curFrame == 4)
                //                {
                //                    curFrame = 0;
                //                }

                //                //keepmoving = false;
                //                //walking = false;
                //                //Console.WriteLine("8TESSSSSSSST");
                //                status = State.Waiting;

                //            }
                //        }
                //        break;
                //    }
                //case State.MoveUp:
                //    {
                //        if (walking)
                //        {
                //            if (keepmoving)
                //            {
                //                position.Y -= 4;
                //                keepmoving = true;
                //                if (timer > 100f)
                //                {
                //                    curFrame++;
                //                    timer = 0f;
                //                }
                //                if (curFrame == 4)
                //                {
                //                    curFrame = 0;
                //                }
                              
                //                //keepmoving = false;
                //                //walking = false;
                //                status = State.Waiting;
                                
                //            }
                //        }
                //        break;
                //    }
                //case State.MoveLeft:
                //    {
                //        if (walking)
                //        {
                //            if (keepmoving)
                //            {
                //                position.X -= 4;
                //                keepmoving = true;
                //                if (timer > 100f)
                //                {
                //                    curFrame++;
                //                    timer = 0f;
                //                }
                //                if (curFrame == 4)
                //                {
                //                    curFrame = 0;
                //                }
                             
                //                //keepmoving = false;
                //                //walking = false;
                //                status = State.Waiting;
                //            }
               
                //        }
                //        break;
                //    }
            }

            

            //if (waypoints.Count > 0)
            //{
            //    destination = waypoints.Dequeue();
            //    if (DistanceToDestination < 1f)
            //    {
            //        destination = waypoints.Peek();
            //        Console.WriteLine(waypoints.Count);
            //        destination = waypoints.Dequeue();
            //    }

            //    else
            //    {
            //        Vector2 newDirection = waypoints.Peek() - destination;
            //        newDirection.Normalize();

            //        velocity = Vector2.Multiply(newDirection, speed);

            //        destination = newDirection;
            //        destination += velocity;
            //    }
            //}

            if (position.X == 624 && position.Y == 144)
            {
                sceneManager.removeScene(sceneManager.currentScene);
                destination = new Vector2(32 * 3, 32 * 3);
            }

        }
    }
}
