using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace TestGame
{
    
    public class MonsterStats{
        
        public int hunger {
            set {hunger = value;}
            get {return hunger;}
        };
        public int thirst{
            set {thirst = value;}
            get {return thirst;}
        };
        public int exp{
            set {exp = value;}
            get {return exp;}
        };
        public int hp{
            set {hp = value;}
            get {return hp;}
        };
        public string name{
            set {name = value;}
            get {return name;}
        };
        
        public MonsterStats(int hung,int t, int xp,int hp, string name){
            this.hunger = hung;
            this.thirst = t;
            this.exp = xp;
            this.hp = hp;
            this.name = name;
        }
    }
    
    
    class Monster
    {
        MonsterStatus Status;

        public Monster(int hung,int t, int xp,int hp, string name)
        {
             Status = new MonsterStatus(hung,t, xp,hp,name);     
             TaskManager Tasks = new TaskManager();
        }
        public ArrayList Status_Add
        {
           ArrayList status = new ArrayList();

        }
        public bool IsAlive
        {
            get { return status.hp > 0; }
        }

         //public void poop()
        //{
        //    if (Monster.hunger >= .9 && 
        //}


        //public void Update(TaskManager task)
        //{
        //    if (task.taskIsEmpty == false)
        //    {
        //        if (task.currentQueue


        //}
        
    }
}
