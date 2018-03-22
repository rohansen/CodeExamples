using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
  
    public class MissileAttackEncapsulated
    {
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public DateTime AttackDate { get; private set; }
        public double GRAVITATIONAL_ACCELERATION { get; private set; }
        public MissileType MissileType { get; private set; }
        public PersonelRank Rank { get; private set; }

        public MissileAttackEncapsulated(double latitude, double longitude, DateTime when, PersonelRank rank, MissileType type)
        {
            GRAVITATIONAL_ACCELERATION = 9.8;
            Latitude = latitude;
            Longitude = longitude;
            AttackDate = when;
            Rank = rank;
            if (type == MissileType.Nuclear && rank != PersonelRank.CommanderInChief)
                throw new Exception("Only the president can issue this order");
            MissileType = type;

        }

        public void ExecuteAttack()
        {
            Console.WriteLine("Shooting {0} weapon at lat:{1} lon:{2} by order from {3}", MissileType.ToString(), Latitude.ToString(), Longitude.ToString(), Rank.ToString());
            //Fire missiles
        }
    }
}
