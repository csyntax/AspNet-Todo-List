using MyAutoMapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TodoList.Models;

namespace TodoList.Web.ViewModels.Todo
{
    public class ToDoItemViewModel : IMapFrom<TodoItem>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
    }
}