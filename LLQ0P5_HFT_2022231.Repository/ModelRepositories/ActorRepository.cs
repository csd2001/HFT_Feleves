using LLQ0P5_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLQ0P5_HFT_2022231.Repository
{
    public class ActorRepository : Repository<Actor>, IRepository<Actor>
    {
        public ActorRepository(PlayDbContext ctx) : base(ctx)
        {
        }

        public override Actor Read(int id)
        {
            return ctx.Actors.FirstOrDefault(t => t.ActorId == id);
        }

        public override void Update(Actor item)
        {
            var old = Read(item.ActorId);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
