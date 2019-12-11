using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Core.BLL.Interfaces
{
    public interface ITodoListServices
    {
        int AddTodo(TodoList todoItem);
        int DeleteTodo(int id);
        IEnumerable<TodoList> GetAll();
        int UpdateTodo(TodoList todoItem);

    }
}
