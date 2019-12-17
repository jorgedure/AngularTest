using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities
{
    public class TodoList
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }
}
