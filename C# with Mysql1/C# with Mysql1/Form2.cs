using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form2 : Form
    {
        Form1 f1=new Form1() ;//Create an object form to control it
        public Form2()
        {
            InitializeComponent();
        }

        private void yes_Click(object sender, EventArgs e)
        {
            //If yes button is clicked
            this.Hide();//Hides the form2
            f1.Visible = true;//Set visiblity mode of Form1 to true
            
        }

        private void no_Click(object sender, EventArgs e)
        {//If No button is clicked
            this.Hide();
            f1.Hide();
            Form f3 = new Form3();//Create an object for Form 3
            f3.ShowDialog();//Display the form 3     Lines after this are useless in this event
            f1.Close();
            this.Close();
            
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        
    }
}
