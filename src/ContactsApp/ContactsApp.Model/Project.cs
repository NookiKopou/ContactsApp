using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Model
{
    class Project
    {
        /// <summary>
        /// Список контактов.
        /// </summary>
        private string _list;

        /// <summary>
        /// Возвращает или задает список контактов.
        /// </summary>
        public string List
        {
            get
            {
                return _list;
            }
            set
            {
                _list = value;
            }
        }
    }
}
/// Комментарий
