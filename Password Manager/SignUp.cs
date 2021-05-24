using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Password_Manager
{
    public partial class SignUp : Form
    {
        public string userpassword,userconfirmpassword;
        //HASH KLASE
        Hash sh = new Hash();
        public SignUp()
        {
            InitializeComponent();
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //ATIDAROME LOGIN LANGA KAI PASPAUDZIAMAS LOGIN MYGTUKAS
            Login login = new Login();
            login.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SUSIKURIAM SQL OBJECTA, ISSIKVIECIAME FUNKCIJA KURI PRIDEDA
            sql ql = new sql();
            try
            {
               
                if (Password.Text == ConfiemPassword.Text)
                {
                    //Thread th1 = new Thread(() => ql.AddUser(Username.Text, sh.passHash(Password.Text)));
                    //th1.Start();
                    //ISSIKVIECIAME SQL klases funkijc AddUser. duadame username, uzhasinta passworda ir viskas
                    ql.AddUser(Username.Text,sh.passHash(Password.Text));
                }
                else
                {
                    MessageBox.Show("PASSWORD DOESNT MATCH");
                }
                
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }
    }
}
