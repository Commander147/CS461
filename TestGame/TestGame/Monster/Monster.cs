using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestGame
{
    class Monster
    {
        private int hunger;
        private int thurst;
        private string _name;
        private byte _level;
        private float _curHP = 100.00;
        private float _maxWeight;

        public float CurHP
        {
            get { return _curHP; }
            set
            {
                if (_type > Traits.Character)
                    _curHP = value;
            }
        }
        

        public short Age
        {
            get { return _age; }
            set { _age = value; }
        }
        public string RaceID
        {
            get { return _raceID; }
            set { _raceID = value; }
        }
        public List<MonsterStat> Stats
        {
            get { return _stats; }
            set { _stats = value; }
        }


        
        public bool IsAlive
        {
            get { return _curHP > 0; }
        }
        

        public Monster()
        {
            _stats = new List<MonsterStat>();
        }
        
        public int MaxWeight()
        {
            int str = 0;
            //find the strength stat
            foreach (MonsterStat stat in _stats)
            {
                if (stat.StatName.ToLower() == "strength")
                {
                    str = stat.CurrentValue;
                    break;
                }
            }
            return str * 3;
        }
        
        public List<MonsterSpell> GetPageSpells(int page)
        {
            List<MonsterSpell> spells = new List<MonsterSpell>();
            foreach (int key in _spellbook.Keys)
            {
                if (_spellbook[key] == page)
                    spells.Add(_spells[key]);
            }
            return spells;
        }

        public void MoveSpell(int id, int page)
        {
            //check to see if page has an empty spot
            int count = 0;
            foreach (int key in _spellbook.Keys)
            {
                if (_spellbook[key] == page)
                    count++;
            }
            if (count < Spell.SpellsPerPage)
                _spellbook[id] = page;
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
