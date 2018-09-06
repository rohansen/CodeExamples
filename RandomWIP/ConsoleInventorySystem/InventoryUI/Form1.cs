using ConsoleInventorySystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryUI
{
    public partial class Form1 : Form
    {
        private List<Consumable> consumables = new List<Consumable>();
        private List<Weapon> weapons = new List<Weapon>();
        private static Player player;
        public Form1()
        {
            InitializeComponent();
            GenerateItems();
            LoadItemsIntoGUI();
            player = new Player(100, textBox1);
        }

       

        private void LoadItemsIntoGUI()
        {
            foreach (var item in consumables)
            {
                lbConsumables.Items.Add(item);
            }
            foreach (var item in weapons)
            {
                lbWeapons.Items.Add(item);
            }
        }

        private void GenerateItems()
        {
            BroadSword bs = new BroadSword("Sword of broad something", 50);
            BroadSword bs1 = new BroadSword("Sword of horses", 50);
            BroadSword bs2 = new BroadSword("Sword of cheese", 50);
            Juice j1 = new Juice("Grape Juice", 35);
            Juice j2 = new Juice("Jug o' Juice", 75);
            Juice j3 = new Juice("Vodka Juice", 45);
            Juice j4 = new Juice("Smurf Juice", 10);
            consumables.AddRange(new Consumable[] { j1, j2,j3,j4 });
            weapons.AddRange(new Weapon[] { bs, bs1, bs2 });
        }

        private void PickupItem_click(object sender, EventArgs e)
        {
            if (lbWeapons.SelectedItem!=null)
            {
                player.Inventory.InventoryItems.Add(lbWeapons.SelectedItem as Weapon);
                lbInventory.Items.Add(lbWeapons.SelectedItem as Weapon);
                lbWeapons.Items.Remove(lbWeapons.SelectedItem);
            }else if (lbConsumables.SelectedItem!=null)
            {
                player.Inventory.InventoryItems.Add(lbWeapons.SelectedItem as Consumable);
                lbInventory.Items.Add(lbConsumables.SelectedItem as Consumable);
                lbConsumables.Items.Remove(lbConsumables.SelectedItem);
            }
        }

  
        private void ConsumableFocused(object sender, EventArgs e)
        {
            lbWeapons.SelectedItem = null;
        }

        private void WeaponFocused(object sender, EventArgs e)
        {
            lbConsumables.SelectedItem = null;
        }

        private void DropItem_click(object sender, EventArgs e)
        {
            if (lbInventory.SelectedItem != null) {
                Item selectedItem = lbInventory.SelectedItem as Item;
                player.Inventory.InventoryItems.Remove(selectedItem);
                lbInventory.Items.Remove(lbInventory.SelectedItem);
                if(selectedItem is Consumable)
                {
                    lbConsumables.Items.Add(selectedItem);
                }else if (selectedItem is Weapon)
                {
                    lbWeapons.Items.Add(selectedItem);
                }
            }
        }

        private void Eat_click(object sender, EventArgs e)
        {
            if (lbInventory.SelectedItem != null && lbInventory.SelectedItem is Consumable)
            {
                ((Consumable)lbInventory.SelectedItem).Consume(player);
                lblHealth.Text = "Health: " + player.Hitpoints;
                lbInventory.Items.Remove(lbInventory.SelectedItem);
            }else
            {
                MessageBox.Show("You cannot eat that!");
            }
        }

        private void CutYourself_click(object sender, EventArgs e)
        {
            if (lbInventory.SelectedItem != null && lbInventory.SelectedItem is Weapon)
            {
                ((Weapon)lbInventory.SelectedItem).Attack(player);
                lblHealth.Text = "Health: " + player.Hitpoints;
            }
        }
    }
}
