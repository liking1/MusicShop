using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Artish
    {
        public Artish()
        {

        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public int CountryId { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
        public virtual Country Country { get; set; }
    }
}
