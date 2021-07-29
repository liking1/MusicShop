using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TrackDTO
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public TimeSpan Duration { get; set; }
        public double? Rating { get; set; }
        public int AuditionNumber { get; set; }
        public string Text { get; set; }
        public string Name { get; set; }
    }
}
