using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Assignment14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmpDetails obj = new EmpDetails();
            obj.EmpId = Convert.ToInt32(textemp.Text);
            obj.EmpName = textName.Text;
            obj.Age = Convert.ToInt32(textAge.Text);
            if (radioButton1.Checked)
            {
                obj.Gender = radioButton1.Text;
            }
            else
                if (radioButton2.Checked)
                {
                    obj.Gender = radioButton2.Text;
                }
            //MessageBox.Show(obj.Gender);
            obj.Location = textLocation.Text;
            obj.Mobile = Convert.ToInt64(textMobile.Text);
            obj.Email = textMail.Text;
            obj.Address = textAddress.Text;

            
            int result = obj.getDetails(obj.EmpId, obj.EmpName, obj.Age, obj.Gender, obj.Location, obj.Mobile, obj.Email, obj.Address);

            if (result == 1)
            {
                MessageBox.Show("Details Added");
            }
            else
            {
                MessageBox.Show("Company not Added");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
