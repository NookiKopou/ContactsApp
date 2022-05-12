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
        /// <summary>
        /// Объявление переменных
        /// </summary>
        private string _surnameError, _nameError, _dateOfBirthError,
            _phoneNumberError, _emailError, _vkIDError;

        /// <summary>
        /// Создает новый экземпляр и заполняет его данными
        /// </summary>
        private Contact _contact = new Contact("Orlov", "Artyom", new DateTime(2002, 3, 8),
            "o@outlook.com", "1w96e3", 76896849592);

        /// <summary>
        /// Выводит данные на форму
        /// </summary>
        private void UpdateForm()
        {
            SurnameTextBox.Text = _contact.Surname;
            NameTextBox.Text = _contact.Name;
            DateOfBirthTimePicker.Value = _contact.DateOfBirth;
            PhoneNumberTextBox.Text = Convert.ToString(_contact.PhoneNumber.Number);
            EmailTextBox.Text = _contact.Email;
            VKIDTextBox.Text = _contact.VkID;
        }

        /// <summary>
        /// Валидация фамилии
        /// </summary>
        private void SurnameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _surnameError = String.Empty;
                _contact.Surname = SurnameTextBox.Text;
                SurnameTextBox.BackColor = Color.White;

            }
            catch (ArgumentException exception)
            {
                SurnameTextBox.BackColor = Color.LightPink;
                _surnameError = exception.Message;
            }           
        }

        /// <summary>
        /// Валидация имени
        /// </summary>
        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _nameError = String.Empty;
                _contact.Name = NameTextBox.Text;
                NameTextBox.BackColor = Color.White;

            }
            catch (ArgumentException exception)
            {
                NameTextBox.BackColor = Color.LightPink;
                _nameError = exception.Message;
            }
        }

        /// <summary>
        /// Валидация даты рождения
        /// </summary>
        private void DateOfBirthTimePicker_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                _dateOfBirthError = String.Empty;
                _contact.DateOfBirth = DateOfBirthTimePicker.Value;
                DateOfBirthTimePicker.BackColor = Color.White;

            }
            catch (ArgumentException exception)
            {
                DateOfBirthTimePicker.BackColor = Color.LightPink;
                _dateOfBirthError = exception.Message;
            }
        }

        /// <summary>
        /// Валидация номера телефона
        /// </summary>
        private void PhoneNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _phoneNumberError = String.Empty;
                _contact.PhoneNumber.Number = long.Parse(PhoneNumberTextBox.Text);
                PhoneNumberTextBox.BackColor = Color.White;

            }
            catch (ArgumentException exception)
            {
                PhoneNumberTextBox.BackColor = Color.LightPink;
                _phoneNumberError = exception.Message;
            }
        }

        /// <summary>
        /// Валидация E-mail`а
        /// </summary>
        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _emailError = String.Empty;
                _contact.Email = EmailTextBox.Text;
                EmailTextBox.BackColor = Color.White;

            }
            catch (ArgumentException exception)
            {
                EmailTextBox.BackColor = Color.LightPink;
                _emailError = exception.Message;
            }
        }

        /// <summary>
        /// Валидация ID VK
        /// </summary>
        private void VKIDTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _vkIDError = String.Empty;
                _contact.VkID = VKIDTextBox.Text;
                VKIDTextBox.BackColor = Color.White;

            }
            catch (ArgumentException exception)
            {
                VKIDTextBox.BackColor = Color.LightPink;
                _vkIDError = exception.Message;
            }
        }

        /// <summary>
        /// Проверка на ошибки и вывод сообщений о них
        /// </summary>
        private bool CheckFormOnErrors()
        {
            if ((_surnameError == "") && (_nameError == "") && (_dateOfBirthError == "") && 
                (_phoneNumberError == "") && (_emailError == "") && (_vkIDError == ""))
            {
                return true;
            }
            else
            {
                if (_surnameError != "")
                {
                    MessageBox.Show($"Surname must be no longer than 50 letters. "
                        + $"But was {SurnameTextBox.TextLength} letters",
                        "Error");
                }
                if (_nameError != "")
                {
                    MessageBox.Show($"Name must be no longer than 50 letters. "
                        + $"But was {NameTextBox.TextLength} letters",
                        "Error");
                }
                if (_dateOfBirthError != "")
                {
                    MessageBox.Show($"Year of birth cannot be less than 1900 "
                        + "and be later than today. " + $"But was {DateOfBirthTimePicker.Text}",
                        "Error");
                }
                if (_phoneNumberError != "")
                {
                    MessageBox.Show($"Number must start with 7 and contain 11 digits. "
                        + $"But was {PhoneNumberTextBox.Text}",
                        "Error");                 
                }
                if (_emailError != "")
                {
                    MessageBox.Show($"Email must be no longer than 50 letters. "
                        + $"But was {EmailTextBox.TextLength} letters",
                        "Error");
                }
                if (_vkIDError != "")
                {
                    MessageBox.Show($"VK ID must be no longer than 15 letters. "
                        + $"But was {VKIDTextBox.TextLength} letters",
                        "Error");
                }
                return false;
            }
        }

        /// <summary>
        /// Обновление данных в экземпляре
        /// </summary>
        private void UpdateContact()
        {
            _contact.Surname = SurnameTextBox.Text;
            _contact.Name = NameTextBox.Text;
            _contact.DateOfBirth = DateOfBirthTimePicker.Value;
            _contact.PhoneNumber.Number = long.Parse(PhoneNumberTextBox.Text);
            _contact.Email = EmailTextBox.Text;
            _contact.VkID = VKIDTextBox.Text;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (CheckFormOnErrors() == true)
            {
                UpdateContact();
                this.Close();
            }
        }

        public ContactForm()
        {
            InitializeComponent();
            UpdateForm();
        }
    }
}
