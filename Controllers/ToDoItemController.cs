using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoAPI.Models;
using ToDoAPI.Services;

namespace ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<ToDoItem>> GetAll() => ToDoItemService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<ToDoItem> Get(int id)
        {
            var todoItem = ToDoItemService.Get(id);
            if (todoItem == null)
                return NotFound();
            return todoItem;
        }

        [HttpPost]
        public IActionResult Create(ToDoItem item)
        {
            ToDoItemService.Add(item);
            return CreatedAtAction(nameof(Create), new { Id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, ToDoItem item)
        {
            if (id != item.Id)
                return BadRequest();
            var existingItem = ToDoItemService.Get(id);
            if (existingItem is null)
                return NotFound();
            ToDoItemService.Update(item);
            return NoContent();
        }

        // DELETE api/<ToDoItemController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var toDoItem = ToDoItemService.Get(id);

            if (toDoItem is null)
                return NotFound();

            ToDoItemService.Delete(id);

            return NoContent();
        }
    }
}
