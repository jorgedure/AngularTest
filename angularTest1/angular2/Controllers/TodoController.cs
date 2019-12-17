using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.BLL.Interfaces;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace angular2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoListServices todoListServices;

        public TodoController(ITodoListServices _todoListServices) {
            todoListServices = _todoListServices;
        }

        [HttpPost]
        public int Add([FromBody]TodoList todoItem)
        {
            return todoListServices.AddTodo(todoItem);
        }
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return todoListServices.DeleteTodo(id);
        }
        [HttpGet]
        public IEnumerable<TodoList> GetAll()
        {
            return todoListServices.GetAll();
        }
        [HttpPost("Edit")]
        public int Edit(TodoList todoItem)
        {
            return todoListServices.UpdateTodo(todoItem);
        }

        //[HttpPost("CheckAll")]
        //public IEnumerable<TodoList> CheckAll(TodoList todo) {

        //    return todoListServices.GetAll();
        //}
    }
}