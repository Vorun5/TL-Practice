using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todo_list.Entities
{
    public class ToDoEntity
    {
        public int Id { get; }
        public string Name { get; set; }
        public bool Done { get; set; }
    }
}
