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
        /// Экземпляр класс ProjectSerializer для сереализации.
        /// </summary>
        private ProjectSerializer _projectSerializer = new ProjectSerializer();

        /// <summary>
        /// Вывод на экран списка заметок по выбранной категории
        /// </summary>
        private void OutputBirthday()
        {
            _currentContactDateOfBirth = _project.SearchByDateOfBirth(_currentContacts);
            DateOfBirthPanel.Visible = _currentContactDateOfBirth.Count > 0;

            var surnames = _currentContactDateOfBirth.Select(contact => contact.Surname).ToArray();
            BirthdaysLabel.Text = string.Join(",", surnames);
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
                _projectSerializer.SaveToFile(_project);
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
                _projectSerializer.SaveToFile(_project);
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
                _projectSerializer.SaveToFile(_project);
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
            var contact = _currentContacts[index];

            SurnameTextBox.Text = contact.Surname;
            NameTextBox.Text = contact.Name;
            DateOfBirthTimePicker.Value = contact.DateOfBirth;
            PhoneNumberTextBox.Text = Convert.ToString(contact.PhoneNumber.Number);
            EmailTextBox.Text = contact.Email;
            VKIDTextBox.Text = contact.VkID;
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

        private void ContactsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ContactsListBox.SelectedIndex == -1)
            {
                ClearSelectedContact();
                return;
            }
            UpdateSelectedContact(ContactsListBox.SelectedIndex);
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
                _projectSerializer.SaveToFile(_project);
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

            //Выгружает из файла userdata.json.
            _project = _projectSerializer.LoadFromFile();

            _currentContacts = _project.SortAlphabetically(_project.Contacts);
            for (int i = 0; i < _currentContacts.Count; i++)
            {
                ContactsListBox.Items.Add(_currentContacts[i].Surname);
            }
            OutputBirthday();
        }
    }
}

            