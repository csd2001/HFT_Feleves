using LLQ0P5_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLQ0P5_HFT_2022231.Logic.Interfaces
{
    public interface IDirectorLogic
    {
        void Create(Director item);
        void Delete(int id);
        Director Read(int id);
        IQueryable<Director> ReadAll();
        void Update(Director item);
    }
}
