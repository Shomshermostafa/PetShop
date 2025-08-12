using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace Register_Form
{
    public partial class Form1 : Form
    {
        DBcon dbc = new DBcon();
        public static string name;
        public static string id;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            name = textBox1.Text;
            id = textBox2.Text;

            Form2 f2 = new Form2();
            f2.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex>0 && string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Focus();
                errorProvider1.Icon = Properties.Resources.cross;
                errorProvider1.SetError(this.textBox1, "Enter valid username!");
                //MessageBox.Show("Enter your name please!");
            }
            else
            {
                errorProvider1.Icon = Properties.Resources.correct;
                //errorProvider1.Clear();
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > 0 && string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Focus();
                errorProvider2.Icon = Properties.Resources.cross;
                errorProvider2.SetError(this.textBox2, "Enter valid password!");
                //MessageBox.Show("Enter your salary please!");
            }
            else
            {
                errorProvider2.Icon = Properties.Resources.correct;
                //errorProvider2.Clear();
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex > 0)
                {


                    if (comboBox1.SelectedIndex > 0 && textBox1.Text != "" && textBox2.Text != "")
                    {
                        if (comboBox1.Text == "Admin")
                        {
                            dbc.Opencon();
                            string query = "select count(*) from RegDbtbl where Email='" + textBox1.Text + "' and password='" + textBox2.Text + "'";
                            SqlCommand command = new SqlCommand(query, dbc.GetCon());

                            int v = (int)command.ExecuteScalar();
                            if (v != 1)
                            {
                                MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("log in succesesed welcome to homepage!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                textBox1.Text = "";
                                textBox2.Text = "";

                                //loginname = textusername.Text;
                                //logintype = comboRole.Text;
                                clrValue();
                                this.Hide();
                                Form3 f3 = new Form3();
                                f3.Show();

                            }
                        }
                        else
                        {
                            MessageBox.Show("Fill in both fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            clrValue();
                        }

                    }
                    else if (comboBox1.Text == "Seller")
                    {
                        dbc.Opencon();
                        string query = "select count(*) from RegDbtbl where Email='" + textBox1.Text + "' and password='" + textBox2.Text + "'";
                        SqlCommand command = new SqlCommand(query, dbc.GetCon());

                        int v = (int)command.ExecuteScalar();
                        if (v != 1)
                        {
                            MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("log in succesesed welcome to homepage!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            textBox1.Text = "";
                            textBox2.Text = "";

                            //loginname = textusername.Text;
                            //logintype = comboRole.Text;
                            clrValue();
                            this.Hide();
                            Form3 f3 = new Form3();
                            f3.Show();

                        }
                    }
                    else
                    {
                        MessageBox.Show("Fill in both fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        clrValue();
                    }


                        }
                        else
                        {
                            MessageBox.Show("Please select any role", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            clrValue();
                        }

                    }



              catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbc.Closecon();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ResetControl();
        }

        private void ResetControl()
        {
            //comboBox1.SelectedIndex = 0;
            textBox1.Clear();
            textBox2.Clear();
            
           
        }
        private void clrValue()
        {
            comboBox1.SelectedIndex = 0;
            textBox1.Clear();
            textBox2.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            comboBox1.SelectedIndex = 0;
        }
    }
}
