using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
  
    public class MissileAttack
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime AttackDate { get; set; }
        public double GRAVITATIONAL_ACCELERATION { get; set; }
        public MissileType MissileType { get; set; }
        public PersonelRank Rank { get; set; }

        public MissileAttack(double latitude, double longitude, DateTime when, PersonelRank rank, MissileType type)
        {
            GRAVITATIONAL_ACCELERATION = 9.8;
            Latitude = latitude;
            Longitude = longitude;
            AttackDate = when;
            Rank = rank;
            if (type== MissileType.Nuclear && rank != PersonelRank.CommanderInChief)
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
