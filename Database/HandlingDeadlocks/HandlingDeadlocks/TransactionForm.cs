using Core;
using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HandlingDeadlocks
{
    public partial class TransactionForm : Form
    {
        //private DbUser dbUser = new DbUser();
        private DbUserWithTransactions dbUser = new DbUserWithTransactions();
        public TransactionForm()
        {
            InitializeComponent();
            //For simplicity i have disabled cross thread checking for the form;this is not best practice
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lbAccounts.Items.Clear();
            lbUsers.Items.Clear();
            foreach (var item in dbUser.GetAllUsersWithAccounts())
            {
                lbUsers.Items.Add(item);
            }
        }
        
        private void lbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            User selectedUser = (User)lbUsers.SelectedItem;
            lbAccounts.Items.Clear();
            foreach (var item in dbUser.GetAllAccountsFromUser(selectedUser.Id))
            {
                lbAccounts.Items.Add(item);
            }
            txtUserName.Text = selectedUser.Name;
        }
        
        private void btnWithdraw500Click(object sender, EventArgs e)
        {
            Thread t = new Thread(WithdrawThread);
            t.IsBackground = true;
            t.Start(500M);
        }

        private void WithdrawThread(object obj)
        {
            Account selectedAccount = (Account)lbAccounts.SelectedItem;
            try
            {
                dbUser.RetryingWithdraw(selectedAccount, Convert.ToDecimal(obj), UpdateStatusCallback);
            }
            catch (SqlException sqle)
            {

                MessageBox.Show("Fejl: " + sqle.Number);
            }
            

        }

        private void UpdateStatusCallback(string obj)
        {
            txtStatus.AppendText("-------------------------------------------" + Environment.NewLine);
            txtStatus.AppendText(obj + Environment.NewLine);
        }

        private void btnWithdraw200Click(object sender, EventArgs e)
        {

            Thread t = new Thread(WithdrawThread);
            t.IsBackground = true;
            t.Start(200M);

        }
        
        private void lbAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            Account selectedPet = (Account)lbAccounts.SelectedItem;
        }

        private void btnUpdateUsername_Click(object sender, EventArgs e)
        {
            User selectedUser = (User)lbUsers.SelectedItem;
            selectedUser.Name = txtUserName.Text;
            if (dbUser.UpdateUser(selectedUser, true))
            {
                txtStatus.AppendText("Updated username..." + Environment.NewLine);
            }
            else
            {

                var result = MessageBox.Show("Someone has changed data before last refresh!, do you want to overwrite?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    dbUser.UpdateUser(selectedUser, false);
                }

            }

            //Refresh data
            lbUsers.Items.Clear();
            foreach (var item in dbUser.GetAllUsersWithAccounts())
            {
                lbUsers.Items.Add(item);
            }
        }
    }
}
