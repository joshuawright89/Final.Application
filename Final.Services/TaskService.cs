using Final.Models.TaskModels;
using FinalMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Services
{
    public class TaskService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        //Create
        public bool CreateTask(TaskCreate model)
        {
            Task entity = new Task
            {
                TaskName = model.TaskName
            };

            _context.Tasks.Add(entity);
            if (_context.SaveChanges() == 1)
                return true;

            return false;
        }


        //Get (ALL)


        //Get (Details by Id)




    }
}
