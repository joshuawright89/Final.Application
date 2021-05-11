using Final.Data;
using Final.Models.FocusModels;
using FinalMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Services
{
    public class FocusService
    {
        private readonly Guid _userId;
        public FocusService(Guid userId)
        {
            _userId = userId;
        }

        private readonly ApplicationDbContext ctx = new ApplicationDbContext();
        public bool CreateFocus(FocusCreate model)
        {
            var entity = new Focus()
            {
                FocusLabel = model.FocusLabel
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Focuses.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //GET (get all focuses)
        public IEnumerable<FocusListItem> GetFocuses()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Focuses
                    .Select(
                        e =>
                        new FocusListItem
                        {
                            FocusLabel = e.FocusLabel,
                            Id = e.Id,
                            DaysAssignedThisFocus = e.DaysAssignedThisFocus
                        });
                    return query.ToArray();
            }
        }


        //GET (Focus details by Id)
        public FocusDetails GetFocusById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var focusEntity = ctx.Focuses.Find(id);
                if (focusEntity == null) return null;

                var focusList = new FocusDetails
                {
                    Id = focusEntity.Id,
                    FocusLabel = focusEntity.FocusLabel,
                    DaysAssignedThisFocus = focusEntity.DaysAssignedThisFocus
                };
                return focusList;
            }
        }


        //UPDATE
        public bool UpdateFocus(FocusEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Focuses
                    .Single(e => e.Id == model.Id);

                entity.FocusLabel = model.FocusLabel;
                entity.DaysAssignedThisFocus = model.DaysAssignedThisFocus;

                return ctx.SaveChanges() == 1;
            }
        }


        //DELETE
        public bool DeleteFocus(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Focuses
                    .Single(e => e.Id == id);

                ctx.Focuses.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
