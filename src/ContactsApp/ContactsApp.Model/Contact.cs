﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ContactsApp.Model
{
    class Contact
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
        PhoneNumber _number;

        /// <summary>
        /// Дата рождения.
        /// </summary>
        private DateTime _birthday;

        /// <summary>
        /// E-mail.
        /// </summary>
        private string _email;

        /// <summary>
        /// ID ВКонтакте.
        /// </summary>
        private string _vkID;

        ///public interface ICloneable();

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
                    throw new ArgumentException($"Surname must be no longer than 50 letters." 
                        + $"But was {value}");
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
                    throw new ArgumentException($"Name must be no longer than 50 letters." 
                        + $"But was {value}");
                }
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                _name = textInfo.ToTitleCase(value);
            }
        }

        /// <summary>
        /// Возвращает или задает номер телефона.
        /// </summary>
        public PhoneNumber Number
        {
            get
            {
                return _number;
            }
        }

        /// <summary>
        /// Возвращает или задает дату рождения.
        /// </summary>
        public DateTime Birthday
        {
            get
            {
                return _birthday;
            }
            set
            {
                if (value.Year < 1900 || value.Year > DateTime.Now.Year)
                {
                    throw new ArgumentException($"Number must start with 7 and contain 11 digits."
                    + $"But was {value}");
                }
                _birthday = value;
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
                    throw new ArgumentException($"Email must be no longer than 50 letters." 
                        + $"But was {value}");
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
                    throw new ArgumentException($"Email must be no longer than 15 letters." 
                        + $"But was {value}");
                }
                _vkID = value;
            }
        }

        /// <summary>
        /// Создает экземпляр <see cref="Surname">.
        /// </summary>
        public Contact(string surname, string name, DateTime birthday, string email, string vkID)
        {
            Surname = surname;
            Name = name;
            Birthday = birthday;
            Email = email;
            VkID = vkID;
        }
    }
}
