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
        private readonly Guid _userId;
        public DayService(Guid userId)
        {
            _userId = userId;
        }

        private readonly ApplicationDbContext ctx = new ApplicationDbContext();

        //Create
        public bool CreateDay(DayCreate model)
        {
            Day entity =
                new Day()
                {
                    Today = model.Today,
                    DayLabel = model.DayLabel
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Days.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //Get ALL Days   I PROBABLY DO NOT NEED THIS, AS THERE IS A DAY/INDEX URL THAT WILL SHOW DAY OBJECTS... RIGHT?
        public List<DayListItem> GetAllDays()
        {
            var dayEntities = ctx.Days.ToList();
            var dayList = dayEntities.Select(d => new DayListItem
            {
                Today = d.Today,
                Id = d.Id,
                DayLabel = d.DayLabel,
                ToDosAssignedForToday = d.ToDosAssignedForToday
            }).ToList();
            return dayList;

        }


        //Get ALL days by a specific user
        public IEnumerable<DayListItem> GetDaysByUser()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Days
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new DayListItem
                        {
                            Id = e.Id,
                            Today = e.Today,
                            DayLabel = e.DayLabel,
                            ToDosAssignedForToday = e.ToDosAssignedForToday
                        }
                        );
                return query.ToArray();
            }
        }


    }
}
