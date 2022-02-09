using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Crud
{
    public interface IPostCrud
    {
        Task<IEnumerable<ToDoListItem>> GetItem();
        Task<ActionResult<ToDoListItem>> PostItems(PostItem postitem);
        Task<ToDoListItem> GetById(Guid id);
        Task UpdateStatusPatchAsync(Guid id, PatchState patchstate);
        Boolean ToDoListItemExists(string title);
    }
}