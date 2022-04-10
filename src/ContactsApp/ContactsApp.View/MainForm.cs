using Microsoft.Build.Evaluation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactsApp.View
{
    public partial class MainForm : Form
    {
        private Project _project;

        public MainForm()
        {
            InitializeComponent();
        }

        private void FindBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            //UpdateListBox();
            //AddContact();
            ContactForm contactForm = new ContactForm();
            contactForm.Show();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            ContactForm contactForm = new ContactForm();
            contactForm.Show();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            ContactForm contactForm = new ContactForm();
            contactForm.Show();
        }

        private void ExitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddContactToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ContactForm contactForm = new ContactForm();
            contactForm.Show();
        }

        private void EditContactToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ContactForm contactForm = new ContactForm();
            contactForm.Show();
        }

        private void RemoveContactToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ContactForm contactForm = new ContactForm();
            contactForm.Show();
        }

        private void AboutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void UpdateListBox(Project contacts)
        {
            _project = new Project();
            ContactListBox.Items.Clear();
            //_project.contacts();
            for (int i = 0; i < ContactListBox.Items.Count; i++)
            {
                //ContactListBox.Items.Add();
            }
        }

        private void ContactListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

