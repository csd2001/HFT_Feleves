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
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleID { get; set; }
        public string Rolename { get; set; }

        public int PlayId { get; set; }
        public int ActorId { get; set; }
        [JsonIgnore]

        public virtual Actor Actor { get; set; }
        [JsonIgnore]

        public virtual Play Play { get; set; }
        public Role() { 
        
        }
    }
}
