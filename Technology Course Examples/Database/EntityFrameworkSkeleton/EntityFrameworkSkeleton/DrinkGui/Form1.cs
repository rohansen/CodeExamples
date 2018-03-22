using DataAccessLayer.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using BusinessLogicLayer.Models;

namespace DrinkGui
{
    public partial class Form1 : Form
    {
        private readonly DrinkSystemContext _db = new DrinkSystemContext();
        public Form1()
        {
            InitializeComponent();
            InitializeCustom();

        }

        private void txtSaveIngredient_Click(object sender, EventArgs e)
        {
            Ingredient ingredient = new Ingredient { Name = txtIngredientName.Text };
            _db.Ingredients.Add(ingredient);
            _db.SaveChanges();
            txtIngredientName.Text = "";
            RefreshIngredientBox();
        }

        private void RefreshIngredientBox()
        {
            lbIngredients.Items.Clear();
            var ingredients = _db.Ingredients.ToList();
            foreach (var item in ingredients)
            {
                lbIngredients.Items.Add(item);
            }

        }
        private void RefreshDrinkBox(List<Drink> drinks = null)
        {
            lbDrinks.Items.Clear();

            var drinksToAdd = drinks ?? _db.Drinks.Include(x => x.Ingredients).ToList();

            foreach (var item in drinksToAdd)
            {
                lbDrinks.Items.Add(item);
            }

        }

        private void InitializeCustom()
        {
            lbIngredients.DisplayMember = "Name";
            lbIngredients.ValueMember = "Id";
            lbDrinks.DisplayMember = "Name";
            lbDrinks.ValueMember = "Id";
            RefreshIngredientBox();
            RefreshDrinkBox();
        }

        private void btnCreateDrink_Click(object sender, EventArgs e)
        {
            if (txtDrinkName.Text == "")
            {
                MessageBox.Show(this, "Error", "Enter text", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var drink = new Drink { Name = txtDrinkName.Text };
            foreach (var selectedItem in lbIngredients.SelectedItems)
            {
                drink.Ingredients.Add(selectedItem as Ingredient);
            }
            _db.Drinks.Add(drink);
            _db.SaveChanges();
            RefreshDrinkBox();
        }

        private void DrinksMouseClick(object sender, MouseEventArgs e)
        {
            var lb = sender as ListBox;
            if (lb?.SelectedItem == null) return;


            var drink = (Drink)lb.SelectedItem;
            var ingredientList = "";
            foreach (var ing in drink.Ingredients)
            {
                ingredientList += ing.Name + Environment.NewLine;
            }
            MessageBox.Show(drink.Name + Environment.NewLine + ingredientList);
        }

        private void txtFindDrink_Click(object sender, EventArgs e)
        {

            List<Drink> foundDrinks;
            if (txtDrinkSearch.Text == "")
            {
                foundDrinks = _db.Drinks.ToList();
            }
            else
            {
                foundDrinks = _db.Drinks.Where(x =>
                    x.Name.ToLower().Contains(txtDrinkSearch.Text.ToLower()) ||
                        x.Ingredients.Select(y => y.Name.ToLower())
                        .Any(y => y.Contains(txtDrinkSearch.Text.ToLower())))
                        .ToList();
            }

            RefreshDrinkBox(foundDrinks);
        }

        private void btnDeleteDrink_Click(object sender, EventArgs e)
        {
            _db.Drinks.Remove(lbDrinks.SelectedItem as Drink);
            _db.SaveChanges();
            RefreshDrinkBox();
            RefreshIngredientBox();
        }

        private void DrinksSingleClick(object sender, MouseEventArgs e)
        {
            var lb = sender as ListBox;
            if (lb?.SelectedItem == null) return;

            Drink drink = (Drink)lb.SelectedItem;
            txtDrinkName.Text = drink.Name;
            btnUpdateDrink.Enabled = txtDrinkName.Text != drink.Name;
        }

        private void DrinkNameKeyUp(object sender, KeyEventArgs e)
        {
            var drink = lbDrinks.SelectedItem as Drink;

            if (drink != null && txtDrinkName.Text != drink.Name)
            {
                btnUpdateDrink.Enabled = true;
            }
            else
            {
                btnUpdateDrink.Enabled = false;
            }

        }

        private void btnUpdateDrink_Click(object sender, EventArgs e)
        {
            if (lbDrinks.SelectedItem == null) return;


            var drink = (Drink)lbDrinks.SelectedItem;
            _db.Drinks.Attach(drink);
            drink.Name = txtDrinkName.Text;
            _db.SaveChanges();
            RefreshDrinkBox();
        }

    }
}
