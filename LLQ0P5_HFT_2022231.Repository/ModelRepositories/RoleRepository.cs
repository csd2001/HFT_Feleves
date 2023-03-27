using LLQ0P5_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLQ0P5_HFT_2022231.Repository
{
    public class RoleRepository : Repository<Role>, IRepository<Role>
    {
        public RoleRepository(PlayDbContext ctx) : base(ctx)
        {
        }

        public override Role Read(int id)
        {
            return ctx.Roles.FirstOrDefault(t => t.RoleID == id);
        }

        public override void Update(Role item)
        {
            var old = Read(item.RoleID);
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
