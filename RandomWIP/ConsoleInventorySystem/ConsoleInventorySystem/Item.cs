using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInventorySystem
{

    /*
     * -----Part 1
     *  0. Listen carefully to the inheritance lecture, and explanation of this exercise!
        1. Create an Empty solution
        2. Create a Class Library (GameLogic)
        3. Create a Console application (TextGUI)
        4. Create a reference from your Console application to your Class Library
        5. Implement the classes from the diagram that is sorrounded by the RED line in the class library
        5.1 Juice --> Inherits from abstract class Consumable. Consumable inherits from abstract class Item
        5.1.0 Create a Player class, that contains the properties IsAlive and Hitpoints. Also, Create an Inventory class, and give the Player class a reference to a Inventory. The Inventory class should contain a List<Item>'s as a property; remember to instantiate it in the Invetory constructor
        5.1.0.0 Create a constructor on the Player class that accepts hitpoints, and set the Hitpoints property value inside of it, along with a new Inventory and IsAlive = true;
        5.1.1 Let the abstract class Item contain the string property "Title" --> Let the constructor accept a string title, and set the property
        5.1.2 Let the abstract class Consumable contain an abstract method Consume that accepts an input of type Player; in the Consumable class, remember to call the base class constructor, and pass along the title to the superclass
        5.2 Let the concrete class Juice inherit from the abstract class Consumable. Create a field on consumable that contains the amount of hitpoints it restores.
        5.2.2 Remember to set the field value in the constructor, along with the input parameters that you need to send along to the superclass. Implement the abstract method Consume(you could do a Console.WriteLine("I ate something");
        6 Create another class that inherits from Consumable called Bread; set it up as you did with the Juice class
        7. In your Program.cs, instantiate a new Player. Instantiate some "Juice" and "Bread" instances to the Players Inventory List<>
        8. Look through the Players Inventory List, Print the Items title. In your loop, use the "is" operator, to check if the current item is Juice. If it is, drink it.
        -----End of part 1
        -----Part 2
        1. Expand your program by implementing new types of items. You currently have Consumables; how about implementing Weapons. You can do this by creating an abstract Weapon class and inherit from Item
        2. When you have created Weapon as you did with the Consumable class, you can create two concrete weapons: eg. a BroadSword and a Katana. You do this by creating concrete classes and inheriting from Weapon.
        3. Implement the abstract method Attack(Player playerToAttack), and decrement the Health of the input player.
        4. Go back to your Program.cs, and add your new Weapons to the inventory List
        5. Loop through it, and see that you inventory can contain everything that is an Item.
        6. If you want, you can check if the current loop iteration Item is a Weapon, if it is, type cast it to Weapon and run the .Attack method on it.
        -----End part 2
        -----Start part 3
        1. Expand your program with generalized behavior using interfaces.
        2. Implement a IPlayer interface with two methods, Die() and Respawn(). Furthermore, try and implement your properties IsAlive and Hitpoints here. This means that all IPlayers needs to have Hitpoints and an Alive status
        3. Let your player class implement this interface, and implement the methods
        4. Implement a IDamagable interface, and let your Player Implement it. you COULD also let the IPlayer interface inherit from the IDamagable interface. That is up to you
        4.1 On the IDamagable interface, create the method TakeDamage(int amount)
        4.2 Implement the TakeDamage method on your Player, and decrement the Health he has.
        4.3 Notice that ANY type that implements the IDamagable interface, now can take damage, and work in any context we set up
        4.4 Now you can finally look though you implementation and find the places where you use a concrete player as Input to methods, and change this to IDamagable. This loosens coupling 
        -----End part 3
        -----Part 4 - Freestyle
        1. Try and continue developing your Inventory system by creating the IHealable interface
        2. You could also implement a IPickup interface, and let your Item (or something else) implement it, such that "things" can be picked up.
        3. Ask questions, thats why im here ! :)

    */
    public interface IPlayer : IDamagable, IHealable
    {
        int Hitpoints { get; set; }
        bool IsAlive { get; set; }
        void Respawn();
        void Die();
    }

    public interface IDamagable
    {
        void TakeDamage(int amount);
    }

    public interface IHealable
    {
        void Heal(int amount);
    }

    public class Player : IPlayer
    {
        public bool IsAlive { get; set; }
        public int Hitpoints { get; set; }
        public Inventory Inventory { get; private set; }
        public Player(int hitPoints)
        {
            Inventory = new Inventory();
            Hitpoints = hitPoints;
            IsAlive = true;
        }

        public void TakeDamage(int amount)
        {
            Hitpoints -= amount;
            Console.WriteLine($"You took {amount} damage ({Hitpoints} left)");
        }

        public void Heal(int amount)
        {
            Hitpoints += amount;
            Console.WriteLine($"You healed for {amount} hitpoints ({Hitpoints} left)");
        }

        public void Respawn()
        {
            IsAlive = true;
            Console.WriteLine("You are alive again");
        }

        public void Die()
        {
            IsAlive = false;
            Console.WriteLine("You are dead");
        }
    }
    
    public class Inventory
    {
        public List<Item> InventoryItems { get; private set; }
        public Inventory()
        {
            InventoryItems = new List<Item>();
        }

    }

    public abstract class Item
    {
        public string Title { get; private set; }
        public Item(string title)
        {
            Title = title;
        }

    }
    
    public abstract class Weapon : Item
    {
        public int Damage { get; private set; }
        public Weapon(string title, int damage) : base(title)
        {
            Damage = damage;
        }

        public void Attack(IDamagable damagable)
        {
            
            
            if(damagable is IPlayer)
            {
                var player = damagable as IPlayer;
                if (!player.IsAlive) return;
                damagable.TakeDamage(Damage);
              
                if (player.Hitpoints<=0)
                {
                    player.Die();
                }
                
            }
        }
    }
    
    public class BroadSword : Weapon
    {
        public BroadSword(string title, int damage) : base(title, damage)
        {

        }

    }

    public abstract class Consumable : Item
    {
        public Consumable(string title) : base(title)
        {

        }
        public abstract void Consume(IHealable whoConsumesIt);
    }
    
    public class Juice : Consumable
    {
        private int _restoresHitpointAmount;
        public Juice(string title, int restoredHitpointAmount) : base(title)
        {
            _restoresHitpointAmount = restoredHitpointAmount;
        }

        public override void Consume(IHealable whoConsumesIt)
        {
            whoConsumesIt.Heal(_restoresHitpointAmount);
        }
    }
}
