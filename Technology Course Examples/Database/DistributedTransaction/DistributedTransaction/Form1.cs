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
using System.Transactions;
using System.Windows.Forms;

namespace DistributedTransaction
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void PrintTransactionMetaData()
        {
            textBox1.AppendText("Distributed identifier: " + Transaction.Current.TransactionInformation.DistributedIdentifier + Environment.NewLine);
            textBox1.AppendText("Local identifier: " + Transaction.Current.TransactionInformation.LocalIdentifier + Environment.NewLine);
            textBox1.AppendText("Status: " + Transaction.Current.TransactionInformation.Status + Environment.NewLine);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DoTransaction();
        }

        private async void DoTransaction()
        {
            textBox1.Text = "";
            TransactionOptions option = new TransactionOptions();
            option.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            option.Timeout = new TimeSpan(0, 0, 30);

            string deductSQL = "UPDATE Account SET Balance = Balance - " + txtAmount1.Text + " WHERE CustomerId = " + txtCustomer1.Text;
            string insertCmdSql2 = "UPDATE Account SET Balance = Balance + " + txtAmount1.Text + " WHERE CustomerId = " + txtCustomer2.Text;
            string debugReadSql = " SELECT Balance FROM Account WHERE CustomerId = " + txtCustomer2.Text;

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, option))
            {
                //Create Connections
                SqlConnection SqlConn1 = new SqlConnection("Server=localhost;Integrated Security=true; initial catalog=DanskeBank"); //kør Danske Bank SQL på DB1
                SqlConnection SqlConn2 = new SqlConnection("Server=localhost\\SQLExpress;Integrated Security=true; initial catalog=SBanking"); //kør SBanking SQL på DB2

                //Create command to read initial values THIS IS ON THE FIRST DATABASE
                SqlConn1.Open();
                SqlCommand comm0 = SqlConn1.CreateCommand();
                comm0.CommandText = debugReadSql;
                var rdr = await comm0.ExecuteReaderAsync();
                while (await rdr.ReadAsync())
                {
                    textBox1.AppendText("Executing query on server 1..." + Environment.NewLine);
                    textBox1.AppendText("Balance on Acc 1 is: " + rdr["Balance"].ToString() + Environment.NewLine);
                }
                rdr.Close();
                Thread.Sleep(2000);
                
                //Create first DB command
                SqlCommand comm1 = SqlConn1.CreateCommand();
                
                //Read data
                //Do a select statement, to try and read the intermediary transaction data
                comm1.CommandText = deductSQL;
             
                textBox1.AppendText("Connecting to server 1..." + Environment.NewLine);
                PrintTransactionMetaData();
                await comm1.ExecuteNonQueryAsync();
                Thread.Sleep(4000);

                PrintTransactionMetaData();

                //Create second sql command THIS IS ON THE SECOND DATABASE
                SqlCommand comm2 = SqlConn2.CreateCommand();
                comm2.CommandText = insertCmdSql2;
                SqlConn2.Open();
                textBox1.AppendText("Connecting to server 2..." + Environment.NewLine);
                PrintTransactionMetaData();
         
                await comm2.ExecuteNonQueryAsync();
                textBox1.AppendText("Executing query on server 2..." + Environment.NewLine);
                PrintTransactionMetaData();
                scope.Complete();
                textBox1.AppendText("Scope completed..." + Environment.NewLine);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            throw new Exception("FATAL ERROR; THE POPE IS DEAD");
        }
    }
}
