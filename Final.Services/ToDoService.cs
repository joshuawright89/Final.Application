﻿using Final.Data.Entities;
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
        //private readonly Guid _userId;
        //public ToDoService(Guid userId)
        //{
        //    _userId = userId;
        //}                                         This is for connecting the a user's identity to any note he creates, not needed, but how do we have each new entity stored with its own incrememented Id???

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
                Id = t.Id,
                ToDoName = t.ToDoName
            }).ToList();
            return toDoList;
        }


        //Get (Details by Id)
        public ToDoListItem GetToDoById(int toDoId)
        {
            var toDoEntity = _ctx.ToDos.Find(toDoId);
            if (toDoEntity == null)
                return null;

            var toDoList = new ToDoListItem
            {
                Id = toDoEntity.Id,
                ToDoName = toDoEntity.ToDoName
            };
            return toDoList;
        }



    }
}
