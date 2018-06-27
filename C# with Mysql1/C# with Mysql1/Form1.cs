using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        string nam, address;
        int num;
        public Form1()
        {
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           nam = textBox1.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            address = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            num = Convert.ToInt32(textBox3.Text);
        }

        private void submit_Click(object sender, EventArgs e)
        {//Details in the start of the program are written in the Application 4 project
            string qname = textBox1.Text;
            string qaddr = textBox2.Text;
            string qnum = Convert.ToString(num);
            string serv = "localhost",database = "namefield", uid = "root", pasw = "121417181";
            string constring = 
            constring = "SERVER=" + serv + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + pasw + ";";
            MySqlConnection connection = new MySqlConnection(constring);
            connection.Open();
            //Insert details in to the table where data within first braces are "columns" and Second is the "data to be placed"
            string query = "INSERT INTO details(Name,Mail,Number) VALUES ('"+qname+"','"+qaddr+"',"+qnum+");";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();//Query used to change data
            connection.Close();
            this.Visible = false;//Hides the form1
           Form2 f2 = new Form2();
            f2.ShowDialog();   
        }
    }
}
