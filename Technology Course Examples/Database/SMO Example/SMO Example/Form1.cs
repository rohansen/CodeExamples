using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Security;
using System.Transactions;
using System.IO;
using System.Diagnostics;

namespace SMO_Example
{
    public partial class Form1 : Form
    {
        private Timer t = new Timer();
        private ServerConnection srvConn;
        public Form1()
        {
            InitializeComponent();
            t.Interval = 1000;
            t.Tick += T_Tick;
        }


        private void ConnectToDb()
        {
            string sqlServerLogin = txtSqlUserName.Text;
            string password = txtSqlPassword.Text;
            string instanceName = txtSqlInstanceName.Text;
            srvConn = new ServerConnection();
            srvConn.ServerInstance = instanceName;   // connects to named instance  
            srvConn.LoginSecure = false;   // set to true for Windows Authentication  
            srvConn.Login = sqlServerLogin;
            srvConn.Password = password;

        }
        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            listBox1.ValueMember = "";

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 1 || Path.GetExtension(files[0]).ToLower() != ".csv")
            {
                MessageBox.Show("Drag 1 file, needs to be csv");
            }
            else
            {
                StreamReader sr = new StreamReader(files[0], Encoding.Default);
                CsvHelper.CsvReader rdr = new CsvHelper.CsvReader(sr);
                rdr.Configuration.RegisterClassMap<MyClassMap>();
                rdr.Configuration.Delimiter = ";";
                var test = rdr.GetRecords<Student>().ToList();
                foreach (var item in test)
                {
                    listBox1.Items.Add(item);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {





        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = "";
            var students = listBox1.SelectedItems.Cast<Student>();
            foreach (Student item in listBox1.SelectedItems)
            {
                s += item.Fullname + ", ";
            }
            MessageBox.Show(s);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectToDb();
                Server srv = new Server(srvConn);
                var students = listBox1.SelectedItems.Cast<Student>();
                string msg = "";
                foreach (var s in students)
                {
                    msg += s.Activity + "_" + s.IDFromAdministrativeSystem + " for student: " + s.Fullname + "\n";
                }
                var res = MessageBox.Show(this, "Warning, you are about to create the following students in the database:\n" + msg, "Are you sure?", MessageBoxButtons.OKCancel);
                if (res == DialogResult.Cancel)
                    return;

                // Connecting to a named instance of SQL Server with SQL Server Authentication using ServerConnection  



                foreach (var student in students)
                {
                    string dbandloginname = student.Activity + "_" + student.IDFromAdministrativeSystem;
                    Database db = new Database(srv, dbandloginname);
                    db.Create();
                    Login login = new Login(srv, dbandloginname);
                    login.LoginType = LoginType.SqlLogin;
                    login.DefaultDatabase = dbandloginname;
                    login.Create("Password1!");

                    User newDbUser = new User(db, dbandloginname);
                    newDbUser.Login = dbandloginname;
                    newDbUser.DefaultSchema = "dbo";
                    newDbUser.Create();
                    newDbUser.AddToRole("db_owner");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Something went wrong" + ex.Message);
                return;
            }




        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://ums.ucn.dk");
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void findDatabases(object sender, EventArgs e)
        {
            t.Start();
            
        }

        private void T_Tick(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            try
            {
                ConnectToDb();
                Server srv = new Server(srvConn);
                var databases = srv.Databases;
                foreach (Database db in databases)
                {
                    if (db.Name.ToLower().Contains(txtSearch.Text.ToLower()))
                    {
                        listBox2.Items.Add(db);
                    }
                }
                t.Stop();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Something went wrong" + ex.Message);
                t.Stop();
                return;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            try
            {
                Server srv = new Server(srvConn);
                var dbs = listBox2.SelectedItems.Cast<Database>();

                string msg = "";
                foreach (var s in dbs)
                {
                    msg += s.Name + "\n";
                }
                var res = MessageBox.Show(this, "Warning, you are about to delete the following databases:\n" + msg, "Are you sure?", MessageBoxButtons.OKCancel);
                if (res == DialogResult.Cancel)
                    return;



                foreach (var db in dbs)
                {
                    User u = db.Users[db.Name];
                    u.Drop();
                    Login l = srv.Logins[db.Name];
                    l.Drop();
                    db.Drop();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Something went wrong" + ex.Message);
                return;
            }
        }

        private void findDatabases(object sender, KeyEventArgs e)
        {

        }
    }
}
