using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AplicationDataContext;
using Core.BLL.Interfaces;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.BLL.Services
{
    public class TodoListServices : ITodoListServices
    {
        private DataContext _db;

        public TodoListServices(DataContext db)
        {
            _db = db;
        }

        public int AddTodo(TodoList todoItem)
        {
            try
            {
                _db.TodoList.Add(todoItem);
                _db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }
        public int DeleteTodo(int id)
        {
            try
            {
                TodoList todo = _db.TodoList.Find(id);
                _db.TodoList.Remove(todo);
                _db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }
        public int UpdateTodo(TodoList todoItem)
        {
            _db.Entry(todoItem).State = EntityState.Modified;
            _db.SaveChanges();
            return 1;
        }
        public IEnumerable<TodoList> GetAll()
        {
            try
            {
                return _db.TodoList.ToList().OrderBy(x => x.Id);
            }
            catch
            {
                throw;
            }
        }
        

    }
}
