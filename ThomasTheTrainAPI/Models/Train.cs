using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThomasTheTrainAPI.Models
{
    public class Train
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int EnginePower { get; set; }
    }
}
