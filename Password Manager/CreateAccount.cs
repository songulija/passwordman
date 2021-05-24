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

namespace Password_Manager
{
    public partial class CreateAccount : Form
    {

        public string path = @"C:\Users\PC\Desktop\Password-Manager-Lukas\Password Manager\bin\Debug\Users\" + Login.username + ".txt";
        public string record = "";
        public CreateAccount()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            StreamReader srCheck = new StreamReader(path);
            //perskaitome viska su StreamReader
            string checkID = srCheck.ReadToEnd();

            srCheck.Close();

            if (checkID.Contains(txtID.Text + ";"))
            {
                MessageBox.Show("THIS ID EXIST please chang it");
                txtID.Focus();
                txtID.SelectAll();
            }
            else
            {
                StreamWriter sw = new StreamWriter(path, true);
                //IRASOME txtID title username ir t.t.

                string strData = txtID.Text + ";" + txtTitle.Text + ";" + txtUsername.Text + ";" + txtPassword.Text + ";" + txtURL.Text + ";" + txtMore.Text;


                sw.WriteLine(strData);
                sw.Close();

                MessageBox.Show("Account ADDED");

                foreach (Control c in this.Controls)
                {
                    if(c is TextBox)
                    {
                        c.Text = "";
                    }
                }
            }

           

        }

        
       
        private void button2_Click(object sender, EventArgs e)
        {
            //jeigu mes esame irase USER ID tada galim ieskoti
            if (txtID.Text.Trim() != "")
            {
                //susikuriam stream reader
                StreamReader sr = new StreamReader(path);
                string line = "";
                bool found = false;
                //skaitysime kiekviena line kol yra ka skaityt
                do
                {
                    line = sr.ReadLine();
                    //jeigu line nelygu null reiskia ten kazkas yra tada
                    if(line != null)
                    {
                        //splitinam data kuria radom ;
                        string[] data = line.Split(';');
                        //jeigu rastos data id sutampa su txtID tada priskiriam musu fieldams gautus values
                        if(data[0] == txtID.Text)
                        {
                            txtID.Text = data[0];
                            txtTitle.Text = data[1];
                            txtUsername.Text = data[2];
                            txtPassword.Text = data[3];
                            txtURL.Text = data[4];
                            txtMore.Text = data[5];
                            found = true;
                            record = line;
                            break;
                        }
                    }
                } while (line != null);

                sr.Close();

                if (!found)
                {
                    MessageBox.Show("ID Not Found");
                }
            }
            else
            {
                MessageBox.Show("Enter ID!");
            }
        }
        private void Update_Click(object sender, EventArgs e)
        {
            string line = "";
            //kad gauti ats be ";" turime splitint
            string[] data1 = record.Split(';');
            StreamReader sr = new StreamReader(path);
            List<string> result = new List<string>();
            do
            {
                //readinam line kol yra ka readint
                line = sr.ReadLine();
                //jeigu line turi savyje data tada
                if (line != null)
                {
                    //splitinam gauta data ";" kad gaut svarius atsakymus
                    string[] data = line.Split(';');
                    //jeigu perskaityto katik record duomenis(ID) sutampa su record(kuri mes gavome su find) ID
                    if (data[0] == data1[0])
                    {
                        //pridedam data prie String list(result)
                        result.Add(data1[0] + ";" + txtTitle.Text + ";" + txtUsername.Text + ";" + txtPassword.Text + ";" + txtURL.Text + ";" + txtMore.Text);

                    }
                    else//if nesutampa
                    {
                        //
                        result.Add(line);
                    }
                }
            } while (line != null);
            sr.Close();
            File.Delete(path);
            StreamWriter sw = new StreamWriter(path);
            //irasome data i faila
            foreach (var item in result)
            {
                sw.WriteLine(item);
                Console.WriteLine(item);
            }

            sw.Close();

            MessageBox.Show("updated successfully ");

            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
            }

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                string line = "";
                string[] data1 = record.Split(';');//gauname paspaude find
                StreamReader sr = new StreamReader(path);
                List<string> result = new List<string>();
                do
                {
                    //skaitome kol yra ka skaityt
                    line = sr.ReadLine();
                    if (line != null)//reiskia yra data
                    {
                        string[] data = line.Split(';');//splitinam perskaityta line
                        if (data[0] == data1[0])
                        {
                            //jeigu sutampa tesiam
                            continue;

                        }
                        else
                        {
                            result.Add(line);
                        }
                    }
                } while (line != null);
                sr.Close();
                //deletinam faila su tuo path
                File.Delete(path);
                StreamWriter sw = new StreamWriter(path);
                foreach (var item in result)
                {
                    //surasome nauja data i faila
                    sw.WriteLine(item);
                    Console.WriteLine(item);
                }

                sw.Close();

                MessageBox.Show("Deleted successfully ");

                foreach (Control c in this.Controls)
                {
                    if (c is TextBox)
                    {
                        c.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPassword.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtPassword.Text);
            MessageBox.Show("Coped password");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PasswordGenerator password = new PasswordGenerator();
            txtPassword.Text = password.GeneratePassword(true, true, true, true, 16);
        }
    }
}
