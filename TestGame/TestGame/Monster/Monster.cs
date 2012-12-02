using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestGame
{
    public delegate void MonsterLevelUpDelegate(Monster monster);
    class Monster
    {
        private Array poop;
        private Traits _type;
        private int hunger;
        private string _name;
        private string _classID;
        private byte _level;
        private int _experience;
        private string _raceID;
        private short _baseHP;
        private short _curHP;
        private byte _diseaseResistance;
        private byte _poisonResistance;
        private byte _magicResistance;
        //Affects is empty for these

        private List<Damager> _damageResistances;
        private List<Damager> _damageWeaknesses;
        //Any misc, offensive, or defensive bonuses (ie. spells cast on character, items, etc. May be positive or negative)
        
        private List<Bonus> _defBonuses;
        private List<Bonus> _offBonuses;
        private List<Bonus> _miscBonuses;


        private Dictionary<int, int> _skills;

        //used for things like hiding and spells
        private Object _target;

        private Dictionary<int, MonsterSpell> _spells;
        private Dictionary<int, int> _spellbook; //key is spell ID, value is the page it's on

        private int _baseMana;
        private int _curMana;
        private bool _inCombat;
        private Inventory _inventory; //list of items, for a vendor this is what he sells

        private float _maxWeight;

        // private AttackTypes _selectedAttack;


        public Traits Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string Name
        {
            get { return _name; }
            set { if (!string.IsNullOrEmpty(value)) _name = value; }
        }
        public string ClassID
        {
            get { return _classID; }
            set { _classID = value; }
        }
        public Byte Level
        {
            get { return _level; }
            set
            {
                if (_type > Traits.Character)
                    _level = value;
            }
        }
        public int Experience
        {
            get { return _experience; }
            set
            {
                if (_type > Traits.Character)
                    _experience = value;
            }
        }
        public short BaseHP
        {
            get { return _baseHP; }
            set
            {
                if (_type > Traits.Character)
                    _baseHP = value;
            }
        }
        public short CurHP
        {
            get { return _curHP; }
            set
            {
                if (_type > Traits.Character)
                    _curHP = value;
            }
        }
        public Byte DiseaseResistance
        {
            get { return _diseaseResistance; }
            set { _diseaseResistance = value; }
        }
        public Byte PoisonResistance
        {
            get { return _poisonResistance; }
            set { _poisonResistance = value; }
        }
        public Byte MagicResistance
        {
            get { return _magicResistance; }
            set { _magicResistance = value; }
        }
        public List<Damager> DamageResistances
        {
            get { return _damageResistances; }
            set { _damageResistances = value; }
        }
        public List<Damager> DamageWeaknesses
        {
            get { return _damageWeaknesses; }
            set { _damageWeaknesses = value; }
        }
        public List<Bonus> DefensiveBonuses
        {
            get { return _defBonuses; }
            set { _defBonuses = value; }
        }
        public List<Bonus> OffensiveBonuses
        {
            get { return _offBonuses; }
            set { _offBonuses = value; }
        }
        public List<Bonus> MiscBonuses
        {
            get { return _miscBonuses; }
            set { _miscBonuses = value; }
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


        public Dictionary<int, int> Skills
        {
            get { return _skills; }
            set { _skills = value; }
        }


        public object Target
        {
            get { return _target; }
            set { _target = value; }
        }
        public Dictionary<int, MonsterSpell> Spells
        {
            get { return _spells; }
            set { _spells = value; }
        }
        public int BaseMana
        {
            get { return _baseMana; }
            set { _baseMana = value; }
        }
        public int CurMana
        {
            get { return _curMana; }
            set { _curMana = value; }
        }
        public bool IsAlive
        {
            get { return _curHP > 0; }
        }
        public bool InCombat
        {
            get { return _inCombat; }
            set { _inCombat = value; }
        }

        public Inventory Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }
        public AttackTypes SelectedAttack
        {
            get { return _selectedAttack; }
            set { _selectedAttack = value; }
        }



        public Monster()
        {
            _stats = new List<MonsterStat>();
        }
        #region Bonus, Resistance, Weakness Functions
        public short GetTotalOffBonus()
        {
            short total = 0;
            Bonus bns;
            if (_offBonuses != null)
            {
                for (short i = 0; i < _offBonuses.Count; i++)
                {
                    bns = (Bonus)_offBonuses[i];
                    total += bns.Amount;
                }
            }
            return total;
        }
        public short GetTotalMiscBonus()
        {
            short total = 0;
            Bonus bns;
            if (_miscBonuses != null)
            {
                for (short i = 0; i < _miscBonuses.Count; i++)
                {
                    bns = (Bonus)_miscBonuses[i];
                    total += bns.Amount;
                }
            }
            return total;
        }
        public short GetTotalDefBonus()
        {
            short total = 0;
            Bonus bns;
            if (_defBonuses != null)
            {
                for (short i = 0; i < _defBonuses.Count; i++)
                {
                    bns = (Bonus)_defBonuses[i];
                    total += bns.Amount;
                }
            }
            return total;
        }
        public void AddDefensiveBonus(Bonus bonus)
        {
            if (_defBonuses == null)
                _defBonuses = new List<Bonus>();
            _defBonuses.Add(bonus);
        }
        public void SetDefensiveBonuses(List<Bonus> bonuses)
        {
            _defBonuses = new List<Bonus>();
            if (bonuses != null)
            {
                foreach (Bonus bonus in bonuses)
                    _defBonuses.Add(bonus);
            }
        }
        public void AddOffensiveBonus(Bonus bonus)
        {
            if (_offBonuses == null)
                _offBonuses = new List<Bonus>();
            _offBonuses.Add(bonus);
        }
        public void SetOffensiveBonuses(List<Bonus> bonuses)
        {
            _offBonuses = new List<Bonus>();
            if (bonuses != null)
            {
                foreach (Bonus bonus in bonuses)
                    _offBonuses.Add(bonus);
            }
        }
        public void AddMiscBonus(Bonus bonus)
        {
            if (_miscBonuses == null)
                _miscBonuses = new List<Bonus>();
            _miscBonuses.Add(bonus);
        }
        public void SetMiscBonuses(List<Bonus> bonuses)
        {
            _miscBonuses = new List<Bonus>();
            if (bonuses != null)
            {
                foreach (Bonus bonus in bonuses)
                    _miscBonuses.Add(bonus);
            }
        }
        public void AddDamageResistance(Damager resistance)
        {
            if (_damageResistances == null)
                _damageResistances = new List<Damager>();
            _damageResistances.Add(resistance);
        }
        public void SetDamageResistances(List<Damager> resistances)
        {
            _damageResistances = new List<Damager>();
            if (resistances != null)
            {
                foreach (Damager resistance in resistances)
                    _damageResistances.Add(resistance);
            }
        }
        public void AddDamageWeakness(Damager weakness)
        {
            if (_damageWeaknesses == null)
                _damageWeaknesses = new List<Damager>();
            _damageWeaknesses.Add(weakness);
        }
        public void SetDamageWeaknesses(List<Damager> weaknesses)
        {
            _damageWeaknesses = new List<Damager>();
            if (weaknesses != null)
            {
                foreach (Damager weakness in weaknesses)
                    _damageWeaknesses.Add(weakness);
            }
        }
        #endregion
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
        public void AddSkill(int id, int ranks)
        {
            if (_skills == null)
                _skills = new Dictionary<int, int>();
            _skills.Add(id, ranks);
        }
        public void SetSkills(Dictionary<int, int> skills)
        {
            _skills = skills;
        }
        public bool HasSkill(int key)
        {
            if (_skills != null)
                return _skills.ContainsKey(key);
            else
                return false;
        }
        public void Damage(int amount, DamageType type)
        {
            //reduce amount based on damagetype protection
            foreach (Damager damager in _damageResistances)
            {
                if (damager.Type == type)
                    amount -= GlobalFunctions.GetRangeAmount(damager.DamageAmount);
            }
            _curHP -= (short)amount;
            if (_curHP <= 0)
            {
                //Monster is dead
            }
        }

        public void UseSkill(int key, Difficulty difficulty)
        {
            int result = 0;
            Monster Monster = this;
            if (GlobalData.Skills[key].Use(ref _target, ref Monster, difficulty, ref result))
            {
                switch (GlobalData.Skills[key].Type)
                {
                    case SkillType.Defensive:
                        {
                            if (_target is Monster)
                            {
                            }
                            break;
                        }
                    case SkillType.NonCombat:
                        {
                            if (_target is Monster)
                            {
                            }
                            break;
                        }
                    case SkillType.Offensive:
                        {
                            if (_target is Monster)
                            {
                            }

                            break;
                        }
                }
            }
        }
        public int GetSkillValueByID(int id)
        {
            if (HasSkillByID(id))
                return GlobalFunctions.CalculateSkillBonus(_skills[id]);
            else
                return 0;
        }

        public bool HasSkillByID(int id)
        {
            foreach (int key in _skills.Keys)
                if (key == id)
                    return true;
            return false;
        }
        public int GetCastingSkillBonus()
        {
            int amount = 0;
            foreach (int id in _skills.Keys)
            {
                //TODO: copy function from backup
                if (GlobalData.Skills[id].Name == "Spellcraft")
                {
                    amount = _skills[id];
                    break;
                }
            }

            return amount;
        }


        public bool LearnSpell(int id, int skillPointsAllocated)
        {
            bool hasSpellcraftSkill = false;
            foreach (int key in _skills.Keys)
            {
                //TODO: copy function from backup
                if (GlobalData.Skills[key].Name == "Spellcraft")
                {
                    hasSpellcraftSkill = true;
                    break;
                }
            }
            if (!hasSpellcraftSkill)
                return false;
            _spells[id].AllocatePoints(skillPointsAllocated);

            //get any bonuses for learning spells
            int amount = 0;

            return _spells[id].Learn(amount);
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


        public bool HasItem(int id)
        {
            foreach (MonsterItem item in _inventory.Items)
            {
                if (item.ID == id)
                    return true;
            }
            return false;
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
        public void SetAttackType(AttackTypes type)
        {
            _selectedAttack = type;
        }
    }
}
