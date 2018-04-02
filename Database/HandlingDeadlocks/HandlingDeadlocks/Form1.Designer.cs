namespace HandlingDeadlocks
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
            this.btnWithdraw500 = new System.Windows.Forms.Button();
            this.btnWithdraw200 = new System.Windows.Forms.Button();
            this.lbUsers = new System.Windows.Forms.ListBox();
            this.lbAccounts = new System.Windows.Forms.ListBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.btnUpdateUsername = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnWithdraw500
            // 
            this.btnWithdraw500.Location = new System.Drawing.Point(200, 204);
            this.btnWithdraw500.Name = "btnWithdraw500";
            this.btnWithdraw500.Size = new System.Drawing.Size(186, 28);
            this.btnWithdraw500.TabIndex = 0;
            this.btnWithdraw500.Text = "Withdraw 500";
            this.btnWithdraw500.UseVisualStyleBackColor = true;
            this.btnWithdraw500.Click += new System.EventHandler(this.btnWithdraw500Click);
            // 
            // btnWithdraw200
            // 
            this.btnWithdraw200.Location = new System.Drawing.Point(200, 238);
            this.btnWithdraw200.Name = "btnWithdraw200";
            this.btnWithdraw200.Size = new System.Drawing.Size(186, 28);
            this.btnWithdraw200.TabIndex = 1;
            this.btnWithdraw200.Text = "Withdraw 200";
            this.btnWithdraw200.UseVisualStyleBackColor = true;
            this.btnWithdraw200.Click += new System.EventHandler(this.btnWithdraw200Click);
            // 
            // lbUsers
            // 
            this.lbUsers.FormattingEnabled = true;
            this.lbUsers.Location = new System.Drawing.Point(12, 12);
            this.lbUsers.Name = "lbUsers";
            this.lbUsers.Size = new System.Drawing.Size(182, 186);
            this.lbUsers.TabIndex = 2;
            this.lbUsers.SelectedIndexChanged += new System.EventHandler(this.lbUsers_SelectedIndexChanged);
            // 
            // lbAccounts
            // 
            this.lbAccounts.FormattingEnabled = true;
            this.lbAccounts.Location = new System.Drawing.Point(200, 12);
            this.lbAccounts.Name = "lbAccounts";
            this.lbAccounts.Size = new System.Drawing.Size(186, 186);
            this.lbAccounts.TabIndex = 3;
            this.lbAccounts.SelectedIndexChanged += new System.EventHandler(this.lbAccounts_SelectedIndexChanged);
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(392, 11);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStatus.Size = new System.Drawing.Size(374, 367);
            this.txtStatus.TabIndex = 6;
            // 
            // btnUpdateUsername
            // 
            this.btnUpdateUsername.Location = new System.Drawing.Point(12, 238);
            this.btnUpdateUsername.Name = "btnUpdateUsername";
            this.btnUpdateUsername.Size = new System.Drawing.Size(186, 28);
            this.btnUpdateUsername.TabIndex = 7;
            this.btnUpdateUsername.Text = "Update username";
            this.btnUpdateUsername.UseVisualStyleBackColor = true;
            this.btnUpdateUsername.Click += new System.EventHandler(this.btnUpdateUsername_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(12, 204);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(182, 20);
            this.txtUserName.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 500);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.btnUpdateUsername);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.lbAccounts);
            this.Controls.Add(this.lbUsers);
            this.Controls.Add(this.btnWithdraw200);
            this.Controls.Add(this.btnWithdraw500);
            this.Name = "Form1";
            this.Text = "Deadlock Withdrawal";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWithdraw500;
        private System.Windows.Forms.Button btnWithdraw200;
        private System.Windows.Forms.ListBox lbUsers;
        private System.Windows.Forms.ListBox lbAccounts;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Button btnUpdateUsername;
        private System.Windows.Forms.TextBox txtUserName;
    }
}

