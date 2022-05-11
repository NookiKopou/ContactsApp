using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Model
{
    /// <summary>
    /// Описывает список контактов.
    /// </summary> 
    public class Project
    {
        /// <summary>
        /// Возвращает или задает список контактов.
        /// </summary>
        public List<Contact> Contacts { get; set; } = new List<Contact>();

        /// <summary>
        /// Вариант для VS 2013
        /// </summary> 
        /*public List<Contact> Contacts {get; set;}

        public Project()
        {
            Contacts = new List<Contact>();
        } */
    }
}
