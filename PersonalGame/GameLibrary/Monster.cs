using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    public class Monster : Character
    {
        private int _minDamage;
        public int MaxDamage { get; set; }
        public string Description { get; set; }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                _minDamage = value > 0 && value <= MaxDamage ? value : 1;

            }//end set
        }//end minDamage

        public Monster(string name, int maxLife, int life, int hitChance, int block, int minDamage, int maxDamage, string description)
            : base(name, maxLife, life, hitChance, block)
        {
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Description = description;
        }//end FQCTOR

        public override string ToString()
        {
            return string.Format($"{Name}\n{Description}\nLife Remaining: {Life}");
        }//end ToString()

        public override int CalcDamage()
        {
            return new Random().Next(MinDamage, MaxDamage + 1);
        }//end CalcDamage()

    }//end class
}//end namespace
