using WebApplication1.Models;
using WebApplication1.Crud;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Crud
{
    public class PostCrud : IPostCrud
    {
        private readonly ToDoListContext context;

        public PostCrud(ToDoListContext context)
        {
            this.context = context;
        }

        // POST ITEMS
        public async Task<ActionResult<ToDoListItem>> PostItems(PostItem postitem)
        {
            ToDoListItem toDoList = new ToDoListItem { Title = postitem.Title, DueDate = postitem.DueDate, CreatedAt = DateTime.Now, State = 0, Id = new Guid() };

            context.ToDoListItem.Add(toDoList);
            await context.SaveChangesAsync();
            return toDoList;
        }

        // GET ITEMS
        public async Task<IEnumerable<ToDoListItem>> GetItem()
        {
            return await context.ToDoListItem.ToListAsync();
        }

        // GET ITEMS BY ID
        public async Task<ToDoListItem> GetById(Guid id)
        {
            return await context.ToDoListItem.FindAsync(id);
        }


        // PATCH ITEMS
        public async Task UpdateStatusPatchAsync(Guid id, PatchState patchstate)
        {
            var state = await context.ToDoListItem.FindAsync(id);
            if (state != null)
            {

                state.State = patchstate.State;
                await context.SaveChangesAsync();
            }
        }

        public bool ToDoListItemExists(string title)
        {
            return context.ToDoListItem.Any(postitem => postitem.Title == title);
        }


    }
}