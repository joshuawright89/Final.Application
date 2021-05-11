using Final.Data.Entities;
using Final.Models;
using Final.Models.TaskModels;
using Final.Models.ToDoModels;
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
        }                                         //This is for connecting the a user's identity to any note he creates, not needed, but how do we have each new entity stored with its own incrememented Id???

        //Create
        public bool CreateToDo(ToDoCreate model)
        {
            ToDo entity = new ToDo()
            {
                ToDoName = model.TaskName
            };

            using (var ctx = new ApplicationDbContext())
            {
                _ctx.ToDos.Add(entity);
            return _ctx.SaveChanges() == 1;
            }
        }


        //Get (ALL)
        public List<ToDoListItem> GetAllToDos()
        {
            var toDoEntities = _ctx.ToDos.ToList();
            var toDoList = toDoEntities.Select(t => new ToDoListItem
            {
                Id = t.Id,
                ToDoName = t.ToDoName,
                DaysAssignedThisToDo = t.DaysAssignedThisToDo
            }).ToList();
            return toDoList;
        }


        //Get (Details by Id)
        public ToDoDetails GetToDoById(int toDoId)
        {
            var toDoEntity = _ctx.ToDos.Find(toDoId);
            if (toDoEntity == null)
                return null;

            var toDoList = new ToDoDetails
            {
                Id = toDoEntity.Id,
                ToDoName = toDoEntity.ToDoName,
                DaysAssignedThisToDo = toDoEntity.DaysAssignedThisToDo
            };
            return toDoList;
        }

        //UPDATE
        public bool UpdateToDo(ToDoEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .ToDos
                    .Single(e => e.Id == model.Id);

                entity.ToDoName = model.ToDoName;
                entity.DaysAssignedThisToDo = model.DaysAssignedThisToDo;

                return ctx.SaveChanges() == 1;
            }
        }


        //DELETE
        public bool DeleteToDo(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .ToDos
                    .Single(e => e.Id == id);

                ctx.ToDos.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }


    }
}
