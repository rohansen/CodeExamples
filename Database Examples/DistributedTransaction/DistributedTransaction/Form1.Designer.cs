namespace DistributedTransaction
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtCustomer1 = new System.Windows.Forms.TextBox();
            this.txtAmount1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtCustomer2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(95, 132);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(484, 367);
            this.textBox1.TabIndex = 2;
            // 
            // txtCustomer1
            // 
            this.txtCustomer1.Location = new System.Drawing.Point(16, 36);
            this.txtCustomer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCustomer1.Multiline = true;
            this.txtCustomer1.Name = "txtCustomer1";
            this.txtCustomer1.Size = new System.Drawing.Size(252, 31);
            this.txtCustomer1.TabIndex = 3;
            this.txtCustomer1.Text = "1";
            // 
            // txtAmount1
            // 
            this.txtAmount1.Location = new System.Drawing.Point(201, 92);
            this.txtAmount1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAmount1.Multiline = true;
            this.txtAmount1.Name = "txtAmount1";
            this.txtAmount1.Size = new System.Drawing.Size(252, 31);
            this.txtAmount1.TabIndex = 4;
            this.txtAmount1.Text = "1000";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(277, 57);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 28);
            this.button1.TabIndex = 5;
            this.button1.Text = "Overfør";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txtCustomer2
            // 
            this.txtCustomer2.Location = new System.Drawing.Point(380, 36);
            this.txtCustomer2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCustomer2.Multiline = true;
            this.txtCustomer2.Name = "txtCustomer2";
            this.txtCustomer2.Size = new System.Drawing.Size(252, 31);
            this.txtCustomer2.TabIndex = 6;
            this.txtCustomer2.Text = "1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(221, 506);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(173, 35);
            this.button2.TabIndex = 7;
            this.button2.Text = "Exception!!";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 553);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtCustomer2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtAmount1);
            this.Controls.Add(this.txtCustomer1);
            this.Controls.Add(this.textBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Distribuerede Transaktioner";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtCustomer1;
        private System.Windows.Forms.TextBox txtAmount1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtCustomer2;
        private System.Windows.Forms.Button button2;
    }
}

