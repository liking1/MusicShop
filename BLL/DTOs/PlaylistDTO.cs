using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PlaylistDTO
    {
        public PlaylistDTO()
        {
            this.Tracks = new HashSet<Track>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Track> Tracks { get; set; }
        public int CategoryId { get; set; }
    }
}
