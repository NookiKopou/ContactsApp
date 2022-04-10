using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Model
{
    public class Project
    {
        /// <summary>
        /// Список контактов.
        /// </summary>
        private List<string> contacts = new List<string>();

        /// <summary>
        /// Возвращает или задает номер телефона.
        /// </summary>
        public List<string> Contacts
        {
            get
            {
                return contacts;
            }
            set
            {
                contacts = value;
            }
        }

        /// <summary>
        /// Создает экземпляр <see cref="Project">.
        /// </summary>
        public Project(List<string> contacts)
        {
            Contacts = contacts;
        }
    }
}
