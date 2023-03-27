using LLQ0P5_HFT_2022231.Logic.Interfaces;
using LLQ0P5_HFT_2022231.Models;
using LLQ0P5_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLQ0P5_HFT_2022231.Logic.Classes
{
    public class RoleLogic : IRoleLogic
    {
        IRepository<Role> repository;
        public RoleLogic(IRepository<Role> repository)
        {
            this.repository = repository;
        }
        public void Create(Role item)
        {
            if (item.Rolename == null)
            {
                this.repository.Create(item);
            }
            else
            {
                this.repository.Create(item);
            }

        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
        }

        public Role Read(int id)
        {
           return this.repository.Read(id);
        }

        public IQueryable<Role> ReadAll()
        {
            return repository.ReadAll();
        }

        public void Update(Role item)
        {
            repository.Update(item);
        }
     
     
    }
}
