using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Playlist
    {
        public Playlist()
        {
            this.Tracks = new HashSet<Track>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public ICollection<Track> Tracks { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
