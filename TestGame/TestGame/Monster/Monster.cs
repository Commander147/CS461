using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace TestGame
{
    class Monster
    {
        private MonsterStatus stats;
        private Sprite sprite;
        private TaskManager TM = new TaskManager();
        private SpriteManager SM;
        Task currenttask;

        public Monster(MonsterStatus stats, ref Human sprite, SpriteManager sm)
        {
            this.stats = stats;
            this.sprite = sprite;
            this.SM = sm;
            currenttask = new Task(Task.Type.Poop,null);
            currenttask.status = Task.Status.Done;
        }

        public Monster(MonsterStatus stats, Sprite sprite, SpriteManager sm)
        {
            this.stats = stats;
            this.sprite = sprite;
            this.SM = sm;
            currenttask = new Task(Task.Type.Poop, null);
            currenttask.status = Task.Status.Done;
        }

        public void Update(GameTime gametime)
        {
            if (TM.taskIsEmpty() == false)
            {
                if (currenttask.status == Task.Status.Done)
                {
                    currenttask = TM.GetTask();
                }

                switch (currenttask.type)
                {
                    case Task.Type.Poop:
                        {
                            ExePoop(currenttask.paramaters);
                            currenttask.status = Task.Status.Done;
                            TM.RemoveTask();
                            break;
                        }
                    case Task.Type.Move:
                        {
                            if (currenttask.status == Task.Status.Exe)
                            {
                                if (sprite.position == (Vector2)currenttask.paramaters[0])
                                {
                                    currenttask.status = Task.Status.Done;
                                }
                            }
                            else if (currenttask.status == Task.Status.Done)
                            {
                                TM.RemoveTask();
                            }
                            else
                            {
                                currenttask.status = Task.Status.Exe;
                                ExeMove(currenttask.paramaters);
                            }
                            break;
                        }
                }
            }
            else
            {
                //Console.WriteLine("Waiting for task");
            }
        }

        public bool isAlive()
        {
            return stats.hp > 0;
        }

        public void Poop()
        {
            if (stats.hp <= 30 && stats.Thirst <= 40)
            {
                ArrayList paramaters = new ArrayList();
                Console.WriteLine(sprite.position);
                paramaters.Add(sprite.position);
                TM.AddTask(new Task(Task.Type.Poop, paramaters));
            }
        }

        private void ExePoop(ArrayList paramaters)
        {
            SM.AddSprite(new Poop((Vector2)paramaters[0]));
        }

        public void Move(ArrayList paramaters)
        {
            TM.AddTask(new Task(Task.Type.Move, paramaters));
        }

        private void ExeMove(ArrayList paramaters)
        {

        }

    }
}
