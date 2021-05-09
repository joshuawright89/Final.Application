using Final.Data.Entities;
using Final.Models;
using Final.Models.TaskModels;
using FinalMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Services
{
    public class ToDoService
    {
        private readonly ApplicationDbContext _ctx = new ApplicationDbContext();
        private readonly Guid _userId;
        public ToDoService(Guid userId)
        {
            _userId = userId;
        }

        //Create
        public bool CreateTask(ToDoCreate model)
        {
            ToDo entity = new ToDo
            {
                ToDoName = model.TaskName
            };

            _ctx.ToDos.Add(entity);
            return _ctx.SaveChanges() == 1;
        }


        //Get (ALL)
        public List<ToDoListItem> GetAllToDos()
        {
            var toDoEntities = _ctx.ToDos.ToList();
            var toDoList = toDoEntities.Select(t => new ToDoListItem
            {
                ToDoId = t.ToDoId,
                ToDoName = t.ToDoName
            }).ToList();
            return toDoList;
        }


        //Get (Details by Id)
        public ToDoListItem GetToDoById(int toDoId)
        {
            var toDoEntity = _ctx.ToDos.Find(toDoId);
            var toDoList = new ToDoListItem
            {
                ToDoId = toDoEntity.ToDoId,
                ToDoName = toDoEntity.ToDoName
            };
            return toDoList;
        }



    }
}
