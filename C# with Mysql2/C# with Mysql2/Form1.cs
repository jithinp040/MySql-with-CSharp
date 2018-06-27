using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        string name,qaddr;//Declaring as global variables 
        int num;//Declaring global because somehow they are unable to be used locally(they require initial values
        public Form1()
        {
            InitializeComponent();
        }

        private void Name1_TextChanged(object sender, EventArgs e)
        {
            name = Name1.Text;//Receive the name
        }

        private void check_Click(object sender, EventArgs e)
        {
            int res = 0;//A signal to check whether data was found or not
            
            string serv = "localhost", database = "namefield", uid = "root", pasw = "121417181";
            string constring =
            constring = "SERVER=" + serv + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + pasw + ";";
            MySqlConnection connection = new MySqlConnection(constring);
            connection.Open();
            //Read from Table where "*" implies all the columns to be read
            string query = "SELECT * FROM details";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            //Execute a SQL command to read ,which uses class "MySqlDataReader" as a command for ExecuteReader using cmd
            MySqlDataReader read = cmd.ExecuteReader();
            while (read.Read())//while the data doesnt become empty
            {
                //read.GetString("Name")where read-reader objectRead()-to read data Method GetString-used to get a string "Name"-column name
                if (name == read.GetString("Name"))
                {//if found read its address and number
                    qaddr=read.GetString("Mail");
                    num=Convert.ToInt32(read.GetString("Number"));//obtained string is converted to number
                    res = 1;//A signal is turned on
                }
            }
            if (res == 0)
            {//if not found
                MessageBox.Show("Details not Found:");
                this.Close();//Close the application
            }
            connection.Close();
            this.SendToBack();
            Form2 f2 = new Form2(name, qaddr, num);
            f2.ShowDialog();
        }
    }
}
