
using Encapsulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncapsulationConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            MissileAttack ma1 = new MissileAttack(50, 20, DateTime.Now, PersonelRank.General, MissileType.Fire);
            ma1.Rank = PersonelRank.CommanderInChief;
            ma1.MissileType = MissileType.Nuclear;
            ma1.GRAVITATIONAL_ACCELERATION = 5.0;
            ma1.ExecuteAttack();

            MissileAttackEncapsulated ma2 = new MissileAttackEncapsulated(50, 20, DateTime.Now, PersonelRank.General, MissileType.Fire);
            ma2.Rank = PersonelRank.CommanderInChief;
            ma2.MissileType = MissileType.Nuclear;
            ma2.GRAVITATIONAL_ACCELERATION = 5.0;
            ma2.ExecuteAttack();

        }
    }
}
