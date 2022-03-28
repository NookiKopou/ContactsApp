using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Model
{
    class PhoneNumber
    {
        /// <summary>
        /// Номер телефона.
        /// </summary>
        private long _number;

        /// <summary>
        /// Возвращает или задает номер телефона.
        /// </summary>
        public long Number
        {
            get
            {
                return _number;
            }
            set
            {
                if ((value > 79999999999) && (value < 70000000000))
                {
                    throw new ArgumentException($"Number must start with 7 and contain 11 digits."
                    + $"But was {value}");
                }
                _number = value;
            }
        }

        /// <summary>
        /// Создает экземпляр <see cref="PhoneNumber">.
        /// </summary>
        public PhoneNumber(long number)
        {
            Number = number;
        }
    }
}
