using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Album
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int ArtishId { get; set; } // artishId.Name
        public Artish Artish { get; set; }
        [Required]
        public DateTime Year { get; set; }
        [Required]
        public int GanreId { get; set; }
        public Ganre Ganre { get; set; }
        public int AuditionNumber { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}