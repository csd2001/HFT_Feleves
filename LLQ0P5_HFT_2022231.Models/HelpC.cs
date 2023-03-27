using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLQ0P5_HFT_2022231.Models
{
   public class HelpC
    {

        public class actordate
        {
            public actordate()
            {

            }

            public string name { get; set; }
            public DateTime date { get; set; }


        }
        public class Most
        {
            public Most()
            {
            }


            public int Count { get; set; }
            public string PlayTitle { get; set; }
        }
        public class MostR
        {
            public MostR()
            {

            }

            public int Roles { get; set; }
            public string Title { get; set; }
        }
        public class DirectorWithPlay
        {
            public DirectorWithPlay()
            {
            }

            public string Director { get; set; }
            public string Title { get; set; }
            public string dname()
            {
                return Director;
            }



        }
        public class IncomePerYear
        {
            public IncomePerYear()
            {

            }

            public string Actor { get; set; }
            public int Income { get; set; }

            public int money()
            {
                return Income;
            }
        }
    
}
}
