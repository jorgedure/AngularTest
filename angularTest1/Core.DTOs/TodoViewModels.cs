using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTOs
{
    public class TodoViewModels
    {
        public int Id { get; set; }
        public string TodoItem { get; set; }
        public bool Completed { get; set; }
        public bool Editing { get; set; }
    }
}
