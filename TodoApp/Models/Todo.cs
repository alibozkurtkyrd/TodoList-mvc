using System;
using System.Collections.Generic;

namespace TodoApp.Models
{
    public partial class Todo
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateOnly? CreatedDate { get; set; }
        public int? Status { get; set; }
    }
}
