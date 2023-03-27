using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LLQ0P5_HFT_2022231.Models
{
    public class Play
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlayID { get; set; }
        [StringLength(300)]
         public string Title { get; set; }
        [Range(0,5)]
        public double Rating { get; set; }
        public int Income { get; set; }
        public int DirectorId { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Director Director { get; set; }
        public DateTime ReleaseDate { get; set; }
        [NotMapped]
        [JsonIgnore]

        public virtual ICollection<Actor> Actors { get; set; }
        [NotMapped]
        [JsonIgnore]

        public virtual ICollection<Role> Roles { get; set; }
       public Play()
        {

        }

    }
}
