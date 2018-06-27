// An Reference must be added by right clicking the References in Solution Explorer and select Add Reference->MySql.data


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient; //To use

namespace WindowsFormsApplication4
{
    public partial class Form2 : Form
    {
        string cmail,omail;
        int cnum,onum;
        public Form2(string qname,string qaddr,int num)//Receive data from the First Form
        {
            InitializeComponent();//First Components must be initialised to work
            ChangeName.Text = qname;//display data on the text box
            ChangeMail.Text = qaddr;
            ChangeNumber.Text = Convert.ToString(num);
            omail = qaddr;
            onum = num;
           
        }

        private void ChangeMail_TextChanged(object sender, EventArgs e)
        {
            cmail = ChangeMail.Text;
        }

        private void ChangeNumber_TextChanged(object sender, EventArgs e)
        {
            //converted to number because Textbox only receives strings
            cnum = Convert.ToInt32(ChangeNumber.Text); 
        }

        private void Update_Click(object sender, EventArgs e)
        {
            string serv = "localhost", database = "namefield", uid = "root", pasw = "121417181";//giving basic info for the SQL database
            //the constring consists of the Queries that needs to be performed a command ends with a ";"
            string constring = "SERVER=" + serv + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + pasw + ";";
            //Start a connection using the object "MySqlConnection"
            MySqlConnection connection = new MySqlConnection(constring);
            connection.Open();//Open the SQL database
            //To update contents in a Query where "cmail" is new data and "omail" is old data
            string query = "UPDATE details SET Mail='" + cmail + "' WHERE Mail='" + omail +"';";
            //Send a command to the database using "MySqlCommand(query,connection)
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();//Specifies which type of query is run (NonQuery is used to change data and doesnt affect column
            query = "UPDATE details SET Number=" + cnum + " WHERE Number=" + onum + ";";//similar to last
            cmd.ExecuteNonQuery();
            connection.Close();//Close the connection to the SQL
            MessageBox.Show("Details Changed");
            Application.Exit();
        }

    }
}
