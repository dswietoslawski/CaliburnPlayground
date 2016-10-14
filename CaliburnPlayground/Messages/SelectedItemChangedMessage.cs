using CaliburnPlayground.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnPlayground.Messages
{
    public class SelectedItemChangedMessage
    {
        public ToDoItem toDoItem { get; set; }
    }
}
