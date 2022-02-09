#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Crud;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private readonly IPostCrud postcrud;

        public ToDoListController(IPostCrud _postcrud)
        {
            postcrud = _postcrud;
        }

        // GET: api/ToDoListItems
        [HttpGet]
        public async Task<IEnumerable<ToDoListItem>> GetToDoListItem()
        {
            return await postcrud.GetItem();
        }

        // GET: api/ToDoListItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoListItem>> GetToDoListItem(Guid id)
        {
            var toDoListItem = await postcrud.GetById(id);

            if (toDoListItem == null)
            {
                return NotFound();
            }

            return Ok(toDoListItem);
        }

        // PATCH: api/ToDoListItems
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchToDoListItem([FromRoute] Guid id, [FromBody] PatchState patchstate)
        {
            await postcrud.UpdateStatusPatchAsync(id, patchstate);
            return Ok();
        }

        // POST: api/ToDoListItems
        [HttpPost]
        public async Task<ActionResult<ToDoListItem>> PostItems([FromBody] PostItem toDoListItem)
        {
            if (postcrud.ToDoListItemExists(toDoListItem.Title))
            {
                return BadRequest();
            }
            
            else
            {
                return await postcrud.PostItems(toDoListItem);
            }
        }
    }
}