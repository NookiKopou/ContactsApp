using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactsApp.Model;


namespace ContactsApp.View
{
    public partial class ContactForm : Form
    {
        public ContactForm()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SurnameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
            //    _surname = SurnameTextBox.Text;
                SurnameTextBox.BackColor = Color.White;
            }
            catch (FormatException exception)
            {
                SurnameTextBox.BackColor = Color.LightPink;
                //_surnameErrorText = "$Surname must be no longer than 50 letters."
                //        + $"But was {SurnameTextBox.Text}"; 
            }
        }
    }
}
