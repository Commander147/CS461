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
        Vector2 location;
        ArrayList location_log = new ArrayList[location];
        MonsterStatus Status;

        public Monster(int hung,int t, int xp,int hp, string name)
        {
             Status = new MonsterStatus(hung,t, xp,hp,name);     
             TaskManager Tasks = new TaskManager();
        }
        public bool IsAlive
        {
            get { return Status.hp > 0; }
        }
        public void poop()
        {
            if (Status.hunger >= 80 && Status.thirst >= 60)
                location_log 
        }


        //public void Update(TaskManager task)
        //{
        //    if (task.taskIsEmpty == false)
        //    {
        //        if (task.currentQueue


        //}
        
    }
}
