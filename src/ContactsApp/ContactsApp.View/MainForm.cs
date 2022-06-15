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
        /// Текущий список контактов  
        /// </summary>
        List<Contact> _currentContacts;

        /// <summary>
        /// Текущий список контактов с днем рождения.
        /// </summary> 
        List<Contact> _currentContactDateOfBirth;

        /// <summary>
        /// Вывод на экран списка заметок по выбранной категории
        /// </summary>
        private void OutputBirthday()
        {
            _currentContactDateOfBirth = _project.SearchByDateOfBirth(_currentContacts);
            if (_currentContactDateOfBirth.Count > 0)
            {
                DateOfBirthPanel.Visible = true;
            }
            else
            {
                DateOfBirthPanel.Visible = false;
            }
            for (int i = 0; i < _currentContactDateOfBirth.Count; i++)
            {
                BirthdaysLabel.Text = BirthdaysLabel.Text + _currentContactDateOfBirth[i].Surname + ", " ;
            }
        }

        /// <summary>
        /// Очищает все элементы списка и добавляет данные из коллекции 
        /// </summary>
        private void UpdateListBox()
        {           
            _currentContacts = _project.SortAlphabetically(_project.Contacts);
            ContactsListBox.Items.Clear();
            BirthdaysLabel.Text = "";
            for (int i = 0; i < _currentContacts.Count; i++)
            {
                   ContactsListBox.Items.Add(_currentContacts[i].Surname);
            }
            OutputBirthday();
        }

        /// <summary>
        /// Добавляет новый контакт
        /// </summary>
        private void AddContact()
        {
            ContactForm contactForm = new ContactForm();
            contactForm.Contact = null;
            contactForm.ShowDialog();
            if (contactForm.Contact != null)
            {
                _project.Contacts.Add(contactForm.Contact);
                UpdateListBox();
            }
        }

        /// <summary>
        /// Редактирует существующий контакт
        /// </summary>
        /// <param name="index"></param>
        private void EditContact(int index)
        {
            if (index == -1)
            {
                return;
            }
            ContactForm contactForm = new ContactForm();
            contactForm.Contact = _currentContacts[index]; 
            contactForm.ShowDialog();
            if (contactForm.Contact != null)
            {
                _currentContacts[index] = contactForm.Contact;
                _project.Contacts = _currentContacts;
                UpdateListBox();
            }
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
                return;
            }

            DialogResult result = MessageBox.Show(
                "Do you really want to remove " + _project.Contacts[index].Surname,
                "Message",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
            {
                ContactsListBox.Items.RemoveAt(index);
                _currentContacts.RemoveAt(index);
                _project.Contacts = _currentContacts;
                UpdateListBox();
            }         
        }

        /// <summary>
        /// Получает текущий объект и заполняет данные на правой панели главного окна
        /// </summary>
        /// <param name="index"></param>
        private void UpdateSelectedContact(int index)
        {
            if (index == -1)
            {
                SurnameTextBox.Text = "";
                NameTextBox.Text = "";
                DateOfBirthTimePicker.Value = DateTime.Now;
                PhoneNumberTextBox.Text = "";
                EmailTextBox.Text = "";
                VKIDTextBox.Text = "";
            }
            var path = _currentContacts[index];

            SurnameTextBox.Text = path.Surname;
            NameTextBox.Text = path.Name;
            DateOfBirthTimePicker.Value = path.DateOfBirth;
            PhoneNumberTextBox.Text = Convert.ToString(path.PhoneNumber.Number);
            EmailTextBox.Text = path.Email;
            VKIDTextBox.Text = path.VkID;
        }

        /// <summary>
        /// Очищает все элементы управления на правой панели главного окна
        /// </summary>
        private void ClearSelectedContact()
        {
            SurnameTextBox.Text = "";
            NameTextBox.Text = "";
            DateOfBirthTimePicker.Value = DateTime.Now;
            PhoneNumberTextBox.Text = "";
            EmailTextBox.Text = "";
            VKIDTextBox.Text = "";
        }

        /// <summary>
        /// Создает рандомный контакт
        /// </summary>
        private void AddRandomContact()
        {
            //Создает объект для рандомайзера
            Random rand = new Random();

            string[] arrSurname = { "Orlov", "Preobrazhensky", "Nikitin", "Golubev", "Pasternak",
                "Zaitsev", "Vinogradov", "Belyaev", "Agapov", "Antonov" };

            string[] arrName = { "Artyom", "Aleksandr", "Roman", "Yevgeny", "Ivan",
                "Denis",  "Alexey", "Dmitry", "Danyl", "Oleg" };

            //Создает объекты формата Year.Month.Day
            DateTime date = new DateTime(rand.Next(1900, DateTime.Now.Year), rand.Next(1, 12),
                rand.Next(1, 31));

            string[] arrEmail = { "o@outlook.com", "hr6zdl@yandex.ru", "kaft93x@outlook.com",
                "dcu@yandex.ru", "19dn@outlook.com", "pa5h@mail.ru", "281av0@gmail.com",
                "8edmfh@outlook.com", "sfn13i@mail.ru", "g0orc3x1@outlook.com"};

            string[] arrVkID = { "1w96e3", "e228q4", "2650w5", "2e92t6", "32dy47",
                "35q6y8", "388tr9", "42e1y0", "45h3s1", "48fg52"};

            long[] arrNumber = {76896849592, 73788997271, 79958027501, 71858335201, 70402551651,
                75818585371, 73785003371, 73730705511, 72646996771, 7307886666 };

            //Создает случайную комбинацию контактов и добавляет в _project
            _project.Contacts.Add(new Contact(
                arrSurname[rand.Next(0, arrSurname.Length - 1)],
                arrName[rand.Next(0, arrSurname.Length - 1)],
                date,
                arrEmail[rand.Next(0, arrSurname.Length - 1)],
                arrVkID[rand.Next(0, arrSurname.Length - 1)],
                arrNumber[rand.Next(0, arrSurname.Length - 1)]));
        }

        private void ContactsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ContactsListBox.SelectedIndex == -1)
            {
                ClearSelectedContact();
                return;
            }
            UpdateSelectedContact(ContactsListBox.SelectedIndex);
        }

        private void addRandomContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddRandomContact();
            UpdateListBox();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddContact();
            UpdateListBox();
        }

        private void AddContactToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
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
                    "Do you really want to exit?",
                    "Message",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            int index = ContactsListBox.SelectedIndex;
            EditContact(index);
            UpdateSelectedContact(index);
            UpdateListBox();
            ContactsListBox.SelectedIndex = index;
        }

        private void EditContactToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int index = ContactsListBox.SelectedIndex;
            EditContact(index);
            UpdateSelectedContact(index);
            UpdateListBox();
            ContactsListBox.SelectedIndex = index;
        }

        private void AboutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.Show();
        }

        public MainForm()
        {
            InitializeComponent();
            ClearSelectedContact();
        }
    }
}

            