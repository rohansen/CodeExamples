namespace DrinkGui
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSaveIngredient = new System.Windows.Forms.Button();
            this.txtIngredientName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbIngredients = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnUpdateDrink = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDrinkSearch = new System.Windows.Forms.TextBox();
            this.txtFindDrink = new System.Windows.Forms.Button();
            this.btnDeleteDrink = new System.Windows.Forms.Button();
            this.lbDrinks = new System.Windows.Forms.ListBox();
            this.txtDrinkName = new System.Windows.Forms.TextBox();
            this.btnCreateDrink = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSaveIngredient
            // 
            this.btnSaveIngredient.Location = new System.Drawing.Point(6, 74);
            this.btnSaveIngredient.Name = "btnSaveIngredient";
            this.btnSaveIngredient.Size = new System.Drawing.Size(95, 29);
            this.btnSaveIngredient.TabIndex = 0;
            this.btnSaveIngredient.Text = "Save";
            this.btnSaveIngredient.UseVisualStyleBackColor = true;
            this.btnSaveIngredient.Click += new System.EventHandler(this.txtSaveIngredient_Click);
            // 
            // txtIngredientName
            // 
            this.txtIngredientName.Location = new System.Drawing.Point(6, 46);
            this.txtIngredientName.Name = "txtIngredientName";
            this.txtIngredientName.Size = new System.Drawing.Size(226, 22);
            this.txtIngredientName.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtIngredientName);
            this.groupBox1.Controls.Add(this.btnSaveIngredient);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 258);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ingredients";
            // 
            // lbIngredients
            // 
            this.lbIngredients.FormattingEnabled = true;
            this.lbIngredients.ItemHeight = 16;
            this.lbIngredients.Location = new System.Drawing.Point(238, 46);
            this.lbIngredients.Name = "lbIngredients";
            this.lbIngredients.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbIngredients.Size = new System.Drawing.Size(120, 164);
            this.lbIngredients.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.btnUpdateDrink);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtDrinkSearch);
            this.groupBox2.Controls.Add(this.lbIngredients);
            this.groupBox2.Controls.Add(this.txtFindDrink);
            this.groupBox2.Controls.Add(this.btnDeleteDrink);
            this.groupBox2.Controls.Add(this.lbDrinks);
            this.groupBox2.Controls.Add(this.txtDrinkName);
            this.groupBox2.Controls.Add(this.btnCreateDrink);
            this.groupBox2.Location = new System.Drawing.Point(264, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(504, 258);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Drinks";
            // 
            // btnUpdateDrink
            // 
            this.btnUpdateDrink.Enabled = false;
            this.btnUpdateDrink.Location = new System.Drawing.Point(107, 74);
            this.btnUpdateDrink.Name = "btnUpdateDrink";
            this.btnUpdateDrink.Size = new System.Drawing.Size(95, 29);
            this.btnUpdateDrink.TabIndex = 12;
            this.btnUpdateDrink.Text = "Update Drink";
            this.btnUpdateDrink.UseVisualStyleBackColor = true;
            this.btnUpdateDrink.Click += new System.EventHandler(this.btnUpdateDrink_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Drink name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Drink name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(361, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Drinks";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(239, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Ingredients";
            // 
            // txtDrinkSearch
            // 
            this.txtDrinkSearch.Location = new System.Drawing.Point(6, 131);
            this.txtDrinkSearch.Name = "txtDrinkSearch";
            this.txtDrinkSearch.Size = new System.Drawing.Size(226, 22);
            this.txtDrinkSearch.TabIndex = 7;
            // 
            // txtFindDrink
            // 
            this.txtFindDrink.Location = new System.Drawing.Point(6, 159);
            this.txtFindDrink.Name = "txtFindDrink";
            this.txtFindDrink.Size = new System.Drawing.Size(95, 29);
            this.txtFindDrink.TabIndex = 6;
            this.txtFindDrink.Text = "Find drink";
            this.txtFindDrink.UseVisualStyleBackColor = true;
            this.txtFindDrink.Click += new System.EventHandler(this.txtFindDrink_Click);
            // 
            // btnDeleteDrink
            // 
            this.btnDeleteDrink.Location = new System.Drawing.Point(407, 216);
            this.btnDeleteDrink.Name = "btnDeleteDrink";
            this.btnDeleteDrink.Size = new System.Drawing.Size(77, 29);
            this.btnDeleteDrink.TabIndex = 5;
            this.btnDeleteDrink.Text = "Delete";
            this.btnDeleteDrink.UseVisualStyleBackColor = true;
            this.btnDeleteDrink.Click += new System.EventHandler(this.btnDeleteDrink_Click);
            // 
            // lbDrinks
            // 
            this.lbDrinks.FormattingEnabled = true;
            this.lbDrinks.ItemHeight = 16;
            this.lbDrinks.Location = new System.Drawing.Point(364, 46);
            this.lbDrinks.Name = "lbDrinks";
            this.lbDrinks.Size = new System.Drawing.Size(120, 164);
            this.lbDrinks.TabIndex = 4;
            this.lbDrinks.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DrinksSingleClick);
            this.lbDrinks.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DrinksMouseClick);
            // 
            // txtDrinkName
            // 
            this.txtDrinkName.Location = new System.Drawing.Point(6, 46);
            this.txtDrinkName.Name = "txtDrinkName";
            this.txtDrinkName.Size = new System.Drawing.Size(226, 22);
            this.txtDrinkName.TabIndex = 1;
            this.txtDrinkName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DrinkNameKeyUp);
            // 
            // btnCreateDrink
            // 
            this.btnCreateDrink.Location = new System.Drawing.Point(6, 74);
            this.btnCreateDrink.Name = "btnCreateDrink";
            this.btnCreateDrink.Size = new System.Drawing.Size(95, 29);
            this.btnCreateDrink.TabIndex = 0;
            this.btnCreateDrink.Text = "Create Drink";
            this.btnCreateDrink.UseVisualStyleBackColor = true;
            this.btnCreateDrink.Click += new System.EventHandler(this.btnCreateDrink_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(54, 203);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 29);
            this.button1.TabIndex = 13;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 287);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Drinks Schystem *hick*";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSaveIngredient;
        private System.Windows.Forms.TextBox txtIngredientName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lbIngredients;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDeleteDrink;
        private System.Windows.Forms.ListBox lbDrinks;
        private System.Windows.Forms.TextBox txtDrinkName;
        private System.Windows.Forms.Button btnCreateDrink;
        private System.Windows.Forms.TextBox txtDrinkSearch;
        private System.Windows.Forms.Button txtFindDrink;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnUpdateDrink;
        private System.Windows.Forms.Button button1;
    }
}

