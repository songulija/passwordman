using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Password_Manager
{
    public partial class Login : Form
    {
        public static string username = "";
        //YRA KEY
        string keyy = "youtubee";
        //SUSIKURIAME HASH OBJEKTA. KAD HASHINT PASSWORD
        Hash sh = new Hash();
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SUSIKURIAME SQL OBJEKTA KAD PANAUDOTI SQL KLASES FUNCKIJAS
            sql ql = new sql();
            username = LoginUsername.Text;
            string path = @"C:\Users\PC\Desktop\Password-Manager-Lukas\Password Manager\bin\Debug\Users\" + username + ".txt";




            try
            {
                

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

           

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.ShowDialog();
        }

        

    }
}
