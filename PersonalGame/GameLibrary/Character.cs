using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    public abstract class Character
    {

        private string _name;
        private int _life;



        public int MaxLife { get; set; }
        public int HitChance { get; set; }
        public int Block { get; set; }


        public string Name
        {
            get { return _name; }
            set
            {
                _name = value.Length > 0 ? value : "Stranger"; //turnary operator
            }//end set
        }//end name


        public int Life
        {
            get { return _life; }
            set
            {
                _life = value <= MaxLife ? value : MaxLife;            //Turnary operator and business rule

                //if (value <= MaxLife)
                //{
                //    _life = value;
                //}//end if
                //else
                //{
                //    _life = MaxLife;
                //}//end else
            }//end set


        }//end Life

        public Character () { }

        public Character(string name, int maxLife, int life, int hitChance, int block)
        {
            Name = name;
            MaxLife = maxLife;
            Life = life;
            HitChance = hitChance;
            Block = block;
        }

        public virtual int CalcBlock()
        {
            return Block;
        }

        public virtual int CalcHitChance()
        {
            return HitChance;
        }

        public virtual int CalcDamage()
        {
            return 0;
        }


    }//end class
}//end namespace
