using System;

namespace BLL
{
    public class AlbumDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ArtishId { get; set; }
        public DateTime Year { get; set; }
        public int GanreId { get; set; }
        public int AuditionNumber { get; set; }
    }
}
