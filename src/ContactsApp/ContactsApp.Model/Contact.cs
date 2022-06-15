using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ContactsApp.Model
{
    /// <summary>
    /// Описывает контакт.
    /// </summary> 
    public class Contact: ICloneable
    {
        /// <summary>
        /// Фамилия.
        /// </summary>
        private string _surname;

        /// <summary>
        /// Имя.
        /// </summary>
        private string _name;

        /// <summary>
        /// Номер телефона.
        /// </summary>
        private PhoneNumber _phoneNumber = new PhoneNumber();

        /// <summary>
        /// Дата рождения.
        /// </summary>
        private DateTime _dateOfBirth = DateTime.Now;

        /// <summary>
        /// E-mail.
        /// </summary>
        private string _email;

        /// <summary>
        /// ID ВКонтакте.
        /// </summary>
        private string _vkID;

        /// <summary>
        /// Возвращает или задает фамилию.
        /// </summary>
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException("Surname must be no longer than 50 letters. " 
                        + "But was " + value.Length + " letters.\n");
                }
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                _surname = textInfo.ToTitleCase(value);
            }
        }

        /// <summary>
        /// Возвращает или задает имя.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException("Name must be no longer than 50 letters. " 
                        + "But was " + value.Length + " letters.\n");
                }
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                _name = textInfo.ToTitleCase(value);
            }
        }

        /// <summary>
        /// Возвращает или задает номер телефона.
        /// </summary>
        public PhoneNumber @PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                _phoneNumber = value;
            }
        }

        /// <summary>
        /// Возвращает или задает дату рождения.
        /// </summary>
        public DateTime DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }
            set
            {
                if ((value.Year < 1900) || (value.Year > DateTime.Now.Year))
                {
                    throw new ArgumentException("Year of birth cannot be less than 1900 "
                        + "and be later than today. " + "But was " + value.Day + ":" 
                        + value.Month + ":" + value.Year + ".\n");
                }
                _dateOfBirth = value;
            }
        }

        /// <summary>
        /// Возвращает или задает e-mail.
        /// </summary>
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException("Email must be no longer than 50 letters. " 
                        + "But was " + value.Length + " letters.\n");
                }
                _email = value;
            }
        }

        /// <summary>
        /// Возвращает или задает ID ВКонтакте.
        /// </summary>
        public string VkID
        {
            get
            {
                return _vkID;
            }
            set
            {
                if (value.Length > 15)
                {
                    throw new ArgumentException("VK ID must be no longer than 15 letters. " 
                        + "But was " + value.Length + " letters.\n");
                }
                _vkID = value;
            }
        }

        /// <summary>
        /// Создает экземпляр <see cref="Surname">.
        /// </summary>
        public Contact(string surname, string name, DateTime dateOfBirth, string email, 
                        string vkID, long phoneNumber)
        {
            Surname = surname;
            Name = name;
            DateOfBirth = dateOfBirth;
            Email = email;
            VkID = vkID;
            PhoneNumber phone = new PhoneNumber(phoneNumber);
            @PhoneNumber = phone;
        }

        /// <summary>
        /// Создает пустой экземпляр
        /// </summary>
        public Contact()
        {
        }

        /// <summary>
        /// Глубокое копирование заметки
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new Contact(Surname, Name, DateOfBirth, Email, VkID, _phoneNumber.Number);
        }
    }
}
