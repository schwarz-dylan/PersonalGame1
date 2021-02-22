using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    public class Dragon : Monster
    {
        public bool IsAncient { get; set; }

        public Dragon(string name, int maxLife, int life, int hitChance, int block, int minDamage, int maxDamage, string description, bool isAncient) : base(name, maxLife, life, hitChance, block, minDamage, maxDamage, description)
        {
            IsAncient = isAncient;
        }//end FQCTOR

        public override int CalcBlock()
        {
            int calculatedBlock = Block;

            if (IsAncient)
            {
                calculatedBlock += calculatedBlock / 2;
            }//end if

            return calculatedBlock;
        }//



    }//end class
}//end namespace
