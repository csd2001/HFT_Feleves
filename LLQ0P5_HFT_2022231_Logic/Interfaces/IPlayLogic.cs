
using LLQ0P5_HFT_2022231.Logic.Classes;
using LLQ0P5_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LLQ0P5_HFT_2022231.Logic.Classes.PlayLogic;

namespace LLQ0P5_HFT_2022231.Logic.Interfaces
{
    public interface IPlayLogic
    {
        void Create(Play item);
        void Delete(int id);
        Play Read(int id);
        IQueryable<Play> ReadAll();
        void Update(Play item);
        public IEnumerable<HelpC.actordate> FirstPlayWithActor();
        public IEnumerable<HelpC.Most> MostActors();
        public IEnumerable<HelpC.MostR> MostRoles();
        public IEnumerable<HelpC.IncomePerYear> MostIncomeWithActor();
        public IEnumerable<HelpC.DirectorWithPlay> directorWithPlay();
        public List<int> Plays();
    }
}
