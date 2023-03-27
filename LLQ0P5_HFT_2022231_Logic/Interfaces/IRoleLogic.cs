using LLQ0P5_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLQ0P5_HFT_2022231.Logic.Interfaces
{
    public interface IRoleLogic
    {
        void Create(Role Item);
        void Delete(int id);
        Role Read(int id);
        IQueryable<Role> ReadAll();
        void Update(Role item);
    }
}
