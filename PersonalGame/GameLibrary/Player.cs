using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
   public class Player : Character
   {
        public Race HeroRace { get; set; }
        public Weapon EquippedWeapon { get; set; }

        public Player() { }

        public Player(string name, int life, int maxLife, int hitChance, int block,
            Race heroRace, Weapon equippedWeapon) : base(name, life, maxLife, hitChance, block)

        {
            HeroRace = heroRace;
            EquippedWeapon = equippedWeapon;

            switch (HeroRace)
            {
                case Race.Elf:
                    HitChance += 5;
                    Life -= 5;
                    MaxLife -= 5;
                    break;
                case Race.Dwarf:
                    Block += 5;
                    Life -= 5;
                    MaxLife -= 5;
                    break;
                //case Race.Human:   //commented human out because I want Humans to have default stats.
                //    break;
                case Race.Hobbit:
                    HitChance -= 5;
                    Life += 7;
                    MaxLife += 7;
                    break;
                case Race.Orc:
                    Life -= 5;
                    MaxLife -= 5;
                    break;
                case Race.Goblin:
                    Life -= 7;
                    MaxLife -= 7;
                    break;
                case Race.Golum:
                    HitChance += 5;
                    Life += 5;
                    MaxLife += 5;
                    break;
                case Race.Smeagul:
                    HitChance -= 5;
                    Life -= 5;
                    MaxLife -= 5;
                    break;
            }


        }//end fqctor

        public override string ToString()
        {
            return string.Format("*******{0}******\nLife: {1} of {2}\n" +
                "Hit Chance: {3}%\nBlock: {4}%\nRace: {5}\nWeapon:\n{6}",
                Name,
                Life,
                MaxLife,
                CalcHitChance(),
                Block,
                HeroRace,
                EquippedWeapon);
        }//end ToString()

        public override int CalcDamage()
        {
            Random rand = new Random();

            int damage = rand.Next(EquippedWeapon.MinDamage,
                EquippedWeapon.MaxDamage + 1);

            return damage;

            //return new Random().Next(EquippedWeapon.MinDamage,
            //    EquippedWeapon.MaxDamage + 1); This is the same thing as listed above
        }//end calcDamage

        public override int CalcHitChance()
        {
            return HitChance + EquippedWeapon.BonusHitChance;
        }//end CalHitChance




    }//end class
}//end namespace
