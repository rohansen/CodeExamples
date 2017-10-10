using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HashingExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HashPassword(textBox1.Text);

        }
        private string currentSalt = "";
        private string currentSaltedHash = "";
        private int amountOfIterations = 10000;
        public void HashPassword(string password)
        {
            //Generate Salt
            byte[] salt = new byte[16];
            var cryptoProvider = new RNGCryptoServiceProvider();//128bit salt
            cryptoProvider.GetBytes(salt);
            currentSalt = Encoding.Default.GetString(salt);
            label2.Text = "Salt in memory: " + ToHexString(salt);
            //Hash password with the salt
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, amountOfIterations);
            byte[] hash = pbkdf2.GetBytes(20);
            currentSaltedHash = Encoding.Default.GetString(hash);
            textBox2.Text = "Salted hash in memory: " + ToHexString(hash);
        }
        private string ToHexString(byte[] input)
        {
            string tmp = "";
            foreach (var item in input)
            {
                tmp += item.ToString("x2");
            }
            return tmp;
        }
       

        public bool CheckPassword(string password)
        {
            //Salt already stored in "Database", retrieve salt.. hash and salt cleartext password. check with saltedHash from DB
            var saltToCheck = Encoding.Default.GetBytes(currentSalt);
            var pbkdf2 = new Rfc2898DeriveBytes(password, saltToCheck, amountOfIterations);
            byte[] hash = pbkdf2.GetBytes(20);

            string newSaltedHash = Encoding.Default.GetString(hash);
            
            return newSaltedHash == currentSaltedHash;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CheckPassword(textBox1.Text))
            {
                MessageBox.Show("Welcome!");
            }else
            {
                MessageBox.Show("Stay out!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HashAlgorithm ha = HashAlgorithm.Create("SHA256");
            var pwBytes = Encoding.Default.GetBytes(textBox1.Text);
            var hashBytes = ha.ComputeHash(pwBytes);
            string hashedPasswordString = "";
            foreach (var b in hashBytes)
            {
                hashedPasswordString += b.ToString("x2");
            }

            textBox3.Text = hashedPasswordString;
        }
    }
}
