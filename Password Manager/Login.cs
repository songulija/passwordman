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
                //JEIGU EGZISTUOJA AES FAILAS SU TOKIU USERNAME TADA ..
                if (File.Exists(path + ".aes"))
                {
                    //SUSIKURIAME ASE OBJEKTA HAD DEKRYPTINT FAILA
                    AES sE = new AES();
                    //Thread th = new Thread(() => sE.FileDecrypt(path + ".aes", path, keyy));
                    //th.Start();

                    //DECRYPTINAM SU TOKIU PACIU RAKTU
                    sE.FileDecrypt(path + ".aes", path, keyy);
                }
                else
                {
                    //JEIGU NERA SUKURIAME TOKI FAILA
                    FileStream fs = File.Create(path);
                    fs.Close();
                }

                //Thread th1 = new Thread(() => ql.login(LoginUsername.Text, sh.passHash(loginPassword.Text)));
                //th1.Start();

                //PANAUDOJAME SQL FUNCKIJA LOGIN KURIA SUKUREME, DUODAME USERNAME, UZHASHINTA PASSWORD. FUNCKIJA PAZIURES AR PASSWORDAI SUTAMPA
                ql.login(LoginUsername.Text, sh.passHash(loginPassword.Text));

                //ATIDAROME HOME SCREEN
                Home home = new Home();
                home.ShowDialog();

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
