using Final.Data.Entities;
using Final.Models;
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

        //CREATE
        public bool CreateDay(DayCreate model)
        {
            Day entity =
                new Day()
                {
                    Today = model.Today,
                    DayLabel = model.DayLabel,
                    ToDosAssignedForToday = model.ToDosAssignedForToday,
                    Focus = model.Focus
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Days.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //READ

        //Get ALL Days   I PROBABLY DO NOT NEED THIS, AS THERE IS A DAY/INDEX URL THAT WILL SHOW DAY OBJECTS... RIGHT?
        public List<DayListItem> GetAllDays()
        {
            var dayEntities = ctx.Days.ToList();
            var dayList = dayEntities.Select(d => new DayListItem
            {
                Today = d.Today,
                Id = d.Id,
                DayLabel = d.DayLabel,
                ToDosAssignedForToday = d.ToDosAssignedForToday,
                Focus = d.Focus
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
                            ToDosAssignedForToday = e.ToDosAssignedForToday,
                            Focus = e.Focus
                        }
                        );
                return query.ToArray();
            }
        }

        public DayDetails GetDayById(int id)  //this is our GetDayById SERVICE method
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Days.Single(e => e.Id == id);
                return
                    new DayDetails
                    {
                        Id = entity.Id,
                        Today = entity.Today,
                        DayLabel = entity.DayLabel,
                        ToDosAssignedForToday = entity.ToDosAssignedForToday,
                        Focus = entity.Focus
                    };
            }
        }

        

        //UPDATE

        public bool UpdateDay(DayEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Days
                    .Single(e => e.Today == model.Today);

                entity.Today = model.Today;
                entity.DayLabel = model.DayLabel;
                entity.ToDosAssignedForToday = model.ToDosAssignedForToday;
                entity.Focus = model.Focus;

                return ctx.SaveChanges() == 1;
            }
        }

        //DELETE

        public bool DeleteDay(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Days
                    .Single(e => e.Id == id);

                ctx.Days.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
