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
        /// Ошибка фамилии
        /// </summary>
        private string _surnameError;

        /// <summary>
        /// Ошибка имени
        /// </summary>
        private string _nameError;

        /// <summary>
        /// Ошибка даты рождения
        /// </summary>
        private string _dateOfBirthError;

        /// <summary>
        /// Ошибка номера телефона
        /// </summary>
        private string _phoneNumberError;

        /// <summary>
        /// Ошибка e-mail`а
        /// </summary>
        private string _emailError;

        /// <summary>
        /// Ошибка VK ID
        /// </summary>
        private string _vkIDError;

        /// <summary>
        /// Цвет поля при ошибке
        /// </summary>
        private readonly Color ErrorColor = Color.LightPink;

        /// <summary>
        /// Цвет поля при корректных данных
        /// </summary>
        private readonly Color OkColor = Color.White;

        /// <summary>
        /// Общая ошибка
        /// </summary>
        private string _error = "";

        /// <summary>
        /// Создает новый экземпляр
        /// </summary>
        private Contact _contact;

        /// <summary>
        /// Создает копию экземпляра (создано для правильной работы CancelButton)
        /// </summary>
        private Contact _contactCopy;

        public ContactForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Создает копию контакта
        /// </summary>
        public Contact Contact
        {
            get
            {
                return _contact;
            }
            set
            {
                _contact = value;
                if (_contact != null)
                {
                    _contactCopy = (Contact)_contact.Clone();
                }
                else
                {
                    _contactCopy = new Contact();
                }
                UpdateForm();
            }
        }

        /// <summary>
        /// Выводит данные на форму
        /// </summary>
        private void UpdateForm()
        {
            SurnameTextBox.Text = _contactCopy.Surname;
            NameTextBox.Text = _contactCopy.Name;
            DateOfBirthTimePicker.Value = _contactCopy.DateOfBirth;
            if (SurnameTextBox.Text == "")
            {
                PhoneNumberTextBox.Text = "";
            }
            else
            {
                PhoneNumberTextBox.Text = Convert.ToString(_contactCopy.PhoneNumber.Number);
            }
            EmailTextBox.Text = _contactCopy.Email;
            VKIDTextBox.Text = _contactCopy.VkID;
        }

        /// <summary>
        /// Валидация фамилии
        /// </summary>
        private void SurnameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _surnameError = String.Empty;
                _contactCopy.Surname = SurnameTextBox.Text;
                SurnameTextBox.BackColor = OkColor;
            }
            catch (ArgumentException exception)
            {
                SurnameTextBox.BackColor = ErrorColor;
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
                _contactCopy.Name = NameTextBox.Text;
                NameTextBox.BackColor = OkColor;
            }
            catch (ArgumentException exception)
            {
                NameTextBox.BackColor = ErrorColor;
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
                _contactCopy.DateOfBirth = DateOfBirthTimePicker.Value;
                DateOfBirthTimePicker.BackColor = OkColor;
            }
            catch (ArgumentException exception)
            {
                DateOfBirthTimePicker.BackColor = ErrorColor;
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
                if (PhoneNumberTextBox.Text == null)
                {
                    return;
                }
                    _contactCopy.PhoneNumber.Number = long.Parse(PhoneNumberTextBox.Text);           
                PhoneNumberTextBox.BackColor = OkColor;
            }
            catch (ArgumentException exception)
            {
                PhoneNumberTextBox.BackColor = ErrorColor;
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
                _contactCopy.Email = EmailTextBox.Text;
                EmailTextBox.BackColor = OkColor;
            }
            catch (ArgumentException exception)
            {
                EmailTextBox.BackColor = ErrorColor;
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
                _contactCopy.VkID = VKIDTextBox.Text;
                VKIDTextBox.BackColor = OkColor;
            }
            catch (ArgumentException exception)
            {
                VKIDTextBox.BackColor = ErrorColor;
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
                    _error += _surnameError;
                }
                if (_nameError != "")
                {
                    _error += _nameError;
                }
                if (_dateOfBirthError != "")
                {
                    _error += _dateOfBirthError;
                }
                if (_phoneNumberError != "")
                {
                    _error += _phoneNumberError;
                }
                if (_emailError != "")
                {
                    _error += _emailError;
                }
                if (_vkIDError != "")
                {
                    _error += _vkIDError;
                }
                MessageBox.Show(_error, "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                _error = "";
                return false;
            }
        }

        /// <summary>
        /// Обновление данных в экземпляре
        /// </summary>
        private void UpdateContact()
        {
            _contactCopy.Surname = SurnameTextBox.Text;
            _contactCopy.Name = NameTextBox.Text;
            _contactCopy.DateOfBirth = DateOfBirthTimePicker.Value;
            _contactCopy.PhoneNumber.Number = long.Parse(PhoneNumberTextBox.Text);
            _contactCopy.Email = EmailTextBox.Text;
            _contactCopy.VkID = VKIDTextBox.Text;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {           
            if (CheckFormOnErrors())
            {
                UpdateContact();
                _contact = _contactCopy;
                DialogResult = DialogResult.OK;
            }
        }
    }
}
