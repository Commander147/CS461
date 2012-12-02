using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace TestGame
{
    class Monster
    {
        private int _hunger;
        private int _thurst;
        private string _name;
        private int _level = 1;
        private double _curHP = 100.0;
        private List<Monster> _stats = new List<Monster>();

#region hunger, thurst, name, level, and HP
        public double CurHP
        {
            get { return _curHP; }
            set { _curHP = value;}
        }
        public int Thurst
        {
            get { return _thurst; }
            set { _thurst = value; }
        }
        public int Hunger
        {
            get { return _hunger; }
            set { _hunger = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }
        public List<Monster> Stats
        {
            get { return _stats; }
            set { _stats = value; }
        }
#endregion

        public Monster()
        {
                  
             TaskManager Tasks = new TaskManager();
        }
        public ArrayList Status_Add
        {
           ArrayList status = new ArrayList();

        }
        public bool IsAlive
        {
            get { return _curHP > 0; }
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
