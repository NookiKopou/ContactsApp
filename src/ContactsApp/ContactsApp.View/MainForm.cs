//using Microsoft.Build.Evaluation;
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
    public partial class MainForm : Form
    {
        /// <summary>
        /// Создает новый экземпляр
        /// </summary>
        private Project _project = new Project();

        /// <summary>
        /// Очищает все элементы списка и добавляет данные из коллекции 
        /// </summary>
        private void UpdateListBox()
        {
            ContactsListBox.Items.Clear();
            for (int i = 0; i < _project.Contacts.Count; i++)
            {
                   ContactsListBox.Items.Add(_project.Contacts[i].Surname);
            }
        }

        /// <summary>
        /// Добавляет новый контакт
        /// </summary>
        private void AddContact()
        {
            //Создает объект для рандомайзера
            Random r = new Random();

            string[] arrSurname = { "Orlov", "Preobrazhensky", "Nikitin", "Golubev", "Pasternak",
                "Zaitsev", "Vinogradov", "Belyaev", "Agapov", "Antonov" };

            string[] arrName = { "Artyom", "Aleksandr", "Roman", "Yevgeny", "Ivan", 
                "Denis",  "Alexey", "Dmitry", "Danyl", "Oleg" };

            //Создает объекты формата Year.Month.Day
            DateTime date = new DateTime(r.Next(1900, DateTime.Now.Year), r.Next(1, 12),
                r.Next(1, 31));

            string[] arrEmail = { "o@outlook.com", "hr6zdl@yandex.ru", "kaft93x@outlook.com",
                "dcu@yandex.ru", "19dn@outlook.com", "pa5h@mail.ru", "281av0@gmail.com",
                "8edmfh@outlook.com", "sfn13i@mail.ru", "g0orc3x1@outlook.com"};

            string[] arrVkID = { "1w96e3", "e228q4", "2650w5", "2e92t6", "32dy47",
                "35q6y8", "388tr9", "42e1y0", "45h3s1", "48fg52"};

            long[] arrNumber = {76896849592, 73788997271, 79958027501, 71858335201, 70402551651,
                75818585371, 73785003371, 73730705511, 72646996771, 7307886666 };

            //Создает случайную комбинацию контактов и добавляет в _project
            _project.Contacts.Add(new Contact(
                arrSurname[r.Next(0, arrSurname.Length - 1)],
                arrName[r.Next(0, arrSurname.Length - 1)],
                date,
                arrEmail[r.Next(0, arrSurname.Length - 1)],
                arrVkID[r.Next(0, arrSurname.Length - 1)],
                arrNumber[r.Next(0, arrSurname.Length - 1)]));
        }

        /// <summary>
        /// Удаляет контакт
        /// </summary>
        /// <param name="index"></param>
        private void RemoveContact(int index)
        {
            //Если ни один контакт не выбран, ничего не происходит
            if (index == -1)
            {

            }
            else
            {
                DialogResult result = MessageBox.Show(
                    $"Do you really want to remove " + $"{_project.Contacts[index].Surname} ?",
                    "Message",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);

                if (result == DialogResult.Yes)
                {
                    ContactsListBox.Items.RemoveAt(index);
                    _project.Contacts.RemoveAt(index);
                }
            }         
        }

        private void UpdateSelectedContact(int index)
        {
            if (index == -1)
            {
                ClearSelectedContact(ContactsListBox.SelectedIndex);
            }
            else
            {
                SurnameTextBox.Text = _project.Contacts[index].Surname;
                NameTextBox.Text = _project.Contacts[index].Name;
                DateOfBirthTimePicker.Value = _project.Contacts[index].DateOfBirth;
                PhoneNumberTextBox.Text = Convert.ToString(_project.Contacts[index].PhoneNumber.Number);
                EmailTextBox.Text = _project.Contacts[index].Email;
                VKIDTextBox.Text = _project.Contacts[index].VkID;
            }    
        }

        private void ClearSelectedContact(int index)
        {
            SurnameTextBox.Text = "";
            NameTextBox.Text = "";
            DateOfBirthTimePicker.Value = DateTime.Now;
            PhoneNumberTextBox.Text = "";
            EmailTextBox.Text = "";
            VKIDTextBox.Text = "";
        }

        private void ContactsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSelectedContact(ContactsListBox.SelectedIndex);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            //ContactForm contactForm = new ContactForm();
            //contactForm.Show();
            AddContact();
            UpdateListBox();
        }
        private void AddContactToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ContactForm contactForm = new ContactForm();
            contactForm.Show();
            AddContact();
            UpdateListBox();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            RemoveContact(ContactsListBox.SelectedIndex);
            UpdateListBox();
        }

        private void RemoveContactToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            RemoveContact(ContactsListBox.SelectedIndex);
            UpdateListBox();
        }

        private void ExitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                    $"Do you really want to exit?",
                    "Message",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            ContactForm contactForm = new ContactForm();
            contactForm.Show();
        }

        private void EditContactToolStripMenuItem1_Click(object sender, EventArgs e)
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

        private void FindBox_TextChanged(object sender, EventArgs e)
        {

        }

        public MainForm()
        {
            InitializeComponent();
        }

    }
}

            