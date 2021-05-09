using Final.Data.Entities;
using Final.Models.DayModels;
using FinalMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Services
{
    public class DayService
    {
        private readonly ApplicationDbContext ctx = new ApplicationDbContext();

        private readonly Guid _dayId;
        public DayService(Guid dayId)
        {
            _dayId = dayId;
        }

        //Create
        public bool CreateDay(DayCreate model)
        {
            Day entity =
                new Day()
                {
                    Today = DateTime.Today,
                    DayName = model.DayName
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Days.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //Get ALL Days
        public List<DayListItem> GetAllDays()
        {
            var dayEntities = ctx.Days.ToList();
            var dayList = dayEntities.Select(d => new DayListItem
            {
                Today = d.Today,
                DayId = d.DayId,
                DayName = d.DayName,
                TasksAssignedForToday = d.TasksAssignedForToday
            }).ToList();
            return dayList;

        }


        //Get ALL days with a specific task assigned
        public DayListItem GetDayByTask(TasksForTheDay TasksAssignedForToday)
        {
            var dayEntity = ctx.Days.Find(TasksAssignedForToday);
            if (dayEntity == null)
                return null;

            var listItem = new DayListItem
            {
                Today = dayEntity.Today,
                DayId = dayEntity.DayId,
                DayName = dayEntity.DayName,
                TasksAssignedForToday = dayEntity.TasksAssignedForToday
            };
            return listItem;
        }



    }
}
