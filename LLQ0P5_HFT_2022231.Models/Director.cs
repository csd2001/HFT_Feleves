using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LLQ0P5_HFT_2022231.Models
{
    public class Director
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DirectorId { get; set; }
        [StringLength(150)]
        public string Name { get; set; }
        [NotMapped]
        [JsonIgnore]

        public virtual ICollection<Play> Play { get; set; }

        public Director()
        {
            Play = new HashSet<Play>();
        }
              
    }
}
