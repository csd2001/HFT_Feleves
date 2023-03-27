using Microsoft.AspNetCore.Mvc;
using LLQ0P5_HFT_2022231.Logic.Interfaces;
using LLQ0P5_HFT_2022231.Logic.Classes;
using System.Collections.Generic;
using LLQ0P5_HFT_2022231.Models;

namespace MovieDbApp.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IPlayLogic logic;

        public StatController(IPlayLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<HelpC.DirectorWithPlay> directorWithPlay()
        {
            return this.logic.directorWithPlay();
        }

        [HttpGet]
        public IEnumerable<HelpC.actordate> FirstPlayWithActor()
        {
            return this.logic.FirstPlayWithActor();
        }
        [HttpGet]
        public IEnumerable<HelpC.Most> MostActors()
        {
            return this.logic.MostActors();
        }
        [HttpGet]
        public IEnumerable<HelpC.IncomePerYear> MostIncomeWithActor()
        {
            return this.logic.MostIncomeWithActor();
        }
        [HttpGet]
        public IEnumerable<HelpC.MostR> MostRoles()
        {
            return this.logic.MostRoles();
        }
        [HttpGet]
        public List<int> Plays()
        {
            return this.logic.Plays();
        }
        
       
    }
}