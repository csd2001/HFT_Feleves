﻿using LLQ0P5_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLQ0P5_HFT_2022231.Repository
{
    public class DirectorRepository : Repository<Director>, IRepository<Director>
    {
        public DirectorRepository(PlayDbContext ctx) : base(ctx)
        {
        }

        public override Director Read(int id)
        {
            return ctx.Directors.FirstOrDefault(t => t.DirectorId == id);
        }

        public override void Update(Director item)
        {
            
                var old = Read(item.DirectorId);
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
