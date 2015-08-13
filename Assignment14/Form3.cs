using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Assignment14
{
    public partial class Form3 : Form
    {
        EmpDetails obj = new EmpDetails();
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            ArrayList list = obj.GetEmpID();
            comboID.DataSource = list;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(comboID.Text);
            string name = textName.Text;
            int age =Convert.ToInt32( textAge.Text);
            string gen=null;
            if (radioButton1.Checked)
            {
                gen = radioButton1.Text;
            }
            else
                if (radioButton2.Checked)
                {
                   gen = radioButton2.Text;
                }
            string location = textLocation.Text;
            long mobile = Convert.ToInt64(textMobile.Text);
            string mail = textMail.Text;
            string add = textAddress.Text;

            obj.updateDetails(ID,name,age,gen,location,mobile,mail,add);


            MessageBox.Show("Updated");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(comboID.Text);
            obj.deleteDetails(ID);

            MessageBox.Show("Deleted");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var list = obj.viewBang();
            dataGridView1.DataSource = list;
        }


    }
}
