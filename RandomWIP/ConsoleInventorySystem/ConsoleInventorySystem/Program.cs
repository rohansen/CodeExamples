using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInventorySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Player p1 = new Player(100);
            BroadSword bs = new BroadSword("Sword of a thousand truths",45);
            Juice juice = new Juice("Juice of the hero",25);
            p1.Inventory.InventoryItems.Add(bs);
            p1.Inventory.InventoryItems.Add(juice);

            foreach (Item item in p1.Inventory.InventoryItems)
            {
              
                if(item is Weapon)
                {
                    var weap = item as Weapon;
                    weap.Attack(p1);
                    weap.Attack(p1);
                }
                if(item is Consumable)
                {
                    var cons = item as Consumable;
                    cons.Consume(p1);
                }
            }


        }
    }
}
