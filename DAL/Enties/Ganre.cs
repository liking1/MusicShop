using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Ganre
    {
        public int Id { get; set; }
        [Required]

        [MaxLength(400)]
        public string Name { get; set; }
    }
}
