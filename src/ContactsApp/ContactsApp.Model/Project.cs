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
        /// Возвращает или задает список контактов. Вариант для VS 2019
        /// </summary>
        public List<Contact> Contacts { get; set; } = new List<Contact>();

        /// <summary>
        ///  Возвращает или задает список контактов. Вариант для VS 2013
        /// </summary> 
        /*public List<Contact> Contacts {get; set;}

        public Project()
        {
            Contacts = new List<Contact>();
        } */

        /// <summary>
        /// Сортирует по алфавиту
        /// </summary>
        /// <param name="Contacts"></param>
        /// <returns></returns>
        public List<Contact> SortAlphabetically(List<Contact> contacts)
        {
            contacts = contacts.OrderBy(contact => contact.Surname).ToList();
            return contacts;
        }

        /// <summary>
        /// Ищет контакты с выбранным днем рождения
        /// </summary>
        /// <param name="Contacts"></param>
        /// <param name="dateOfBirth"></param>
        /// <returns></returns>
        public List<Contact> SearchByDateOfBirth(List<Contact> contacts)
        {
            contacts =contacts.Where(contact => (contact.DateOfBirth.Day == DateTime.Now.Day) && (contact.DateOfBirth.Month == DateTime.Now.Month)).ToList();
            return contacts;
        }
    }
}
