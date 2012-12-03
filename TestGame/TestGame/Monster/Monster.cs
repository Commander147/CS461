using System;
using System.Collections.Generic;
using System.Collections;
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
    
    class Monster
    {
        Sprite location;
        MonsterStats Status;

        public Monster(int hung,int t, int xp,int hp, string name)
        {
            Status = new MonsterStats(hung, t, xp, hp, name);     
             TaskManager Tasks = new TaskManager();
        }
        public bool IsAlive
        {
            get { return Status.hp > 0; }
        }
        public void poop()
        {
           // if (Status.hunger >= 80 && Status.thirst >= 60)
                //Tasks.
                
        }


        //public void Update(TaskManager task)
        //{
        //    if (task.taskIsEmpty == false)
        //    {
        //        if (task.currentQueue


        //}
        
    }
}
