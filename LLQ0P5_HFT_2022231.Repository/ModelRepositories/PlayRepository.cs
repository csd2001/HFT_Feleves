using LLQ0P5_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLQ0P5_HFT_2022231.Repository
{
    public class PlayRepository : Repository<Play>, IRepository<Play>
    {
        public PlayRepository(PlayDbContext ctx) : base(ctx)
        {
        }

        public override Play Read(int id)
        {
            return ctx.Play.FirstOrDefault(t => t.PlayID == id);
        }

        public override void Update(Play item)
        {
            var old = Read(item.PlayID);
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
